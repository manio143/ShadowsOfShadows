using System;
using System.Collections.Generic;
using ShadowsOfShadows.Items;
using ShadowsOfShadows.Helpers;
using ShadowsOfShadows.Physics;

namespace ShadowsOfShadows.Entities
{
	public class Player : Character
	{
		private Fraction Fraction;

		private int Experience;
		public int Level { get; }

		public Dictionary<Skill, int> Skills { get; }

		public Player(string name, Fraction fraction) : base(name, 'P')
		{
			this.Fraction = fraction;
            this.Experience = 0;
			this.Level = 1;
			this.Skills = new Dictionary<Skill, int>();
		}

		public Player(string name, List<Item> equipment, Dictionary<Skill, int> skills, 
		              Fraction fraction) : base(name, 'P', equipment)
		{
            this.Fraction = fraction;
            this.Experience = 0;
			this.Level = 1;
			this.Skills = skills;
		}
    
        public int UnlockingSkillLevel
        {
            get { throw new NotImplementedException(); }
        }

		public override void Shoot<T>(Direction direction)
		{
			T projectile = (T)new Projectile(SkillFactory.Instance.GetNewSkillSet(Fraction)[Skill.ShootingPower],
			                                 direction);
		}
	}
}
