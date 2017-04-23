using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShadowsOfShadows.Items
{
    public class Bow : Weapon
    {
        public Bow(int ap, int mp) : base(ap, mp)
        {
        }

        public override void Equip()
        {
            base.Equip();
            // Add archery skill TODO:
        }

        public override void UnEquip()
        {
            base.UnEquip();
            // Delete skill TODO:
        }
    }
}
