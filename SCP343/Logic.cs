using Exiled.API.Enums;
using Exiled.API.Extensions;
using Exiled.API.Features;
using Exiled.API.Features.Items;
using Exiled.Events.EventArgs.Player;
using MEC;
using PlayerRoles;
using System.Collections.Generic;
using System.Linq;

namespace Scp343
{
    public static class Scp343Logic
    {
        public static Player Scp343Player { get; private set; } = null;

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
                var players = Player.List.Where(p => p.Role == cfg.SpawnRole && p.IsAlive).ToList();
                if (players.Count < cfg.MinPlayers)
                    return;

                if (UnityEngine.Random.value > cfg.SpawnChance)
                    return;

                var chosen = players[UnityEngine.Random.Range(0, players.Count)];
                MakeScp343(chosen);
            });
        }

        public static void MakeScp343(Player player)
        {
            var cfg = Scp343Plugin.Instance.Config;
            Scp343Player = player;
            player.CustomInfo = "scp343";
            player.ClearInventory();

            for (int i = 0; i < cfg.MedkitCount; i++)
                player.AddItem(ItemType.Medkit);

            player.IsBypassModeEnabled = cfg.EnableBypass;
            player.IsGodModeEnabled = cfg.EnableGodMode;

            string hint = cfg.SpawnHint;
            player.ShowHint(hint, 10f);
            player.SendConsoleMessage(hint, "ё");
        }

        private static void OnPickingUpItem(PickingUpItemEventArgs ev)
        {
            var cfg = Scp343Plugin.Instance.Config;

            if (Scp343Player == null || ev.Player != Scp343Player)
                return;

            var itemType = ev.Pickup.Type;
            var category = itemType.GetCategory();
            bool isWeapon = category == ItemCategory.Firearm;

            Timing.CallDelayed(0.1f, () =>
            {
                foreach (var item in ev.Player.Items.ToList())
                {
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
            if (IsScp343(ev.Player) && ev.Item.Type == ItemType.Medkit)
            {
                MEC.Timing.CallDelayed(0.2f, () =>
                {
                    ev.Player.AddItem(ItemType.Medkit);
                    ev.Player.ShowHint("<color=#FFD700>Ты всегда получаешь новую аптечку!</color>", 2f);
                    ev.Player.SendConsoleMessage("<color=#FFD700>Ты всегда получаешь новую аптечку!</color>", "ё");
                });
            }
        }

        private static void OnChangingRole(Exiled.Events.EventArgs.Player.ChangingRoleEventArgs ev)
        {
            if (Scp343Player != null && ev.Player == Scp343Player && ev.NewRole != Scp343Plugin.Instance.Config.SpawnRole)
            {
                Scp343Player = null;
            }
        }

        public static bool IsScp343(Player player) => Scp343Player == player;
    }
}
