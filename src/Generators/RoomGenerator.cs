using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using MathNet.Numerics.Distributions;

using ShadowsOfShadows.Entities;
using ShadowsOfShadows.Physics;
using ShadowsOfShadows.Items;

namespace ShadowsOfShadows.Generators
{
	public class RoomGenerator
	{
		public bool first {get;set;} = true;
		public Room lastRoom {get;set;} = new Room{ ExitPoint = new Point(0,0) };

		private DiscreteUniform sizeGen = new DiscreteUniform (5, 30);

		public Room GenerateEmpty(int width, int height, Point position, Point entryPoint, bool entryDoor = true)
		{
			width+=2; height+=2;
			position += new Point (-1, -1);
			var room = new Room (
				           Enumerable.Range (0, height).Select (y => new Point (0, y)).Concat (
					           Enumerable.Range (0, height).Select (y => new Point (width - 1, y)).Concat (
						           Enumerable.Range (1, width - 1).Select (x => new Point (x, 0)).Concat (
							           Enumerable.Range (1, width - 1).Select (x => new Point (x, height - 1))))).Select (p => new Wall (position + p))) {
				Position = position,
				Size = new Point (width, height)
			};
			var exitPoint = new Point(position.X + width - 1, position.Y + new DiscreteUniform (1, height - 2).Sample());
			room.Entities.RemoveAll (w => w.Transform.Position == entryPoint && entryDoor || w.Transform.Position == exitPoint);

			if(entryDoor) room.Entities.Add (new Door (entryPoint));
			room.Entities.Add (new Door (exitPoint, true));

			room.EnterPoint = entryPoint;
			room.ExitPoint = exitPoint;

			return room;
		}

		public Room GenerateRoom() 
		{
			var width = sizeGen.Sample ();
			var height = sizeGen.Sample ();

			var offset = new DiscreteUniform (1, height - 2).Sample();

			var pivot = lastRoom.ExitPoint + new Point (1, -offset);

			var room = GenerateEmpty (width, height, pivot, lastRoom.ExitPoint, !first);
            var gen = new CharacterGenerator();
            var character = gen.GenerateCharacter();
            character.Transform.Position = room.Position + new Point(room.Size.X / 2, room.Size.Y /2);
            room.Entities.Add(character);
			
			first = false;

			var itemGen = new ItemGenerator();
			var chest = new Chest() {Transform = new Transform() {Position = room.Position + new Point(3, 2)}};
			chest.Items = new List<Item>() {itemGen.GenerateItem(), itemGen.GenerateItem(), itemGen.GenerateItem()};
			room.Entities.Add(chest);

			lastRoom = room;

			return room;
		}
	}
}

