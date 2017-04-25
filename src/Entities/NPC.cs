using System;

namespace ShadowsOfShadows.Entities
{
	public class NPC : Character
	{
		public NPC () : base("NPC", 'N')
		{
			Immortal = true;
		}
	}
}

