using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ShadowsOfShadows.Items
{
    public class StrengthPotion : TimedConsumable
    {
		[XmlIgnore]
        public int AP { get; private set; }

		public StrengthPotion() : base("Strength Potion") { }

        public StrengthPotion(TimeSpan duration) : base("Strength Potion", "Attack power 3\n", duration)
        {
            AP = 3;
        }
        public override void Use()
        {
            base.Use();
            Screen.MainConsole.Player.AttackPower += AP;
        }

        public override void EndEffect()
        {
            Screen.MainConsole.Player.AttackPower -= AP;
        }

    }
}
