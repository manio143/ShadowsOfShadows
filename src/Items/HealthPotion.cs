using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShadowsOfShadows.Items
{
    [ItemType(ItemType.Potion)]
    public class HealthPotion : RegenerationConsumable
    {
        public HealthPotion() : base("Health Potion", 10) { }


    }
    
    [ItemType(ItemType.Potion)]
    public class StrongHealthPotion : RegenerationConsumable
    {
        public StrongHealthPotion() : base("Strong Health Potion", 20)
        {
        }
    }
}
