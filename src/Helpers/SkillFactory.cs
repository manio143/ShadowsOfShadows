using System;
using System.Collections.Generic;

namespace ShadowsOfShadows.Helpers
{
	/* Is a singleton class */
	public class SkillFactory
	{
		private static SkillFactory instance;

		protected SkillFactory()
		{
			
		}

		public static SkillFactory Instance
		{
			get
			{
				if (instance == null)
					instance = new SkillFactory();
				return instance;
			}
		}

		public Dictionary<Skill, int> GetNewSkillSet(Fraction fraction)
		{
			Dictionary<Skill, int> skills = new Dictionary<Skill, int>();

			foreach (Skill skill in Enum.GetValues(typeof(Skill)))
			{
				skills[skill] = 1;
			}

			switch (fraction)
			{
				case Fraction.Warrior:
					skills[Skill.Strength] += 2;
					break;
				case Fraction.Mage:
					skills[Skill.Mana] += 1;
					skills[Skill.MagicPower] += 2;
					break;
				case Fraction.Hunter:
					skills[Skill.ShootingPower] += 2;
					break;
			}

			return skills;
		}
	}
}
