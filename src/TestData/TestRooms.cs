using System.Linq;
using Microsoft.Xna.Framework;
using ShadowsOfShadows.Entities;
using ShadowsOfShadows.Generators;
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
            room1 = new RoomGenerator().GenerateEmpty(15, 9, new Point(-3, -3), new Point());
            room1.Entities.Add(new Chest(new ConsoleRenderable('c'), 1,
                new Item[] { new Apple(), new StrengthPotion(System.TimeSpan.FromSeconds(5)), new Apple(), new Apple(), new Apple(), new Apple(), new Apple(), new Apple(), new Apple(), new Apple(), new Apple() })
            {
                Transform = new Transform() { Position = new Point(3, 3) }
            });
            var itemGen = new ItemGenerator();
            room1.Entities.Add(new Chest(new ConsoleRenderable('c'), 0,
                Enumerable.Range(1, 5).Select(n => itemGen.GenerateItem()).Cast<Item>().ToArray())
            {
                Transform = new Transform() { Position = new Point(0, 5) }
            });
            room1.EnterPoint = new Point(-1, -1);
        }
    }
}