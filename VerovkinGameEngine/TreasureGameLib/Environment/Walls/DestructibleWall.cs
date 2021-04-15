using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreasureGameLib.Environment.Walls
{
    public class DestructibleWall : Wall
    {
        public DestructibleWall(Position position, float width, float height, int index)
            : base (position, width, height, index, new OpenTKColor(0.0f, 1.0f, 0f))
        { }

        public override void Use()
        {
            Collider = false;
            IsVisiable = false;
        }
    }
}
