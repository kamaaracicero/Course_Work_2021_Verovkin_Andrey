using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreasureGameLib.Environment.Walls
{
    public class IntangibleWall : PlaceDecorator
    {
        public override bool Collider { get => false; }

        public override bool IsVisiable { get => true; }

        public IntangibleWall(Place place)
            : base (place, new OpenTKColor(0.86f, 0.86f, 0.86f))
        { }
    }
}
