using System;
using ShadowsOfShadows.Helpers;
using ShadowsOfShadows.Physics;

namespace ShadowsOfShadows.Entities
{
	public class NPC : Character
	{
		private Fraction Fraction;

        public NPC() : base('N') { }

		public NPC (Fraction fraction, int speed) : base("NPC", 'N', speed, 1)
		{
			this.Fraction = fraction;
			Immortal = true;
		}

		public override void Shoot<T>(Direction direction)
		{
			T projectile = (T)new Projectile(SkillFactory.GetNewSkillSet(Fraction)[Skill.ShootingPower],
											 direction);
		}
    }
}

