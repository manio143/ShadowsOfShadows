using System;
using System.Linq;
using Microsoft.Xna.Framework;
using ShadowsOfShadows.Entities;
using MathNet.Numerics.Distributions;

namespace ShadowsOfShadows.Generators
{
	public class RoomGenerator
	{
		private bool first = true;
		private Room lastRoom = new Room{ ExitPoint = new Point(0,0) };

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

			first = false;

			lastRoom = room;

			return room;
		}
	}
}

