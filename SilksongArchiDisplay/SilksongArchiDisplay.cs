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
    public new static ManualLogSource Logger = null!;
    public static Type Display = null!;
    public static MethodInfo Add = null!;
    void Awake()
    {
        Logger = base.Logger;
        Display = typeof(RecentItemsDisplayPlugin).Assembly.GetType("RecentItemsDisplay.Display");
        Add = AccessTools.DeclaredMethod(Display, "AddItem");
        new Harmony(Id).PatchAll();
    }
}