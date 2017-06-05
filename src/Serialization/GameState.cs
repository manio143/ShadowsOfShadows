using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.IO;

using ShadowsOfShadows.Entities;
using System.Xml;
using Microsoft.Xna.Framework;
using ShadowsOfShadows.Helpers;
using System.Linq;

namespace ShadowsOfShadows.Serialization
{
	[Serializable()]
	public class GameState
	{
        [XmlIgnore]
        public Dictionary<Skill, int> PlayerSkills { get; set; }

        [XmlElement("Player")]
		public Player Player { get; set; }
		[XmlArray("Rooms"), XmlArrayItem(typeof(Room), ElementName = "Room")]
        public List<Room> Rooms { get; set; }

        public Point Middle { get; set; }

        /* For serialization */
        public GameState() { }

		public GameState (Player player, List<Room> rooms, Point middle)
		{
            this.PlayerSkills = player.Skills;
			this.Player = player;
			this.Rooms = rooms;
            this.Middle = middle;
		}

        public SerializeableKeyValue<Skill, int>[] SearchCategoriesSerializable
        {
            get
            {
                var skills = PlayerSkills;
                var list = new SerializeableKeyValue<Skill, int>[skills.Count];
                if (skills != null)
                {
                    int i = 0;
                    foreach (var skill in skills)
                        list[i++] = new SerializeableKeyValue<Skill, int>() { Key = skill.Key, Value = skills[skill.Key] };
                    //list.AddRange(Skills.Keys.Select(key => new SerializeableKeyValue<Skill, int>() { Key = key, Value = Skills[key] }));
                }
                return list.ToArray();
            }
            set
            {
                PlayerSkills = new Dictionary<Skill, int>();
                foreach (var item in value)
                {
                    PlayerSkills.Add(item.Key, item.Value);
                }
            }
        }
    }
}
