using System;
using Exiled.API.Features;
using HarmonyLib;


namespace ManualCoroutine
{
    public class ManualCoroutine : Plugin<Config>
    {
        private Harmony harm;
        public override string Name => "ManualCoroutine";

        public override string Prefix => "manualcoroutine";

        public override string Author => "Antoniofo";

        public override Version Version => new Version(1,0,0);

        public override Version RequiredExiledVersion => new Version(8,14,0);

        public override void OnEnabled()
        {
            harm = new Harmony("manualcoroutinepatch-antoniofo");
            harm.PatchAll();
            base.OnEnabled();
        }

        public override void OnDisabled()
        {
            harm.UnpatchAll();
            base.OnDisabled();
        }
    }
}
