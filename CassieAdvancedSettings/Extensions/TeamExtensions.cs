using Respawning;
using Respawning.NamingRules;

namespace CassieAdvancedSettings.Extensions
{
    public static class ReferenceHubExtensions
    {
        /// <param name="characterClassManager">Can be null, if team is not MTF</param>
        public static string ToFriendlyString(this Team team, CharacterClassManager characterClassManager = null)
        {
            switch (team)
            {
                case Team.SCP:
                    return "SCP " + characterClassManager.CurRole.fullName;
                case Team.MTF:
                    UnitNamingRule rule;
                    return UnitNamingRules.TryGetNamingRule(SpawnableTeamType.NineTailedFox, out rule) ? rule.GetCassieUnitName(characterClassManager.CurUnitName) : "UNKNOWN";
                case Team.RSC:
                    return "SCIENCE PERSONNEL";
                case Team.CHI:
                    return "CHAOSINSURGENCY";
                case Team.CDP:
                    return "CLASSD PERSONNEL";
                case Team.TUT:
                    return "BAN TEAM";
                default:
                    return "CONTAINMENTUNIT UNKNOWN";
            }
        }
    }
}
