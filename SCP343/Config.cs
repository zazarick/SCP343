using System.ComponentModel;
using Exiled.API.Interfaces;
using PlayerRoles;
using Exiled.API.Features.Items;

namespace Scp343
{
    public class Scp343Config : IConfig
    {
        [Description("Включён ли плагин SCP-343?")]
        public bool IsEnabled { get; set; } = true;

        [Description("Включить отладочное логирование?")]
        public bool Debug { get; set; } = false;

        [Description("Автоматически выбирать SCP-343 при старте раунда")]
        public bool EnableAutoSpawn { get; set; } = true;

        [Description("Роль, из которой выбирается SCP-343")]
        public RoleTypeId SpawnRole { get; set; } = RoleTypeId.ClassD;

        [Description("Шанс спавна SCP-343 (0.0 - 1.0)")]
        public float SpawnChance { get; set; } = 1.0f;

        [Description("Минимальное количество игроков для спавна SCP-343")]
        public int MinPlayers { get; set; } = 1;

        [Description("Количество аптечек, выдаваемых при спавне")]
        public int MedkitCount { get; set; } = 8;

        [Description("Включить bypass для SCP-343")]
        public bool EnableBypass { get; set; } = true;

        [Description("Включить godmode для SCP-343")]
        public bool EnableGodMode { get; set; } = true;

        [Description("Во что превращать оружие (по умолчанию SCP500)")]
        public ItemType WeaponConvertTo { get; set; } = ItemType.SCP500;

        [Description("Сообщение при спавне SCP-343")]
        public string SpawnHint { get; set; } =
            "<color=yellow><b>SCP-343 (БОГ)</b></color>\n" +
            "<color=grey>Все предметы, которые ты подбираешь, становятся аптечками.</color>\n" +
            "<color=grey>Всё оружие превращается в SCP-500.</color>\n" +
            "<color=#00bfff>Ты получаешь 8 аптечек, bypass и godmode при спавне.</color>\n" +
            "<color=yellow>CustomInfo: scp343</color>";
    }
}
