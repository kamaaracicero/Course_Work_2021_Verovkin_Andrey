using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreasureGameLib.BonusesRewards
{
    public abstract class Bonus : CollectedItem
    {
        public static int bonusScale = 3;

        public int BonusCount { get; private set; }

        public Bonus(Position position, float width, float height, OpenTKColor color, int bonusCount)
            : base (position, width, height, color)
        {
            BonusCount = bonusCount;
            position.X += (this.Width / bonusScale) * 1.5f;
            position.Y -= (this.Height / bonusScale) * 1.5f;
        }
    }
}
