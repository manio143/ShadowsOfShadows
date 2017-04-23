using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShadowsOfShadows.Items
{
    public class Weapon : Wearable
    {
        public int AP { get; private set; }
        public int MP { get; private set; }

        public Weapon(int ap, int mp)
        {
            AP = ap;
            MP = mp;
        }

        public override void Equip()
        {
            // unequip previous
            // Screen.player.AttackPower += AP; TODO:
            // Screen.player.MagicPower += MP; TODO:
        }

        public override void UnEquip()
        {
            // Screen.player.AttackPower -= AP; TODO:
            // Screen.player.MagicPower -= MP; TODO:
        }
    }
}
