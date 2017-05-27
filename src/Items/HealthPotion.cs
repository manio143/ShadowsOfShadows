using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShadowsOfShadows.Items
{
    public class HealthPotion : RegenerationConsumable
    {
        public HealthPotion() : base("Health Potion", 10) { }


        public class StrongHealthPotion : RegenerationConsumable
        {
            public StrongHealthPotion() : base("Strong Health Potion", 20)
            {
            }
        }
    }
}
