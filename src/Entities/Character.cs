using System;
using System.Collections.Generic;
using ShadowsOfShadows.Items;
using ShadowsOfShadows.Helpers;
using ShadowsOfShadows.Physics;

namespace ShadowsOfShadows.Entities
{
	public abstract class Character : Entity, IInteractable, IUpdateable
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

		public abstract void Shoot<T>(Direction direction) where T : Projectile;
    
        public double Health { get; set; }

		public double AttackPower { get; set; }

		public double DefencePower { get; set; }

		public double Mana { get; set; }

		public bool Immortal { get; set; }

		public double MagicPower { get; set; }

		public void Attack(Character character)
		{
			this.Health -= character.DefencePower;
			character.Health -= this.AttackPower;
		}
	}
}
