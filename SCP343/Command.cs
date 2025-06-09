using CommandSystem;
using Exiled.API.Features;
using System;

namespace Scp343
{
    [CommandHandler(typeof(RemoteAdminCommandHandler))]
    [CommandHandler(typeof(GameConsoleCommandHandler))]
    public class Scp343Command : ICommand
    {
        public string Command => "scp343spawn";
        public string[] Aliases => Array.Empty<string>();
        public string Description => "Превратить игрока в SCP-343 (по ID или нику)";

        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            if (arguments.Count < 1)
            {
                response = "Использование: scp343spawn <playerId/ник>";
                return false;
            }

            Player target = null;
            string targetArg = arguments.At(0);

            if (ushort.TryParse(targetArg, out ushort id))
                target = Player.Get(id);

            if (target == null)
                target = Player.Get(targetArg);

            if (target == null)
            {
                response = $"Игрок с ID или ником '{targetArg}' не найден!";
                return false;
            }

            Scp343Logic.MakeScp343(target);
            response = $"Игрок {target.Nickname} теперь SCP-343!";
            return true;
        }
    }
}