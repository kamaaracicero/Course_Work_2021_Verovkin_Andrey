using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreasureGameLib.BonusesRewards
{
    public class UniquePoint : Point
    {
        const int bonusPoints = 5;

        public UniquePoint(Position position, float width, float height)
            : base (position, width, height, new OpenTKColor(0.5f, 0.0f, 0.5f), bonusPoints)
        { }
    }
}
