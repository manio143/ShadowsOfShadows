using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ShadowsOfShadows.Items
{
    [ItemType(ItemType.Potion)]
    public class MagicPotion : TimedConsumable
    {
		[XmlIgnore]
        public int MP { get; private set; }
        public MagicPotion() : base("Magic Potion", "Magic power 3\n", TimeSpan.FromSeconds(10))
        {
            MP = 3;
        }

        public override void Use()
        {
           base.Use();
           Screen.MainConsole.Player.MagicPower += MP;
        }

        public override void EndEffect()
        {
            Screen.MainConsole.Player.MagicPower -= MP;
        }
    }
}
