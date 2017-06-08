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

        [XmlIgnore] // TODO Can a dictionary really be serialized?
        public Dictionary<Skill, int> Skills { get; set; }

        /* For serialization */
        public Player() : base('P') { }

        public Player(string name, Fraction fraction, int speed) : base(name, 'P', speed, 1)
		{
			this.Fraction = fraction;
            this.Experience = 0;
			this.Level = 1;
			this.Skills = SkillFactory.GetNewSkillSet(fraction);
		}

		public Player(string name, Fraction fraction, int speed, List<Item> equipment, Dictionary<Skill, int> skills
		              ) : base(name, 'P', speed, 1, equipment)
		{
            this.Fraction = fraction;
            this.Experience = 0;
			this.Level = 1;
			this.Skills = skills;
		}

        public string GetPlayerBuffs()
        {
            string result = "Active buffs:\n";
            foreach (var buff in ActiveBuffs)
            {
				var statsWithOffset = buff.StatsString.Split ('\n').Select (s => " " + s).Aggregate ("", (acc, s) => acc + s + "\n");
				result += buff.ToString() + ":\n" + statsWithOffset;
            }
            return result;
        }

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
            if(changes && !Screen.MenuConsole.IsActive)
            {
                // refresh player's stats
                Screen.MenuConsole.PrintPlayerStats();
            }
        }
    }
}
