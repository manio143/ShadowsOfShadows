using System;
using ShadowsOfShadows.Physics;

namespace ShadowsOfShadows.Entities
{
	public class Projectile : Entity, IUpdateable
	{
		/* Negative means healing */
		public int Damage { get; }

		public Projectile(int damage, Direction direction) : base(new Renderables.ConsoleRenderable('O'))
		{
			this.Damage = damage;
			this.Transform.Direction = direction;
		}

		public void Update(TimeSpan deltaTime)
		{

		}
        public override char GetEntityChar()
        {
            return 'O';
        }
    }
}
