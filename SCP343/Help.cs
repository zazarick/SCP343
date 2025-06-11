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

            string decorated = Scp343Plugin.Instance.Config.SpawnHint;

            if (player != null)
            {
                player.ShowHint(decorated, 10f);
                player.SendConsoleMessage(decorated, "yellow");
            }

            response = decorated;
            return true;
        }
    }
}
