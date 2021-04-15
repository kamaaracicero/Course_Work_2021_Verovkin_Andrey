using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreasureGameLib.BonusesRewards
{
    public abstract class CollectedItem : GameObject
    {
        public CollectedItem(Position position, float width, float height, OpenTKColor color)
            : base(position, width, height, color, true, false)
        {
            position.X += Width / 2;
            position.Y -= Height / 2;
        }

        public void Use()
        {
            IsVisiable = false;
        }
    }
}
