using CommandSystem;
using Exiled.API.Features;
using MEC;
using System;
using System.Collections.Generic;

namespace ManualCoroutine
{
    [CommandHandler(typeof(GameConsoleCommandHandler))]
    [CommandHandler(typeof(RemoteAdminCommandHandler))]
    public class StartDummyCoroutine : ICommand
    {
        public string Command => "startcoroutine";

        public string[] Aliases => Array.Empty<string>();

        public string Description => "STARTS DUMMY COROUTINES";

        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {

            Player ply = Player.Get(sender);
            if (ply is null)
            {
                Timing.RunCoroutine(DummyCoroutine());
            }
            else
            {
                Timing.RunCoroutine(DummyCoroutine(ply));
            }

            response = "COROUTINE STARTED";
            return true;
        }

        private IEnumerator<float> DummyCoroutine()
        {

            yield return Timing.WaitForSeconds(60);
        }

        private IEnumerator<float> DummyCoroutine(Player ply)
        {
            ply.ShowHint("Hello");
            yield return Timing.WaitForSeconds(60);
        }
    }
}