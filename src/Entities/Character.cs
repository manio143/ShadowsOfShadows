using System;

namespace ShadowsOfShadows
{
	public class Character : Entity, IInteractable, IUpdateable
	{
		public Character ()
		{
		}

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

