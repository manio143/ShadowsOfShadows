using System;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using ShadowsOfShadows.Entities;
using ShadowsOfShadows.Helpers;
using ShadowsOfShadows.Physics;
using ShadowsOfShadows.Renderables;
using ShadowsOfShadows.TestData;
using ShadowsOfShadows.Serialization;
using Console = SadConsole.Console;
using IUpdateable = ShadowsOfShadows.Entities.IUpdateable;
using Keyboard = SadConsole.Input.Keyboard;
using System.Collections.Generic;
using SadConsole.GameHelpers;

namespace ShadowsOfShadows.Consoles
{
    public class MainConsole : Console
    {
        public Player Player { get; private set; }

        private Point Middle { get; }

        public Room CurrentRoom { get; private set; } = TestRooms.Room1;

        public MainConsole(int width, int height) : base(width, height)
        {
            /* Example of loading game state from file
             * GameState loader = new GameState();
            GameState lastGame = loader.loadGameState("1.sav");

            Player = lastGame.Player;
            Player.Renderable = new ConsoleRenderable('P');
            Player.Renderable.ConsoleObject.Position = lastGame.PlayerPosition;
            Player.Transform.Position = lastGame.PlayerPosition;
            CurrentRoom = lastGame.Rooms[0];

            foreach (var entity in CurrentRoom.Entities)
            {
                entity.Renderable = new ConsoleRenderable(entity.GetEntityChar());
                entity.Renderable.ConsoleObject.Position = entity.Transform.Position;
            }*/
            Player = new Player("Player", Fraction.Warrior, 10);


            var v = new Wall(new ConsoleRenderable(219));
            v.Transform.Position = new Point(2, 2);
            v.Transform.Collision.TurnOff();
            CurrentRoom.Entities.Add(v);
            Player.Transform.Position = new Point(1, 1);

            Middle = new Point(Width / 2, Height / 2);

            /* Example of saving game state
             * var rooms = new List<Room>();
            rooms.Add(CurrentRoom);

            var gS = new GameState(Player, rooms, Middle);
            gS.saveGameState("1.sav");*/
        }

        public override void Draw(System.TimeSpan delta)
        {
            base.Draw(delta);

            GameObject playerObject = Player.Renderable.ConsoleObject;
            //var playerObject = Player.Renderable.ConsoleObject;
            playerObject.Position = Middle;
            playerObject.Draw(delta);

            foreach (var entity in CurrentRoom.Entities)
            {
                GameObject consoleObject = entity.Renderable.ConsoleObject;
                //var consoleObject = entity.Renderable.ConsoleObject;
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
