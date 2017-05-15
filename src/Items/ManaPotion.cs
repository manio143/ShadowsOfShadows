using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShadowsOfShadows.Items
{
    public class ManaPotion : Consumable
    {
        public int AmountOfMana { get; private set; }
        public ManaPotion(String name, int amountOfMana): base(name, "Mana regeneration " + amountOfMana + "\n")
        {
            AmountOfMana = amountOfMana;
        }
        public ManaPotion() : this("Mana Potion", 5)
        {
        }
        public override void Use()
        {
            Screen.MainConsole.Player.Mana = Math.Min(Screen.MainConsole.Player.Mana + AmountOfMana, Screen.MainConsole.Player.MaxMana);
        }
    }
    public class StrongManaPotion : ManaPotion
    {
        public StrongManaPotion() : base("Strong Mana Potion", 10)
        {
        }
    }
}
