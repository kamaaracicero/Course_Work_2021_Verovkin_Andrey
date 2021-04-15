using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreasureGameLib
{
    public class OpenTKColor
    {
        public float R { get; set; }

        public float G { get; set; }

        public float B { get; set; }

        public const float F = 1.0f;

        public OpenTKColor(float r, float g, float b)
        {
            this.R = r;
            this.G = g;
            this.B = b;
        }
    }
}
