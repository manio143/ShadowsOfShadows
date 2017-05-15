using System;
using System.Collections.Generic;
using ShadowsOfShadows.Items;
using ShadowsOfShadows.Helpers;

namespace ShadowsOfShadows.Entities
{
	public class Character : Entity, IInteractable, IUpdateable
	{
		public string Name { get; }

		public List<Item> Equipment { get; }

		public Character(string name, char renderChar) : base(new Renderables.ConsoleRenderable(renderChar))
		{
			this.Name = name;
			this.Equipment = new List<Item>();
		}

		public Character(string name, char renderChar, List<Item> equipment) : this(name, renderChar)
		{
			this.Equipment = equipment;
		}


		public void Interact()
		{

		}

		public void Update(TimeSpan deltaTime)
		{

		}
    
        public int Health { get; set; }
        public int MaxHealth { get; set; }

        public int AttackPower { get; set; }

		public int DefencePower { get; set; }

		public int Mana { get; set; }
        public int MaxMana { get; set; }

        public bool Immortal { get; set; }

		public int MagicPower { get; set; }

		public void Attack(Character character)
		{
			this.Health -= character.DefencePower;
			character.Health -= this.AttackPower;
		}

        public void TakeDamage(int amount)
        {
            Health = Math.Max(Health - Math.Min(DefencePower - amount, 0), 0);
        }
	}
}
