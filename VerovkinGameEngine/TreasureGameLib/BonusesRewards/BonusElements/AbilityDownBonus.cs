using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreasureGameLib.BonusesRewards
{
    public class AbilityDownBonus : Bonus
    {
        public const int bonusCount = -1;

        public AbilityDownBonus(Position position, float width, float height)
            : base (position, width, height, new OpenTKColor(0.0f, 0.0f, 0.0f), bonusCount)
        { }
    }
}
