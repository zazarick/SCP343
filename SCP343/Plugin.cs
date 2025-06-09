using Exiled.API.Features;
using System;

namespace Scp343
{
    public class Scp343Plugin : Plugin<Scp343Config>
    {
        public override string Name => "SCP-343";
        public override string Author => "zazarick";
        public override Version Version => new Version(1, 2, 0);
        public override string Prefix => "scp343";
        public static Scp343Plugin Instance;

        public override void OnEnabled()
        {
            Instance = this;
            Scp343Logic.RegisterEvents();
            base.OnEnabled();
        }

        public override void OnDisabled()
        {
            Scp343Logic.UnregisterEvents();
            Instance = null;
            base.OnDisabled();
        }
    }
}