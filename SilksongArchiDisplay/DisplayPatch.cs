using System.Reflection;
using HarmonyLib;
using RecentItemsDisplay;

namespace SilksongArchiDisplay;

[HarmonyPatch]
public class DisplayPatch
{
    [HarmonyPatch(typeof(Display), nameof(Display.AddItem))]
    [HarmonyPrefix]
    public static bool AddItem()
    {
        if (Assembly.GetExecutingAssembly() != typeof(DisplayPatch).Assembly) return false;
        return true;
    }
}