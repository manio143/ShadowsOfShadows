using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.IO;

using ShadowsOfShadows.Entities;
using System.Xml;
using Microsoft.Xna.Framework;

namespace ShadowsOfShadows.Serialization
{
	[Serializable()]
	public class GameState
	{
		[XmlElement("Player")]
		public Player Player { get; set; }
		[XmlArray("Rooms"), XmlArrayItem(typeof(Room), ElementName = "Room")]
        public List<Room> Rooms { get; set; }

        public Point PlayerPosition { get; set; }

		/* For serialization */
		public GameState()
		{
		
		}

		public GameState (Player player, List<Room> rooms, Point playerPosition)
		{
			this.Player = player;
			this.Rooms = rooms;
            this.PlayerPosition = playerPosition;
		}

		public void saveGameState(string fileName)
		{
			// TODO Catch exception
			XmlSerializer xsSubmit = new XmlSerializer(typeof(GameState));
		    var objectToSerialize = this;
			var xml = "";

			using(var sww = new StringWriter())
			{
				using(XmlWriter writer = XmlWriter.Create(sww))
				{
					xsSubmit.Serialize(writer, objectToSerialize);
					xml = sww.ToString();

					System.IO.StreamWriter file = new System.IO.StreamWriter("../../../savedgames/" + fileName);
					file.Write(xml);

					file.Close();
				}
			}
		}

        public GameState loadGameState(string fileName)
        {
            GameState state = null;
            string path = "../../../savedgames/" + fileName;

            XmlSerializer serializer = new XmlSerializer(typeof(GameState));

            StreamReader reader = new StreamReader(path);
            state = (GameState)serializer.Deserialize(reader);
            reader.Close();

            return state;
        }
	}
}
