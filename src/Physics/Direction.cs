using System;
using Microsoft.Xna.Framework;

namespace ShadowsOfShadows.Physics
{
    public enum Direction
    {
        Up,
        Down,
        Left,
        Right
    }

    public static class DirectionHelper
    {
        public static Point AsPoint(this Direction dir)
        {
            switch (dir)
            {
                case Direction.Up:
                    return new Point(0, -1);
                case Direction.Down:
                    return new Point(0, 1);
                case Direction.Left:
                    return new Point(-1, 0);
                case Direction.Right:
                    return new Point(1, 0);
                default:
                    throw new ArgumentOutOfRangeException(nameof(dir), dir, null);
            }
        }
    }
}