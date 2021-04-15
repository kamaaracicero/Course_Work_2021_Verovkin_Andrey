using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TreasureGameLib.BonusesRewards;

namespace TreasureGameLib.Environment
{
    public class Place : GameObject
    {
        public int Index { get; private set; }

        public Point Points { get; private set; }
        public Bonus Bonus { get; private set; }

        public Place(Position position, float width, float height, int index, bool isVisiable = false, bool collider = false)
            : base (position, width, height, new OpenTKColor(0.0f, 0.0f, 0.0f), isVisiable, collider)
        {
            this.Index = index;
        }

        public Place(Position position, float width, float height, int index, OpenTKColor color, bool isVisiable = false, bool collider = false)
            : base(position, width, height, color, isVisiable, collider)
        {
            this.Index = index;
        }

        public void SetBonus(Bonus bonus)
        {
            Bonus = bonus;
        }

        public void SetPoints(Point point)
        {
            point.position.X += this.position.X;
            point.position.Y += this.position.Y;
            Points = point;
        }

        public int GetPoints()
        {
            int points = Points.Count;
            Points.Use();
            Points = null;
            return points;
        }

    }
}
