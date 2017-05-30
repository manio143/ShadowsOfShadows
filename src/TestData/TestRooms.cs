using Microsoft.Xna.Framework;
using ShadowsOfShadows.Entities;
using ShadowsOfShadows.Helpers;
using ShadowsOfShadows.Items;
using ShadowsOfShadows.Physics;
using ShadowsOfShadows.Renderables;

namespace ShadowsOfShadows.TestData
{
    public static class TestRooms
    {
		private static Room room1;
		public static Room Room1 => room1;

		static TestRooms()
		{
			room1 = new RoomGenerator().GenerateEmpty(15, 9, new Point(-3, -3));
			room1.Entities.Add(new Chest(new ConsoleRenderable('c'), 1, new Item [] { new Apple(), new StrengthPotion(System.TimeSpan.FromSeconds(5))})
				{
					Transform = new Transform() {Position = new Point(3, 3)}
				});
			room1.EnterPoint = new Point(-1, -1);
		}
    }
}