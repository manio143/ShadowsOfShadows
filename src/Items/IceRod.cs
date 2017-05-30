using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShadowsOfShadows.Items
{
    public class IceRod : Weapon
    {
		public IceRod() : base("Ice Rod") { }

        public IceRod(int ap, int mp) : base("Ice Rod", ap, mp) { }

        public override void Equip()
        {
            base.Equip();
            // Add ice shot skill TODO:
        }

        public override void UnEquip()
        {
            base.UnEquip();
            // Delete skill TODO:
        }
    }
}
