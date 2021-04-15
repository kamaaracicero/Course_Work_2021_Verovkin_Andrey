using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreasureGameLib.Environment.Walls
{
    public class CommonWall : Wall
    {
        public CommonWall(Position position, float width, float height, int index)
            : base (position, width, height, index)
        { }
    }
}
