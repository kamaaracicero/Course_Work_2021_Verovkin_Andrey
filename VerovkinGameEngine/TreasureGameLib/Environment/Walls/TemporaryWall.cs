using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreasureGameLib.Environment.Walls
{
    public class TemporaryWall : PlaceDecorator
    {
        public override bool Collider { get => true; }

        public override bool IsVisiable { get => true; }

        public TemporaryWall(Place place)
            : base(place, new OpenTKColor(0.35f, 0.35f, 0.35f))
        { }
    }
}
