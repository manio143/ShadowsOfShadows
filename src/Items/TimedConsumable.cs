using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShadowsOfShadows.Items
{
    public abstract class TimedConsumable : Consumable
    {
        public System.TimeSpan Duration { get; private set; }
        public bool Active { get; private set; }

        public TimedConsumable(System.TimeSpan duration)
        {
            Duration = duration;
            Active = false;
        } 

        public override void Use()
        {
            Active = true;
        }

        public void Update(System.TimeSpan delta)
        {
            if (!Active) return;

            if(delta > Duration)
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
