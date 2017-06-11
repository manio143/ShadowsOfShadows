using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using ShadowsOfShadows.Items;
using ShadowsOfShadows.Physics;
using ShadowsOfShadows.Renderables;
using System.Linq;
using System.Threading;
using ShadowsOfShadows.Consoles;

namespace ShadowsOfShadows.Entities
{
    public abstract class Character : Entity, IInteractable, IUpdateable
    {
        public string Name { get; set; }

        private static MathNet.Numerics.Distributions.Normal rnd = new MathNet.Numerics.Distributions.Normal(0.7, 0.15);

        public bool IsMoving { get; set; }
		public bool IsAttacking { get; set; }

        public int Speed { get; set; }
        public int CurrentSpeed { get; set; }
        public int Velocity { get; set; }

        public List<Item> Equipment { get; set; }

        public Character() { }

        public Character(char c) : base(c) { }

        protected Character(string name, char renderChar, int speed, int velocity) : base(
            new ConsoleRenderable(renderChar))
        {
            Name = name;
            Speed = speed;
            CurrentSpeed = speed;
            Velocity = velocity;
            Equipment = new List<Item>();
        }

        protected Character(string name, char renderChar, int speed, int velocity, List<Item> equipment)
            : this(name, renderChar, speed, velocity)
        {
            Equipment = equipment;
        }


        public void Interact()
        {
        }

		private void Attack()
		{
			if (!IsAttacking)
				return;

			var entity = Screen.MainConsole.Entities.FirstOrDefault(e => e.Transform.Position ==
				Transform.Position +
				Transform.Direction.AsPoint());
			var enemy = entity as Character;
			if (enemy != null)
				Attack (enemy);
		}

        private void Move()
        {
            if (IsMoving == false)
                return;

            var entity = Screen.MainConsole.Entities.FirstOrDefault(e => e.Transform.Position ==
                                                                   Transform.Position +
                                                                   Transform.Direction.AsPoint());
            
            Point lastPosition = Transform.Position;            
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

            if (entity != null && CollisionBox.CheckCollision(Transform, entity.Transform))
                Transform.Position = lastPosition;
        }

        public virtual void Update(TimeSpan deltaTime)
        {
            CurrentSpeed--;
            if (CurrentSpeed == 0)
            {
                CurrentSpeed = Speed;
                Move();
				Attack();
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
            int previousHP = character.Health;
            double sample = rnd.Sample();
            character.TakeDamage((int)(AttackPower * sample));
            Screen.MessageConsole.PrintMessageWithTimeout(
                Name + " dealt " + (previousHP - character.Health) + " damage to " + character.Name,
                TimeoutMessage.SHORT_TIMEOUT);
        }

        public void TakeDamage(int amount)
        {
            Health = Math.Max(Health - Math.Max(amount - DefencePower, 0), 0);
        }
    }
}
