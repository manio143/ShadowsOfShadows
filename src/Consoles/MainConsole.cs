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
using ShadowsOfShadows.Generators;

namespace ShadowsOfShadows.Consoles
{
    public class MainConsole : Console
    {
        public Player Player { get { return State.Player; } }

        public Point Middle { get { return new Point(Width / 2, Height / 2); } }

		public RoomGenerator RoomGenerator => State.RoomGenerator;

		public List<Room> CurrentRooms => State.Rooms;

        public GameState State { get; set; }

        public MainConsole(int width, int height) : base(width, height)
        {
			State = new GameState (new Player("Player", Fraction.Warrior, 10));
			Player.Transform.Position = CurrentRooms[0].EnterPoint + new Point(1, 0);
        }

        public override void Draw(System.TimeSpan delta)
        {
            base.Draw(delta);

            var playerObject = Player.Renderable.ConsoleObject;
            playerObject.Position = Middle;
            playerObject.Draw(delta);

			foreach(var room in CurrentRooms)
            foreach (var entity in room.Entities)
            {
                var consoleObject = entity.Renderable.ConsoleObject;
                consoleObject.Position = entity.Transform.Position - Player.Transform.Position + Middle;
                if (consoleObject.Position.X < Width && consoleObject.Position.Y < Height)
                    consoleObject.Draw(delta);
            }
        }

		public List<Entity> Entities { get { return CurrentRooms.Select (r => r.Entities).Aggregate (Enumerable.Empty<Entity> (), (acc, e) => acc.Concat (e)).ToList (); } }

        public override void Update(TimeSpan delta)
        {
            base.Update(delta);
			foreach(var room in CurrentRooms)
			foreach (var entity in room.Entities)
                (entity as IUpdateable)?.Update(delta);

			foreach (var entity in CurrentRoom.Entities) 
			{
				var projectile = entity as Projectile;
				if (projectile != null && projectile.IsDead)
					CurrentRoom.Entities.Remove (projectile);
			}
            Player.Update(delta);
        }

        public override bool ProcessKeyboard(Keyboard info)
        {
            if (info.IsKeyPressed(Keys.Escape))
                Screen.MenuConsole.OpenMainMenu();

            ProcessMovement(info);

            ProcessAttack(info);

            if (info.IsKeyPressed(Keys.E))
            {
                var entity = Entities.FirstOrDefault(e => e.Transform.Position ==
                                                                   Player.Transform.Position +
                                                                   Player.Transform.Direction
                                                                       .AsPoint()) as IInteractable;
                entity?.Interact();
            }
            if (info.IsKeyPressed(Keys.T))
            {
                var entity = Entities.FirstOrDefault(e => e.Transform.Position ==
                                                                   Player.Transform.Position +
                                                                   Player.Transform.Direction.AsPoint()) as Openable;
                entity?.TryToUnlock();
            }

            return true;
        }

        private void ProcessAttack(Keyboard info)
        {
            if (info.IsKeyDown(Keys.Space))
                Player.IsAttacking = true;
            else
                Player.IsAttacking = false;
        }

        private void ProcessMovement(Keyboard info)
        {
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

            if (info.IsKeyUp(Keys.Up) && info.IsKeyUp(Keys.Left) && info.IsKeyUp(Keys.Right) && info.IsKeyUp(Keys.Down))
                Player.IsMoving = false;
        }
    }
}
