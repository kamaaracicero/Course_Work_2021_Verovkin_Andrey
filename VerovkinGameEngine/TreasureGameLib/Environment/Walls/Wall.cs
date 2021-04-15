using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreasureGameLib.Environment.Walls
{
    public abstract class Wall : Place
    {
        public Wall(Position position, float width, float height, int index)
            : base(position, width, height, index, new OpenTKColor(0.58f, 0.58f, 0.58f), true, true)
        { }

        public Wall(Position position, float width, float height, int index, OpenTKColor color)
            : base(position, width, height, index, color, true, true)
        { }

        public virtual void Use()
        {
            return;
        }
    }
}
