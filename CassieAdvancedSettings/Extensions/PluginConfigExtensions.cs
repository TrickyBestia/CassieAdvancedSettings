using System.Linq;

namespace CassieAdvancedSettings.Extensions
{
    public static class PluginConfigExtensions
    {
        public static CassieInfo GetScpDeathCassie(this PluginConfig config, RoleType scp)
        {
            return config.Cassies.FirstOrDefault(cassie => cassie.Trigger == $"On{scp}Death");
        }
    }
}
