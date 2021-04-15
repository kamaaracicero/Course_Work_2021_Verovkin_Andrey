using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreasureGameLib.BonusesRewards
{
    public abstract class BonusFactory
    {
        protected const int standartParty = 5;

        protected int Party { get; private set; }

        protected readonly float bonusWidth;
        protected readonly float bonusHeight;

        public BonusFactory(int party, float bonusWidth, float bonusHeight)
        {
            Party = party;
            this.bonusWidth = bonusWidth;
            this.bonusHeight = bonusHeight;
        }

        public abstract Bonus[] CreateParty();

        public abstract Bonus CreateSingle();

        public abstract Bonus[] CreateNumber(int number);
    }
}
