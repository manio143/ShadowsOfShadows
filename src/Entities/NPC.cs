using System;
using ShadowsOfShadows.Helpers;
using ShadowsOfShadows.Physics;

namespace ShadowsOfShadows.Entities
{
	public class NPC : Character
	{
		public NPC () : base("NPC", 'N', 0, 1)
		{
			Immortal = true;
		}

		public override void Shoot<T>(Direction direction)
		{
		}
    }
}

