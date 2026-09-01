using System;
using System.Reflection;
using BepInEx;
using BepInEx.Logging;
using HarmonyLib;
using RecentItemsDisplay;
using SilksongRandomizer;
using System.Collections.Concurrent;

namespace SilksongArchiDisplay;


[BepInAutoPlugin("dev.ambershadow.silksongarchidisplay", "Silksong Archi Display", "1.0.0")]
[BepInDependency(RecentItemsDisplayPlugin.Id)]
[BepInDependency(RandomizerPlugin.PluginGuid)]
public partial class SilksongArchiDisplayPlugin : BaseUnityPlugin
{
    // Make a queue to release the items via Update() to avoid releases and large item checks from crashing the game while running or on reconnect.
    private static readonly ConcurrentQueue<(UnityEngine.Sprite sprite, string message)> pendingItemsQueue = new();

    void Awake()
    {
        new Harmony(Id).PatchAll();
        VanillaItems.mgr.Dispose();
        VanillaItems.fsmMgr.Dispose();
    }

    void Update()
    {
        while (pendingItemsQueue.TryDequeue(out var item))
        {
            Display.AddItem(item.sprite, item.message);
        }
    }

    internal static void QueueItem(UnityEngine.Sprite sprite, string message)
    {
        pendingItemsQueue.Enqueue((sprite, message));
    }
}