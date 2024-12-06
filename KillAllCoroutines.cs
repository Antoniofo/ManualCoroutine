using CommandSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MEC;

namespace ManualCoroutine
{
    [CommandHandler(typeof(GameConsoleCommandHandler))]
    [CommandHandler(typeof(RemoteAdminCommandHandler))]  
    public class KillAllCoroutines : ICommand
    {
        public string Command => "killallcoroutine";

        public string[] Aliases => Array.Empty<string>();

        public string Description => "KILL ALL COROUTINE";

        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            Timing.KillCoroutines();

            response = "ALL COROUTINE KILLED";
            return true;
        }
    }
}
