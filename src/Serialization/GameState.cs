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

        public List<SerializeableKeyValue<Skill, int>> PlayerSkillsSerial
        {
            get
            {
                return PlayerSkills.ToSerializableKvp();
            }
            set
            {
                PlayerSkills = new Dictionary<Skill, int>();
                foreach (var item in value)
                    PlayerSkills.Add(item.Key, item.Value);
            }
        }
    }
}
