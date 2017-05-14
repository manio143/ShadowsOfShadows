using System;

namespace ShadowsOfShadows.Entities
{
	public class Monster : Character
	{
		private int Experience;

		public Monster () : base("Monster", 'M')
		{
			this.Experience = 0;
		}
	}
}

