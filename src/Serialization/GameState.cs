using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.IO;
using System.Linq;
using System.Xml;

using Microsoft.Xna.Framework;

using ShadowsOfShadows.Entities;
using ShadowsOfShadows.Helpers;
using ShadowsOfShadows.Generators;

namespace ShadowsOfShadows.Serialization
{
    [Serializable()]
    public class GameState
    {
        [XmlElement("Player")]
        public Player Player { get; set; }
        [XmlArray("Rooms"), XmlArrayItem(typeof(Room), ElementName = "Room")]
        public List<Room> Rooms { get; set; }

        public RoomGenerator RoomGenerator { get; set; } = new RoomGenerator();


        /* For serialization */
        public GameState() { }

        public GameState(Player player)
        {
            this.Player = player;
            this.Rooms = new List<Room>() { this.RoomGenerator.GenerateRoom() };
        }
    }
}
