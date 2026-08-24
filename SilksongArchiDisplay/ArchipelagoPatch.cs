using Archipelago.MultiClient.Net.Models;
using HarmonyLib;
using RecentItemsDisplay;
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
            Display.AddItem(RandomizerPlugin.Instance.FillerIcon, $"{item.Split(" to ")[0].Replace("_", " ")}\nto {item.Split(" to ")[1]}");
        };
    }
    
    [HarmonyPatch(typeof(Archi), nameof(Archi.MarkItemUnlocked)), HarmonyPrefix]
    public static void MarkItemUnlocked(Archi __instance, ItemInfo item, bool raiseEvent)
    {
        string name = item.Player.Name == "Server" ? "Start" : item.Player.Name;
        if (raiseEvent)
            Display.AddItem(RandomizerPlugin.Instance.MapCheckIcon,$"{__instance.GetItemName(item).Replace("_", " ")}\nfrom {name}");
    }
}