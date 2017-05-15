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
        public static Room Room1 => new Room(new Entity[]
        {
            new Wall(new ConsoleRenderable(219)){Transform = new Transform(){Position = new Point(0,0)}},
            new Wall(new ConsoleRenderable(219)){Transform = new Transform(){Position = new Point(0,1)}},
            new Wall(new ConsoleRenderable(219)){Transform = new Transform(){Position = new Point(0,2)}},
            new Wall(new ConsoleRenderable(219)){Transform = new Transform(){Position = new Point(0,3)}},
            new Wall(new ConsoleRenderable(219)){Transform = new Transform(){Position = new Point(0,4)}},
            new Wall(new ConsoleRenderable(219)){Transform = new Transform(){Position = new Point(1,4)}},
            new Wall(new ConsoleRenderable(219)){Transform = new Transform(){Position = new Point(2,4)}},
            new Wall(new ConsoleRenderable(219)){Transform = new Transform(){Position = new Point(3,4)}},
            new Wall(new ConsoleRenderable(219)){Transform = new Transform(){Position = new Point(4,4)}},
            new Wall(new ConsoleRenderable(219)){Transform = new Transform(){Position = new Point(4,3)}},
            new Wall(new ConsoleRenderable(219)){Transform = new Transform(){Position = new Point(4,2)}},
            new Wall(new ConsoleRenderable(219)){Transform = new Transform(){Position = new Point(4,1)}},
            new Wall(new ConsoleRenderable(219)){Transform = new Transform(){Position = new Point(4,0)}},

            new Chest(new ConsoleRenderable('c'),1,new []{new Apple()} ){Transform = new Transform(){Position = new Point(3,3)}},
        });
    }
}