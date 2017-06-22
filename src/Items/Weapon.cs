using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShadowsOfShadows.Items
{
    [ItemType(ItemType.Weapon)]
    public abstract class Weapon : Wearable
    {
        public int AP { get; set; }
        public int MP { get; set; }

        protected Weapon() : base() { }

        protected Weapon(String name) : base(name) { }

        protected Weapon(String name, int ap, int mp) : base(name, "Attack power " + ap + ",\n" + "Magic power " + mp + "\n")
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
