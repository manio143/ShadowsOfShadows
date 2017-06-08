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
        [XmlElement("Player")]
        public Player Player { get; set; }
        [XmlArray("Rooms"), XmlArrayItem(typeof(Room), ElementName = "Room")]
        public List<Room> Rooms { get; set; }


        /* For serialization */
        public GameState() { }

		public GameState (Player player, List<Room> rooms)
		{
			this.Player = player;
			this.Rooms = rooms;
		}
    }
}
