using System;
using System.Collections.Generic;

namespace ShadowsOfShadows.Helpers
{
    public static class SkillFactory
    {
        public static Dictionary<Skill, int> GetNewSkillSet(Fraction fraction)
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
