using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreasureGameLib.BonusesRewards
{
    public class UniquePointFactory : PointFactory
    {
        public UniquePointFactory(int party, float width, float height)
            : base(party, width, height)
        { }

        public UniquePointFactory(float width, float height)
            : this(standartParty, width, height)
        { }

        public override Point[] CreateNumber(int number)
        {
            List<Point> points = new List<Point>();

            for (int index = 0; index < number; index++)
            {
                points.Add(new UniquePoint(new Position(0.0f, 0.0f, -0.25f), pointWidth, pointHeight));
            }

            return points.ToArray();
        }

        public override Point[] CreateParty()
        {
            List<Point> points = new List<Point>();

            for (int index = 0; index < Party; index++)
            {
                points.Add(new UniquePoint(new Position(0.0f, 0.0f, -0.25f), pointWidth, pointHeight));
            }

            return points.ToArray();
        }

        public override Point CreateSingle()
        {
            return new UniquePoint(new Position(0.0f, 0.0f, -0.25f), pointWidth, pointHeight);
        }
    }
}
