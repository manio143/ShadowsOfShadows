using System;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using ShadowsOfShadows.Entities;
using ShadowsOfShadows.Helpers;
using ShadowsOfShadows.Physics;
using ShadowsOfShadows.Renderables;
using ShadowsOfShadows.TestData;
using Console = SadConsole.Console;
using IUpdateable = ShadowsOfShadows.Entities.IUpdateable;
using Keyboard = SadConsole.Input.Keyboard;
using System.Collections.Generic;

namespace ShadowsOfShadows.Consoles
{
    public class MainConsole : Console
    {
        public Player Player { get; private set; }

        private Point Middle { get; }

        public Room CurrentRoom { get; set; } = TestRooms.Room1;

        public MainConsole(int width, int height) : base(width, height)
        {
            Player = new Player("Player", Fraction.Warrior, 10);
            foreach(var w in CurrentRoom.Entities)
            {
                w.Transform.Collision = new CollisionBox(
                new Polygon(new List<Rectangle> { new Rectangle(0, 0, 1, 1) })
                );
            }

            var v = new Wall(new ConsoleRenderable(219));
            v.Transform.Position = new Point(2, 2);
            v.Transform.Collision.TurnOff();
            CurrentRoom.Entities.Add(v);
            Player.Transform.Position = new Point(1, 1);

            Middle = new Point(Width / 2, Height / 2);
        }

        public override void Draw(System.TimeSpan delta)
        {
            base.Draw(delta);

            var playerObject = Player.Renderable.ConsoleObject;
            playerObject.Position = Middle;
            playerObject.Draw(delta);

            foreach (var entity in CurrentRoom.Entities)
            {
                var consoleObject = entity.Renderable.ConsoleObject;
                consoleObject.Position = entity.Transform.Position - Player.Transform.Position + Middle;
                if (consoleObject.Position.X < Width && consoleObject.Position.Y < Height)
                    consoleObject.Draw(delta);
            }
        }

        public override void Update(TimeSpan delta)
        {
            base.Update(delta);
            foreach (var entity in CurrentRoom.Entities)
                (entity as IUpdateable)?.Update(delta);
            Player.Update(delta);
        }

        public override bool ProcessKeyboard(Keyboard info)
        {
            if (info.IsKeyPressed(Keys.Escape))
                Screen.MenuConsole.OpenMainMenu();

            if (info.IsKeyDown(Keys.Up))
            {
                Player.Transform.Direction = Direction.Up;
                Player.IsMoving = true;
            }
            if (info.IsKeyDown(Keys.Right))
            {
                Player.Transform.Direction = Direction.Right;
                Player.IsMoving = true;
            }
            if (info.IsKeyDown(Keys.Left))
            {
                Player.Transform.Direction = Direction.Left;
                Player.IsMoving = true;
            }
            if (info.IsKeyDown(Keys.Down))
            {
                Player.Transform.Direction = Direction.Down;
                Player.IsMoving = true;
            }

            if (info.IsKeyReleased(Keys.Up) && Player.Transform.Direction == Direction.Up)
                Player.IsMoving = false;
            if (info.IsKeyReleased(Keys.Left) && Player.Transform.Direction == Direction.Left)
                Player.IsMoving = false;
            if (info.IsKeyReleased(Keys.Right) && Player.Transform.Direction == Direction.Right)
                Player.IsMoving = false;
            if (info.IsKeyReleased(Keys.Down) && Player.Transform.Direction == Direction.Down)
                Player.IsMoving = false;

            if (info.IsKeyPressed(Keys.E))
            {
                var entity = CurrentRoom.Entities.FirstOrDefault(e => e.Transform.Position ==
                                                                   Player.Transform.Position +
                                                                   Player.Transform.Direction
                                                                       .AsPoint()) as IInteractable;
                entity?.Interact();
            }
            if (info.IsKeyPressed(Keys.T))
            {
                var entity = CurrentRoom.Entities.FirstOrDefault(e => e.Transform.Position ==
                                                                   Player.Transform.Position +
                                                                   Player.Transform.Direction.AsPoint()) as Openable;
                entity?.TryToUnlock();
            }

            return true;
        }
    }
}
