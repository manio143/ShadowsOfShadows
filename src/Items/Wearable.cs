using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShadowsOfShadows.Items
{
    public abstract class Wearable :  Item
    {
        public abstract void Equip();
        public abstract void UnEquip();
    }
}
