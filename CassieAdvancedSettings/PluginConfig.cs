using Exiled.API.Interfaces;
using System.Collections.Generic;
using System.ComponentModel;

namespace CassieAdvancedSettings
{
    public class PluginConfig : IConfig
    {
        [Description("Should plugin be enabled.")]
        public bool IsEnabled { get; set; } = false;
        [Description("Custom cassies.")]
        public List<CassieInfo> Cassies { get; set; } = new List<CassieInfo>();
    }
}
