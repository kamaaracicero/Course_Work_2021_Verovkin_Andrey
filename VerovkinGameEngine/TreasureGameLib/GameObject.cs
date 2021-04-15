using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreasureGameLib
{
    public abstract class GameObject
    {
        public OpenTKColor color;

        public Position position;

        public virtual bool IsVisiable { get; protected set; }

        public virtual bool Collider { get; protected set; }

        public float Height { get; }
        public float Width { get; }

        public GameObject(Position position, float width, float height, OpenTKColor color, bool isVisiable, bool collider)
        {
            this.position = position;
            Width = width;
            Height = height;
            this.color = color;
            IsVisiable = isVisiable;
            Collider = collider;
        }

        public virtual float[] GetCoords()
        {
            float[] arr = new float[12];
            arr[0] = position.X;
            arr[1] = position.Y;
            arr[2] = position.Z;

            arr[3] = position.X + Width;
            arr[4] = position.Y;
            arr[5] = position.Z;

            arr[6] = position.X + Width;
            arr[7] = position.Y - Height;
            arr[8] = position.Z;

            arr[9] = position.X;
            arr[10] = position.Y - Height;
            arr[11] = position.Z;

            return arr;
        }

        public virtual float[] GetColors()
        {
            float[] colors = new float[16];

            colors[0] = color.R;
            colors[1] = color.G;
            colors[2] = color.B;
            colors[3] = 1.0f;

            colors[4] = color.R;
            colors[5] = color.G;
            colors[6] = color.B;
            colors[7] = 1.0f;

            colors[8] = color.R;
            colors[9] = color.G;
            colors[10] = color.B;
            colors[11] = 1.0f;

            colors[12] = color.R;
            colors[13] = color.G;
            colors[14] = color.B;
            colors[15] = 1.0f;

            return colors;
        }

        public void SetPosition(float x, float y)
        {
            position.X = x;
            position.Y = y;
        }
    }
}
