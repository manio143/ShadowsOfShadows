using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShadowsOfShadows.Items
{
    public class HealthPotion : RegenerationConsumable
    {
        public HealthPotion(int regen) : base(regen)
        {
        }


        public class StrongHealthPotion : RegenerationConsumable
        {
            public StrongHealthPotion(int regen) : base(regen)
            {
            }
        }
    }
}
