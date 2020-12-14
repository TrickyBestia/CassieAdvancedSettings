using Exiled.API.Enums;
using Exiled.API.Features;
using System;
using Handlers = Exiled.Events.Handlers;
using CassieAdvancedSettings.Extensions;
using Exiled.Events.EventArgs;
using System.Linq;

namespace CassieAdvancedSettings
{
    class Plugin : Plugin<PluginConfig>
    {
        public override string Author { get; } = "TrickyBestia";
        public override string Name { get; } = "CassieAdvancedSettings";
        public override string Prefix { get; } = "CassieAdvancedSettings";
        public override Version RequiredExiledVersion { get; } = new Version(2, 1, 19);
        public override PluginPriority Priority { get; } = PluginPriority.Default;
        public override Version Version => Assembly.GetName().Version;

        public override void OnEnabled()
        {
            Handlers.Map.AnnouncingScpTermination += OnAnnouncingScpTermination;
            Handlers.Map.AnnouncingNtfEntrance += OnAnnouncingNtfEntrance;

            base.OnEnabled();
        }
        private void OnAnnouncingScpTermination(AnnouncingScpTerminationEventArgs ev)
        {
            string damageType = ev.TerminationCause;
            if (ev.Killer != null)
                damageType = ev.Killer.Team.ToFriendlyString(ev.Killer.ReferenceHub.characterClassManager);
            var cassie = Config.GetScpDeathCassie(ev.Role.roleId);
            if (cassie != null)
            {
                ev.IsAllowed = false;
                var cassieMessage = cassie.Value.Replace("{damagetype}", damageType);
                Cassie.GlitchyMessage(CassieFormatter.Format(cassieMessage), cassie.GlitchChance, cassie.JamChance);
            }
        }
        private void OnAnnouncingNtfEntrance(AnnouncingNtfEntranceEventArgs ev)
        {
            var cassie = Config.Cassies.FirstOrDefault(info => info.Trigger == "OnNtfArrived");
            if (cassie != null)
            {
                ev.IsAllowed = false;
                var cassieMessage = cassie.Value.Replace("{mtf}", $"NATO_{ev.UnitName[0]} {ev.UnitNumber}");
                Cassie.GlitchyMessage(CassieFormatter.Format(cassieMessage), cassie.GlitchChance, cassie.JamChance);
            }
        }
    }
}
