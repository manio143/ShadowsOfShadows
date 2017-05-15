using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using ShadowsOfShadows.Items;
using ShadowsOfShadows.Physics;
using ShadowsOfShadows.Renderables;

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
            Health -= character.DefencePower;
            character.Health -= AttackPower;
        }

        public void TakeDamage(int amount)
        {
            Health = Math.Max(Health - Math.Min(DefencePower - amount, 0), 0);
        }
    }
}
