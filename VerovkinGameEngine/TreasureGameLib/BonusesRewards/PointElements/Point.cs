using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreasureGameLib.BonusesRewards
{
    public abstract class Point : CollectedItem
    {
        public static int pointScale = 3;

        public int Count { get; private set; }

        public Point(Position position, float width, float height, OpenTKColor color, int count)
            : base (position, width, height, color)
        {
            Count = count;
            position.X += (this.Width / pointScale)* 1.5f;
            position.Y -= (this.Height / pointScale) * 1.5f;
        }
    }
}
