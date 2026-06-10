using System;
using BepInEx;
using BepInEx.Logging;
using Utilla;
using Utilla.Attributes;

namespace betterbuttons.Source
{
    [BepInPlugin(PluginInfo.GUID, PluginInfo.Name, PluginInfo.Version)]
    public class Plugin : BaseUnityPlugin
    {
        public void Start()
        {
            Logger.Log(LogLevel.Info, "BetterButtons v1.0");
        }
    }
}
