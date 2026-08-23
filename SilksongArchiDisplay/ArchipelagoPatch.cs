using Archipelago.MultiClient.Net.Models;
using HarmonyLib;
using SilksongRandomizer;
using Archi = SilksongRandomizer.Archipelago;

namespace SilksongArchiDisplay;

[HarmonyPatch]
public class ArchipelagoPatch
{
    [HarmonyPatch(typeof(Archi), MethodType.Constructor)]
    [HarmonyPatch([typeof(string)])]
    [HarmonyPostfix]
    public static void CtorPatch(Archi __instance)
    {
        __instance.OnItemSent += (item, _) =>
        {
            SilksongArchiDisplayPlugin.Add.Invoke(null, [RandomizerPlugin.Instance.FillerIcon, $"{item.Split(" to ")[0]}\nto {item.Split(" to ")[1]}", null]);
        };
    }
    
    [HarmonyPatch(typeof(Archi), nameof(Archi.MarkItemUnlocked)), HarmonyPrefix]
    public static void MarkItemUnlocked(Archi __instance, ItemInfo item, bool raiseEvent)
    {
        string name = item.Player.Name == "Server" ? "Start" : item.Player.Name;
        if (raiseEvent)
            SilksongArchiDisplayPlugin.Add.Invoke(null, [RandomizerPlugin.Instance.MapCheckIcon,$"{__instance.GetItemName(item)}\nfrom {name}", null]);
    }
}