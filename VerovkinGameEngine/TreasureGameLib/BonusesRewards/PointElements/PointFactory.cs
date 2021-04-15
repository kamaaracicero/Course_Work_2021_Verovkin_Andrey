using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreasureGameLib.BonusesRewards
{
    public abstract class PointFactory
    {
        protected const int standartParty = 5;

        protected int Party { get; private set; }

        protected readonly float pointWidth;
        protected readonly float pointHeight;

        public PointFactory(int party, float width, float height)
        {
            Party = party;
            this.pointWidth = width;
            this.pointHeight = height;
        }

        public abstract Point[] CreateParty();

        public abstract Point CreateSingle();

        public abstract Point[] CreateNumber(int number);
    }
}
