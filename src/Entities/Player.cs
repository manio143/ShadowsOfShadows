using System;
using System.Collections.Generic;
using ShadowsOfShadows.Items;
using ShadowsOfShadows.Helpers;
using ShadowsOfShadows.Physics;
using System.Xml.Serialization;
using System.Linq;

namespace ShadowsOfShadows.Entities
{
    public class Player : Character
    {
        private Fraction Fraction;

        private int Experience;

        public int Level { get; set; }

        public List<TimedConsumable> ActiveBuffs { get; set; } = new List<TimedConsumable>();

        public Dictionary<Skill, int> Skills { get; set; }

        /* For serialization */
        public Player() : base('P') { }

        public Player(string name, Fraction fraction, int speed) : base(name, 'P', speed, 1)
        {
            Fraction = fraction;

            SetAttributes();

            this.Skills = SkillFactory.GetNewSkillSet(fraction);

            SetInitialStats();
        }

        public Player(string name, Fraction fraction, int speed, List<Item> equipment, Dictionary<Skill, int> skills
                      ) : base(name, 'P', speed, 1, equipment)
        {
            Fraction = fraction;

            SetAttributes();

            this.Skills = skills;

            SetInitialStats();
        }

        public string GetPlayerBuffs()
        {
            string result = "Active buffs:\n";
            foreach (var buff in ActiveBuffs)
            {
                var statsWithOffset = buff.StatsString.Split('\n').Select(s => " " + s).Aggregate("", (acc, s) => acc + s + "\n");
                result += buff.ToString() + ":\n" + statsWithOffset;
            }
            return result;
        }

        private void SetAttributes()
        {
            Experience = 0;
            this.Level = 1;
        }

        private void SetInitialStats()
        {
            this.Health = this.MaxHealth = 10;
            this.AttackPower = (this.Skills[Skill.Strength] + this.Skills[Skill.ShootingPower]) / 2;
            this.DefencePower = this.Skills[Skill.Strength];

            this.Mana = this.MaxMana = this.Skills[Skill.Mana];

            this.Immortal = false;
            this.MagicPower = this.Skills[Skill.MagicPower];
        }

        [YamlDotNet.Serialization.YamlIgnore]
        public int UnlockingSkillLevel => Skills[Skill.Lockpicking];

        public override void Shoot<T>(Direction direction)
        {
            T projectile = (T)new Projectile(Skills[Skill.ShootingPower], direction);
        }

        public override void Update(TimeSpan deltaTime)
        {
            base.Update(deltaTime);

            bool changes = false;

            for (int i = ActiveBuffs.Count - 1; i >= 0; i--)
            {
                ActiveBuffs[i].Update(deltaTime);
                if (ActiveBuffs[i].Active == false)
                {
                    ActiveBuffs.RemoveAt(i);
                    changes = true;
                }
            }
            if (changes && !Screen.MenuConsole.IsActive)
            {
                // refresh player's stats
                Screen.MenuConsole.PrintPlayerStats();
            }
        }
    }
}
