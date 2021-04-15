using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreasureGameLib
{
    public static class DirectionOperations
    {
        public static Direction GetOppositeDirection(Direction direction)
        {
            Direction opposite = Direction.Up;
            switch (direction)
            {
                case Direction.Up:
                    opposite = Direction.Down;
                    break;
                case Direction.Down:
                    opposite = Direction.Up;
                    break;
                case Direction.Right:
                    opposite = Direction.Left;
                    break;
                case Direction.Left:
                    opposite = Direction.Right;
                    break;
            }
            return opposite;
        }
    }
}
