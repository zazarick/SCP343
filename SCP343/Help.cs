using CommandSystem;
using Exiled.API.Features;
using System;

namespace Scp343
{
    [CommandHandler(typeof(GameConsoleCommandHandler))]
    [CommandHandler(typeof(ClientCommandHandler))]
    public class Scp343HelpCommand : ICommand
    {
        public string Command => "scp343help";
        public string[] Aliases => Array.Empty<string>();
        public string Description => "Справка по SCP-343 (Бог)";

        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            Player player = Player.Get(sender);

            string decorated =
                "<color=yellow><b>╔═════════════════════════════════════════════════╗\n" +
                "           Ты — <color=#FFD700>SCP-343 (БОГ)</color>!\n\n" +
                "   <b>—</b> Все предметы, которые ты берёшь, <color=#00ff00>становятся аптечками</color>.\n" +
                "   <b>—</b> Всё оружие, которое ты берёшь, <color=#ff6666>превращается в SCP-500</color>.\n" +
                "   <b>—</b> При спавне ты получаешь <color=#00bfff>8 аптечек</color>, <color=#FFA500>bypass</color> и <color=#FFA500>godmode</color>.\n" +
                "   <b>—</b> CustomInfo: <color=#FFD700>scp343</color>\n\n" +
                "   <b>—</b> Команда <color=#00ffff>.scp343help</color> — показать эту справку\n" +
                "╚═════════════════════════════════════════════════╝</b></color>";

            if (player != null)
            {
                player.ShowHint(decorated, 10f);
                player.SendConsoleMessage(decorated, "ё");
            }

            response = decorated;
            return true;
        }
    }
}