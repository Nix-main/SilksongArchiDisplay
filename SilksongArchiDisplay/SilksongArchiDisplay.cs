using System;
using System.Reflection;
using BepInEx;
using BepInEx.Logging;
using HarmonyLib;
using RecentItemsDisplay;
using SilksongRandomizer;

namespace SilksongArchiDisplay;


[BepInAutoPlugin("dev.ambershadow.silksongarchidisplay", "Silksong Archi Display", "1.0.0")]
[BepInDependency(RecentItemsDisplayPlugin.Id)]
[BepInDependency(RandomizerPlugin.PluginGuid)]
public partial class SilksongArchiDisplayPlugin : BaseUnityPlugin
{
    void Awake()
    {
        new Harmony(Id).PatchAll();
        VanillaItems.mgr.Dispose();
        VanillaItems.fsmMgr.Dispose();
    }
}