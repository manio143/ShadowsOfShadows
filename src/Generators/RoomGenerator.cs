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
        public bool first { get; set; } = true;
        public Room lastRoom { get; set; } = new Room { ExitPoint = new Point(0, 0) };

        private DiscreteUniform sizeGen = new DiscreteUniform(5, 30);
        private Bernoulli boolGen = new Bernoulli(0.20);
        private Normal itemCountGen = new Normal(3, 0.5);

        public Room GenerateEmpty(int width, int height, Point position, Point entryPoint, bool entryDoor = true)
        {
            width += 2; height += 2;
            position += new Point(-1, -1);
            var room = new Room(
                           Enumerable.Range(0, height).Select(y => new Point(0, y)).Concat(
                               Enumerable.Range(0, height).Select(y => new Point(width - 1, y)).Concat(
                                   Enumerable.Range(1, width - 1).Select(x => new Point(x, 0)).Concat(
                                       Enumerable.Range(1, width - 1).Select(x => new Point(x, height - 1))))).Select(p => new Wall(position + p)))
            {
                Position = position,
                Size = new Point(width, height)
            };
            var exitPoint = new Point(position.X + width - 1, position.Y + new DiscreteUniform(1, height - 2).Sample());
            room.Entities.RemoveAll(w => w.Transform.Position == entryPoint && entryDoor || w.Transform.Position == exitPoint);

            if (entryDoor) room.Entities.Add(new Door(entryPoint));
            room.Entities.Add(new Door(exitPoint, true));

            room.EnterPoint = entryPoint;
            room.ExitPoint = exitPoint;

            return room;
        }

        public Room GenerateRoom()
        {
            var width = sizeGen.Sample();
            var height = sizeGen.Sample();

            var offset = new DiscreteUniform(1, height - 2).Sample();

            var pivot = lastRoom.ExitPoint + new Point(1, -offset);

            var room = GenerateEmpty(width, height, pivot, lastRoom.ExitPoint, !first);

            var characterGen = new CharacterGenerator();
            var itemGen = new ItemGenerator();

            for (int i = 0; i < 6; i++)
            {
                if (boolGen.Sample() == 1)
                {
                    var character = characterGen.GenerateCharacter();
                    var position = findRandomPosition(room);
                    character.Transform.Position = position;
                    room.Entities.Add(character);
                }
            }
            for (int i = 0; i < 6; i++)
            {
                if (boolGen.Sample() == 1)
                {
                    var chest = new Chest();
                    var position = findRandomPosition(room);
                    chest.Transform.Position = position;
                    var itemCount = randomItemCount();
                    chest.Items = new List<Item>();
                    for (int j = 0; j < itemCount; j++)
                        chest.Items.Add(itemGen.GenerateItem());
                    room.Entities.Add(chest);
                }
            }

            lastRoom = room;
            first = false;

            return room;
        }

        private Point findRandomPosition(Room room)
        {
            Point p;
            do
            {
                p = new Point(room.Position.X + (sizeGen.Sample() % (room.Size.X - 2)) + 1,
                              room.Position.Y + (sizeGen.Sample() % (room.Size.Y - 2)) + 1);
            } while (room.Entities.Any(e => e.Transform.Position == p));
            return p;
        }

        private int randomItemCount()
        {
            return (int)((uint)itemCountGen.Sample());
        }
    }
}

