using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreasureGameLib.Environment.Walls
{
    public class ImprovedWall : Wall
    {
        public ImprovedWall(Position position, float width, float height, int index)
            : base(position, width, height, index, new OpenTKColor(0.35f, 0.35f, 0.35f))
        { }
    }
}
