using Exiled.API.Interfaces;
using PlayerRoles;
using System.Collections.Generic;
using System.ComponentModel;

namespace Scp343
{
    public class Scp343Config : IConfig
    {
        [Description("Включить ли плагин?")]
        public bool IsEnabled { get; set; } = true;

        [Description("Включить режим отладки?")]
        public bool Debug { get; set; } = false;

        [Description("Минимальное количество игроков на сервере для появления SCP-343.")]
        public int MinPlayers { get; set; } = 1;

        [Description("Шанс появления SCP-343 (0.0 - 1.0).")]
        public float SpawnChance { get; set; } = 1.0f;

        [Description("Включить автоспавн SCP-343 в начале раунда?")]
        public bool EnableAutoSpawn { get; set; } = true;

        [Description("Количество аптечек при спавне SCP-343.")]
        public int MedkitCount { get; set; } = 8;

        [Description("Выдавать ли обход режиму (noclip) SCP-343?")]
        public bool EnableBypass { get; set; } = true;

        [Description("Выдавать ли SCP-343 бессмертие?")]
        public bool EnableGodMode { get; set; } = true;

        [Description("В какое оружие конвертировать поднятое оружие?")]
        public ItemType WeaponConvertTo { get; set; } = ItemType.GunCOM15;

        [Description("Текст хинта при спавне SCP-343.")]
        public string SpawnHint { get; set; } =
    "<b><color=white>Сбегите из комплекса.</color>\n" +
    "<color=#00FF00>Объединитесь с Повстанцами Хаоса.</color>\n" +
    "<color=white>Избегайте других выживших, а также <color=red>объектов SCP.</color></color></b>\n\n" +
    "<color=#00BFFF>Ты получаешь 8 аптечек, BYPASS и GODMODE при спавне.</color>\n" +
    "<color=yellow>CustomInfo: SCP343</color>";

        [Description("Текст хинта при получении новой аптечки.")]
        public string MedkitHint { get; set; } =
            "<color=#FFD700>Ты всегда получаешь новую аптечку!</color>";

        [Description("Текст хинта при попытке поднять SCP-предмет или МикроХИД.")]
        public string ScpItemBlockHint { get; set; } =
            "<color=red>SCP-343 не может поднимать SCP-предметы и МикроХИД!</color>";
    }
}
