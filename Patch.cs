using Exiled.API.Features;
using HarmonyLib;
using MEC;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace ManualCoroutine
{
    [HarmonyPatch]
    public static class Patch
    {
        static int Id = 0;
        public static List<(CoroutineHandle handler, int id)> coroutines = new List<(CoroutineHandle handler, int id)>();

        [HarmonyPostfix]
        [HarmonyPatch(typeof(Timing), nameof(Timing.RunCoroutine), new Type[] { typeof(IEnumerator<float>)})] // Specify parameter types
        public static void GetCoroutineStarted(ref CoroutineHandle __result)
        {
            coroutines.Add((__result, Id++));
            StackTrace trace = new StackTrace();
            Log.Warn(trace.ToString());
        }

    }
}
