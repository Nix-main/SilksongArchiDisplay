using System.Reflection;
using HarmonyLib;
using UnityEngine;

namespace SilksongArchiDisplay;

[HarmonyPatch]
public class DisplayPatch
{
    static MethodBase TargetMethod()
    {
        return SilksongArchiDisplayPlugin.Add;
    }

    static bool Prefix()
    {
        if (Assembly.GetExecutingAssembly() != typeof(DisplayPatch).Assembly) return false;
        return true;
    }
}