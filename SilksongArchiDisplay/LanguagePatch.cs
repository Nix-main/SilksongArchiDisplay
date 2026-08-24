using HarmonyLib;
using TeamCherry.Localization;

namespace SilksongArchiDisplay;

[HarmonyPatch]
public class LanguagePatch
{
    [HarmonyPatch(typeof(Language), nameof(Language.Get), typeof(string), typeof(string))]
    [HarmonyPrefix]
    public static bool GetPatch(string key, ref string __result)
    {
        if (key.Equals("TUTORIAL_CREDIT_NAME_03"))
        {
            __result = "Jasmine Vine";
            return false;
        }

        return true;
    }
}