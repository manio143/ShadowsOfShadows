using System;
using System.Linq;
using ShadowsOfShadows.Entities;
using Microsoft.Xna.Framework;

namespace ShadowsOfShadows
{
	public class RoomGenerator
	{
		public Room GenerateEmpty(int width, int height, Point position)
		{
			width+=2; height+=2;
			position += new Point (-1, -1);
			return new Room (
				Enumerable.Range (0, height).Select (y => new Point (0, y)).Concat (
					Enumerable.Range (0, height).Select (y => new Point (width - 1, y)).Concat (
						Enumerable.Range (1, width - 1).Select (x => new Point (x, 0)).Concat (
							Enumerable.Range (1, width - 1).Select (x => new Point (x, height - 1))))).Select (p => new Wall (position + p)));
		}
	}
}

