using System;
using ShadowsOfShadows.Physics;

namespace ShadowsOfShadows.Entities
{
	public class Projectile : Entity, IUpdateable
	{
		/* Negative means healing */
		public int Damage { get; }
		public bool IsDead { get; set; }

		public Projectile() : base('*') { }
		public Projectile(int damage, Direction direction) : base(new Renderables.ConsoleRenderable('O'))
		{
			this.Damage = damage;
			this.Transform.Direction = direction;
		}
			
		private void Move()
		{
			this.Transform.Position = this.Transform.Position +	this.Transform.Direction.AsPoint();
		}

		public void Update(TimeSpan deltaTime)
		{
			foreach (var entity in Screen.MainConsole.Entities) 
			{
				if(CollisionBox.CheckCollision (this.Transform, entity.Transform))
				{
					var character = entity as Character;
					if (character != null)
						character.TakeDamage (Damage);
					IsDead = true;
				}
			}

			Move();
		}
	}
}
