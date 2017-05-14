using System;

namespace ShadowsOfShadows.Entities
{
	public class Projectile : Entity, IUpdateable
	{
		/* Negative means healing */
		public int Damage { get; } 

		public Projectile(int Damage) : base(new Renderables.ConsoleRenderable('O'))
		{
			this.Damage = Damage;
		}

		public void Update(TimeSpan deltaTime)
		{

		}
	}
}
