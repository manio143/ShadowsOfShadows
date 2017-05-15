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

		public bool IsMoving { get; set; }

		private int Speed;
		public int CurrentSpeed { get; set; }
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
			if (IsMoving == false)
				return;
			
			switch (Transform.Direction)
			{
				case Direction.Right:
					Transform.Position = new Point(Transform.Position.X + Velocity, Transform.Position.Y);
					break;
				case Direction.Left:
					Transform.Position = new Point(Transform.Position.X - Velocity, Transform.Position.Y);
					break;
				case Direction.Up:
					Transform.Position = new Point(Transform.Position.X, Transform.Position.Y - Velocity);
					break;
				case Direction.Down:
					Transform.Position = new Point(Transform.Position.X, Transform.Position.Y + Velocity);
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
   
    public int Health { get; set; }
    public int MaxHealth { get; set; }

    public int AttackPower { get; set; }

		public int DefencePower { get; set; }

		public int Mana { get; set; }
    public int MaxMana { get; set; }

    public bool Immortal { get; set; }

		public int MagicPower { get; set; }

		public void Attack(Character character)
		{
			this.Health -= character.DefencePower;
			character.Health -= this.AttackPower;
		}

        public void TakeDamage(int amount)
        {
            Health = Math.Max(Health - Math.Min(DefencePower - amount, 0), 0);
        }
	}
}
