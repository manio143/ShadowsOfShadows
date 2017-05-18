using System;
using ShadowsOfShadows.Physics;

namespace ShadowsOfShadows.Entities
{
	public class Monster : Character
	{
		private int Experience;

		public Monster(int speed, int velocity) : base("Monster", 'M', speed, velocity)
		{
			this.Experience = 0;
		}

		public override void Shoot<T>(Direction direction)
		{
			T projectile = (T)new Projectile(1, direction);
		}

        public override char GetEntityChar()
        {
            return 'M';
        }
    }
}

