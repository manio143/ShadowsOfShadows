using System;
using Microsoft.Xna.Framework;

using System.Collections.Generic;
using ShadowsOfShadows.Items;
using ShadowsOfShadows.Helpers;
using ShadowsOfShadows.Physics;

namespace ShadowsOfShadows.Entities
{
	public abstract class Character : Entity, IInteractable, IUpdateable
	{
		public string Name { get; }

		private int Speed;
		private int CurrentSpeed;
		public int Velocity { get; set; }

		public List<Item> Equipment { get; }

		public Character(string name, char renderChar, int speed, int velocity) : base(new Renderables.ConsoleRenderable(renderChar))
		{
			this.Name = name;
			this.Speed = speed;
			this.CurrentSpeed = speed;
			this.Velocity = velocity;
			this.Equipment = new List<Item>();
		}

		public Character(string name, char renderChar, int speed, int velocity, List<Item> equipment)
			: this(name, renderChar, speed, velocity)
		{
			this.Equipment = equipment;
		}


		public void Interact()
		{

		}

		private void Move()
		{
			switch (Transform.Direction)
			{
				case Direction.Right:
					Transform.Position = new Point(Transform.Position.X + Velocity, Transform.Position.Y);
					break;
				case Direction.Left:
					Transform.Position = new Point(Transform.Position.X - Velocity, Transform.Position.Y);
					break;
				case Direction.Up:
					Transform.Position = new Point(Transform.Position.X, Transform.Position.Y + Velocity);
					break;
				case Direction.Down:
					Transform.Position = new Point(Transform.Position.X, Transform.Position.Y - Velocity);
					break;

			}
		}

		public void Update(TimeSpan deltaTime)
		{
			CurrentSpeed--;
			if (CurrentSpeed == 0)
			{
				CurrentSpeed = Speed;
				Move();
			}
		}

		public abstract void Shoot<T>(Direction direction) where T : Projectile;
    
        public double Health { get; set; }

		public double AttackPower { get; set; }

		public double DefencePower { get; set; }

		public double Mana { get; set; }

		public bool Immortal { get; set; }

		public double MagicPower { get; set; }

		public void Attack(Character character)
		{
			this.Health -= character.DefencePower;
			character.Health -= this.AttackPower;
		}
	}
}
