using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShadowsOfShadows.Items
{
    public abstract class TimedConsumable : Consumable
    {
        public System.TimeSpan Duration { get; set; }
        public bool Active { get; set; }

		public TimedConsumable() : base() { }

		public TimedConsumable(string name) : base(name) { }

        public TimedConsumable(String name, String stats, System.TimeSpan duration) : base(name, "Duration " + duration.TotalSeconds + ",\n" + stats)
        {
            Duration = duration;
            Active = false;
        } 

        public override void Use()
        {
            Active = true;
            Screen.MainConsole.Player.ActiveBuffs.Add(this);
        }

        public void Update(System.TimeSpan delta)
        {
            if (!Active) return;

            if(delta >= Duration)
            {
                Duration = System.TimeSpan.Zero;
                Active = false;
                EndEffect();
            } 
            else
            {
                Duration -= delta;
            }
        }

        public abstract void EndEffect();
    }
}
