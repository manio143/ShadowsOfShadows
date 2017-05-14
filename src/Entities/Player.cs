using System;
using System.Collections.Generic;
using ShadowsOfShadows.Items;
using ShadowsOfShadows.Helpers;

namespace ShadowsOfShadows.Entities
{
	public class Player : Character
	{
		private int Experience;
		public int Level { get; }

		public Dictionary<Skill, int> Skills { get; }

		public Player(string name) : base(name, 'P')
		{
            this.Experience = 0;
			this.Level = 1;
			this.Skills = new Dictionary<Skill, int>();
		}

		public Player(string name, List<Item> equipment, Dictionary<Skill, int> skills) : base(name, 'P', equipment)
		{
            this.Experience = 0;
			this.Level = 1;
			this.Skills = skills;
		}
    
        public int UnlockingSkillLevel
        {
            get { throw new NotImplementedException(); }
        }
	}
}
