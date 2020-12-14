using Exiled.API.Features;
using System.Linq;

namespace CassieAdvancedSettings
{
    public static class CassieFormatter
    {
        public static string Format(string format)
        {
            return format.Replace("{scpsleft}", Player.Get(Team.SCP).Count().ToString());
        }
    }
}
