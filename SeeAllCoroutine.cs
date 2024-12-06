using CommandSystem;
using MEC;
using System;

namespace ManualCoroutine
{
    [CommandHandler(typeof(GameConsoleCommandHandler))]
    [CommandHandler(typeof(RemoteAdminCommandHandler))]
    public class SeeAllCoroutine : ICommand
    {
        public string Command => "seecoroutine";

        public string[] Aliases => Array.Empty<string>();

        public string Description => "GETS ALL COROUTINES";

        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            try
            {
                // Timing.CurrentCoroutine
                if (Patch.coroutines.Count == 0)
                {
                    response = "None to see";
                    return true;
                }
                response = "LIST: \n";
                //(CoroutineHandle handler, int id) = Patch.coroutines.FirstOrDefault();
                foreach (var coroutine in Patch.coroutines)
                {
                   
                    response += $"ID: {coroutine.id} " + Timing.GetDebugName(coroutine.handler)+"\n";
                }
                return true;
            }
            catch (Exception e)
            {
                response = e.ToString();
                return false;
            }
        }
    }
}
