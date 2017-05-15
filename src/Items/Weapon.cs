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

        public Weapon(String name, int ap, int mp) : base(name, "Attack power " + ap +",\n" + "Magic power " + mp + "\n")
        {
            AP = ap;
            MP = mp;
        }

        public override void Equip()
        {
            Screen.MainConsole.Player.AttackPower += AP;
            Screen.MainConsole.Player.MagicPower += MP;
        }

        public override void UnEquip()
        {
            Screen.MainConsole.Player.AttackPower -= AP;
            Screen.MainConsole.Player.MagicPower -= MP;
        }

        public override bool IsLike(Item item)
        {
            return (item is Weapon);
        }
    }
}
