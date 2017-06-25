using System;
using ShadowsOfShadows.Physics;

namespace ShadowsOfShadows.Entities
{
    public class Monster : Character
    {
        private int Experience;

        public Monster() : this(0, 0) { }

        public Monster(int speed, int velocity) : base("Monster", 'M', speed, velocity)
        {
            Experience = 0;

            Random random = new Random();

            this.Health = this.MaxHealth = random.Next(1, 7);
            this.AttackPower = random.Next(1, 3);
            this.DefencePower = random.Next(0, 1);

            this.Mana = this.MaxMana = random.Next(1, 2);

            this.Immortal = false;
            this.MagicPower = random.Next(1, 2);
        }

        public override void Shoot<T>(Direction direction)
        {
            T projectile = (T)new Projectile(1, direction);
        }
    }
}

