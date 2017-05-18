using System;
using System.Collections.Generic;
using ShadowsOfShadows.Items;
using ShadowsOfShadows.Helpers;
using ShadowsOfShadows.Physics;
using System.Xml.Serialization;

namespace ShadowsOfShadows.Entities
{
	public class Player : Character
	{
		private Fraction Fraction;

		private int Experience;
		public int Level { get; }

        [XmlIgnore]
        public Dictionary<Skill, int> Skills { get; }

        /* For serialization */
        public Player() : base("", 'P', 1, 1)
        {

        }

        public Player(string name, Fraction fraction, int speed) : base(name, 'P', speed, 1)
		{
			this.Fraction = fraction;
            this.Experience = 0;
			this.Level = 1;
			this.Skills = SkillFactory.GetNewSkillSet(fraction);
		}

		public Player(string name, Fraction fraction, int speed, List<Item> equipment, Dictionary<Skill, int> skills
		              ) : base(name, 'P', speed, 1, equipment)
		{
            this.Fraction = fraction;
            this.Experience = 0;
			this.Level = 1;
			this.Skills = skills;
		}

		public int UnlockingSkillLevel => Skills[Skill.Lockpicking];

		public override void Shoot<T>(Direction direction)
		{
			T projectile = (T)new Projectile(Skills[Skill.ShootingPower], direction);
		}

        public override char GetEntityChar()
        {
            return 'P';
        }
    }
}
