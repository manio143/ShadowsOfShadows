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
        public ManaPotion(int amountOfMana)
        {
            AmountOfMana = amountOfMana;
        }
        public override void Use()
        {
            // Screen.player.Mana = Math.Min(Screen.player.Mana + AmountOfMana, Screen.player.MaxMana);
        }
    }
    public class StrongManaPotion : ManaPotion
    {
        public StrongManaPotion(int amountOfMana) : base(amountOfMana)
        {
        }
    }
}
