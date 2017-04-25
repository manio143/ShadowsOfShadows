using System;
using System.Collections.Generic;
using ShadowsOfShadows.Items;

namespace ShadowsOfShadows.Entities
{
	public enum Skill
	{

	}

	public class Player : Character
	{
		public int Level { get; }

		public Dictionary<Skill, int> Skills { get; }

		public Player(string name) : base(name)
		{
			this.Level = 1;
			this.Skills = new Dictionary<Skill, int>();
		}

		public Player(string name, List<Item> equipment, Dictionary<Skill, int> skills) : base(name, equipment)
		{
			this.Level = 1;
			this.Skills = skills;
		}
    
        public int UnlockingSkillLevel
        {
            get { throw new NotImplementedException(); }
        }
	}
}
