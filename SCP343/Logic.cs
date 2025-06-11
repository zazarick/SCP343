using Exiled.API.Enums;
using Exiled.API.Extensions;
using Exiled.API.Features;
using Exiled.Events.EventArgs.Player;
using MEC;
using PlayerRoles;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;

namespace Scp343
{
    public static class Scp343Logic
    {
        public static Player Scp343Player { get; private set; } = null;

        private static readonly ItemType[] ScpItems = new[]
        {
            ItemType.SCP018, ItemType.SCP207, ItemType.SCP268, ItemType.SCP500, ItemType.SCP1576,
            ItemType.SCP1853, ItemType.SCP2176, ItemType.SCP244a, ItemType.SCP244b, ItemType.SCP330,
            ItemType.GunSCP127, ItemType.GunSCP127, ItemType.MicroHID
        };

        public static void RegisterEvents()
        {
            Exiled.Events.Handlers.Server.RoundStarted += OnRoundStarted;
            Exiled.Events.Handlers.Player.PickingUpItem += OnPickingUpItem;
            Exiled.Events.Handlers.Player.UsedItem += OnUsedItem;
            Exiled.Events.Handlers.Player.ChangingRole += OnChangingRole;
        }

        public static void UnregisterEvents()
        {
            Exiled.Events.Handlers.Server.RoundStarted -= OnRoundStarted;
            Exiled.Events.Handlers.Player.PickingUpItem -= OnPickingUpItem;
            Exiled.Events.Handlers.Player.UsedItem -= OnUsedItem;
            Exiled.Events.Handlers.Player.ChangingRole -= OnChangingRole;
            Scp343Player = null;
        }

        private static void OnRoundStarted()
        {
            var cfg = Scp343Plugin.Instance.Config;
            if (!cfg.EnableAutoSpawn)
                return;

            Timing.CallDelayed(2f, () =>
            {
                var allPlayersCount = Player.List.Count();
                if (allPlayersCount < cfg.MinPlayers)
                    return;

                var players = Player.List
                    .Where(p => p.Role == RoleTypeId.ClassD && p.IsAlive && !p.IsScp)
                    .ToList();

                if (players.Count == 0)
                    return;

                if (UnityEngine.Random.value > cfg.SpawnChance)
                    return;

                var selected = players[UnityEngine.Random.Range(0, players.Count)];
                MakeScp343(selected);
            });
        }

        public static void MakeScp343(Player player)
        {
            var cfg = Scp343Plugin.Instance.Config;
            Scp343Logic.Scp343Player = player;
            player.Role.Set(RoleTypeId.ClassD, RoleSpawnFlags.None);

            Timing.CallDelayed(0.5f, () =>
            {
                var dCells = Room.List.Where(r => r.Type == RoomType.LczClassDSpawn).ToList();
                if (dCells.Count > 0)
                {
                    var room = dCells[UnityEngine.Random.Range(0, dCells.Count)];
                    player.Teleport(room.Position + Vector3.up * 1f);
                }

                player.CustomInfo = "SCP-343";
                player.ClearInventory();

                int medCount = cfg.MedkitCount;
                for (int i = 0; i < medCount; i++)
                    player.AddItem(ItemType.Medkit);

                player.IsBypassModeEnabled = cfg.EnableBypass;
                player.IsGodModeEnabled = cfg.EnableGodMode;

                player.ShowHint(cfg.SpawnHint, 10f);
                player.SendConsoleMessage(cfg.SpawnHint, "yellow");
            });
        }

        private static void OnPickingUpItem(PickingUpItemEventArgs ev)
        {
            var cfg = Scp343Plugin.Instance.Config;
            if (Scp343Player == null)
                return;
            if (ev.Player != Scp343Player)
                return;

            if (ScpItems.Contains(ev.Pickup.Type))
            {
                ev.IsAllowed = false;
                ev.Player.ShowHint(cfg.ScpItemBlockHint, 2f);
                return;
            }

            var itemType = ev.Pickup.Type;
            var category = itemType.GetCategory();
            bool isWeapon = category == ItemCategory.Firearm;

            Timing.CallDelayed(0.1f, () =>
            {
                foreach (var item in ev.Player.Items.ToList())
                {
                    if (ScpItems.Contains(item.Type))
                    {
                        ev.Player.RemoveItem(item);
                        continue;
                    }
                    if (isWeapon && item.Type.GetCategory() == ItemCategory.Firearm)
                    {
                        ev.Player.RemoveItem(item);
                        ev.Player.AddItem(cfg.WeaponConvertTo);
                    }
                    else if (!isWeapon && item.Type != ItemType.Medkit && item.Type != cfg.WeaponConvertTo)
                    {
                        ev.Player.RemoveItem(item);
                        ev.Player.AddItem(ItemType.Medkit);
                    }
                }
            });
        }

        private static void OnUsedItem(UsedItemEventArgs ev)
        {
            var cfg = Scp343Plugin.Instance.Config;
            if (!IsScp343(ev.Player)) return;

            if (ev.Item.Type == ItemType.Medkit)
            {
                Timing.CallDelayed(0.2f, () =>
                {
                    ev.Player.AddItem(ItemType.Medkit);
                    ev.Player.ShowHint(cfg.MedkitHint, 2f);
                    ev.Player.SendConsoleMessage(cfg.MedkitHint, "yellow");
                });
            }
        }

        private static void OnChangingRole(Exiled.Events.EventArgs.Player.ChangingRoleEventArgs ev)
        {
            if (Scp343Player != null && ev.Player == Scp343Player && ev.NewRole != RoleTypeId.ClassD)
            {
                Scp343Player = null;
            }
        }

        public static bool IsScp343(Player player) => Scp343Player == player;
    }
}
