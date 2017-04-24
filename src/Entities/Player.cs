using System;
using System.Collections.Generic;

namespace ShadowsOfShadows.Entities
{
	public enum Skill
	{

	}

	public class Player : Character
	{
		public Dictionary<Skill, int> Skills { get; }

		public Player(string name) : base(name)
		{
			Skills = new Dictionary<Skill, int>();
		}
	}
}
