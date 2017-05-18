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

        [XmlIgnore]
        public Dictionary<Skill, int> Skills { get; private set; }

        /* For serialization */
        public Player() : base("", 'P', 1, 1)
        {

        }

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

		public int UnlockingSkillLevel => Skills[Skill.Lockpicking];

		public override void Shoot<T>(Direction direction)
		{
			T projectile = (T)new Projectile(Skills[Skill.ShootingPower], direction);
		}

        public override char GetEntityChar()
        {
            return 'P';
        }

        public SerializeableKeyValue<Skill, int>[] SearchCategoriesSerializable
        {
            get
            {
                var list = new SerializeableKeyValue<Skill, int> [Skills.Count];
                if (Skills != null)
                {
                    int i = 0;
                    foreach (var skill in Skills)
                        list[i++] = new SerializeableKeyValue<Skill, int>() { Key = skill.Key, Value = Skills[skill.Key] };
                    //list.AddRange(Skills.Keys.Select(key => new SerializeableKeyValue<Skill, int>() { Key = key, Value = Skills[key] }));
                }
                return list.ToArray();
            }
            set
            {
                Skills = new Dictionary<Skill, int>();
                foreach (var item in value)
                {
                    Skills.Add(item.Key, item.Value);
                }
            }
        }
    }
}
