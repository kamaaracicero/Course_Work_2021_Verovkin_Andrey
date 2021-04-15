using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreasureGameLib.BonusesRewards
{
    public class CommonPoint : Point
    {
        const int pointBonus = 1;

        public CommonPoint(Position position, float width, float height)
            :base (position, width, height, new OpenTKColor(1.0f, 1.0f, 0.0f), pointBonus)
        { }
    }
}
