using System.Collections.Generic;
using ShadowsOfShadows.Renderables;
using ShadowsOfShadows.Items;

namespace ShadowsOfShadows.Entities
{
    public class TrapChest : Chest
    {
        int Damage { get; set; }
        bool Active { get; set; }

		public TrapChest() : base() { }

        public TrapChest(IRenderable rendarable, int lockDificulty, List<Item> items, int damage) : base(rendarable,
            lockDificulty, items)
        {
            Damage = damage;
            Active = true;
        }

        public override void Interact()
        {
            if (Active)
            {
                Active = false;
                Screen.MainConsole.Player.TakeDamage(Damage);
                Screen.MessageConsole.PrintMessage("It's a trap!");
            }

            base.Interact();
        }
    }
}