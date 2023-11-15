using BepInEx;
using HarmonyLib;
using Reptile;

namespace BRC_Ultrawide
{
    [BepInPlugin("com.MandM.BRC-Ultrawide", "BRC-Ultrawide", "1.0.0")]
    [BepInProcess("Bomb Rush Cyberfunk.exe")]

    public class Plugin : BaseUnityPlugin
    {
        public void Awake()
        {
            Harmony harmony = new Harmony("MandM.BRC-Ultrawide.Harmony");
            harmony.PatchAll();
        }
    }

    [HarmonyPatch(typeof(EffectsUI))]
    public class EffectsUIPatch
    {
        [HarmonyPostfix]
        [HarmonyPatch("ShowVerticalBars")]
        public static void ShowVerticalBars_Postfix(EffectsUI __instance)
        {
            // Immediately hide the vertical bars.
            __instance.HideVerticalBars();
        }
    }
}
