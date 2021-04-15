using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreasureGameLib
{
    public class Player : GameObject
    {
        private const int viewBlockScale = 3;
        public const int playerScale = 2;
        private readonly OpenTKColor viewBlockColor = new OpenTKColor(0f, 0f, 0f);
        public readonly float viewBlockIndentX;
        public readonly float viewBlockIndentY;

        public int Count { get; set; } 

        public int Id { get; private set; }

        public int MapXCoord { get; set; }

        public int MapYCoord { get; set; }

        public Direction ViewDirection { get; set; }

        public int AbilitiesCount { get; set; }

        public Player(Position position, float width, float height, int id)
            : base (position, width / playerScale, height / playerScale, new OpenTKColor(1.0f, 0.0f, 0.0f), true, false)
        {
            Id = id;

            position.X += (this.Width / playerScale); // * (playerScale + 2); // if playerScale == 3
            position.Y -= (this.Height / playerScale); 

            viewBlockIndentX = Width / viewBlockScale;
            viewBlockIndentY = Height / viewBlockScale;

            AbilitiesCount = 2;
            if (id == 9)
                color = new OpenTKColor(0.0f, 0.0f, 1.0f);
        }

        public Player(float width, float height, int id)
            : this (new Position(0, 0, 0.5f), width, height, id)
        { }

        public void SetMapCoords(int x, int y)
        {
            MapXCoord = x;
            MapYCoord = y;
        }

        public float[] MoveViewBlock()
        {
            float[] viewBoxCoords = GetViewBoxCoords();
            switch (ViewDirection)
            {
                case Direction.Up:
                    for (int index = 1; index < viewBoxCoords.Length; index+=3)
                        viewBoxCoords[index] += viewBlockIndentY;
                    break;
                case Direction.Down:
                    for (int index = 1; index < viewBoxCoords.Length; index+=3)
                        viewBoxCoords[index] -= viewBlockIndentY;
                    break;
                case Direction.Right:
                    for (int index = 0; index < viewBoxCoords.Length; index+=3)
                        viewBoxCoords[index] += viewBlockIndentX;
                    break;
                case Direction.Left:
                    for (int index = 0; index < viewBoxCoords.Length; index+=3)
                        viewBoxCoords[index] -= viewBlockIndentX;
                    break;
            }
            return viewBoxCoords;
        }

        public override float[] GetCoords()
        {
            float[] arr = new float[24];

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

            arr[12] = position.X + viewBlockIndentX;
            arr[13] = position.Y - viewBlockIndentY;
            arr[14] = 1f;

            arr[15] = position.X + Width - viewBlockIndentX;
            arr[16] = position.Y - viewBlockIndentY;
            arr[17] = 1f;

            arr[18] = position.X + Width - viewBlockIndentX;
            arr[19] = position.Y - Height + viewBlockIndentY;
            arr[20] = 1f;

            arr[21] = position.X + viewBlockIndentX;
            arr[22] = position.Y - Height + viewBlockIndentY;
            arr[23] = 1f;

            return arr;
        }

        private float[] GetViewBoxCoords()
        {
            float[] arr = new float[12];

            arr[0] = position.X + viewBlockIndentX;
            arr[1] = position.Y - viewBlockIndentY;
            arr[2] = 1f;

            arr[3] = position.X + Width - viewBlockIndentX;
            arr[4] = position.Y - viewBlockIndentY;
            arr[5] = 1f;

            arr[6] = position.X + Width - viewBlockIndentX;
            arr[7] = position.Y - Height + viewBlockIndentY;
            arr[8] = 1f;

            arr[9] = position.X + viewBlockIndentX;
            arr[10] = position.Y - Height + viewBlockIndentY;
            arr[11] = 1f;

            return arr;
        }

        public override float[] GetColors()
        {
            float[] colors = new float[32];

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

            colors[16] = viewBlockColor.R;
            colors[17] = viewBlockColor.G;
            colors[18] = viewBlockColor.B;
            colors[19] = 1.0f;

            colors[20] = viewBlockColor.R;
            colors[21] = viewBlockColor.G;
            colors[22] = viewBlockColor.B;
            colors[23] = 1.0f;

            colors[24] = viewBlockColor.R;
            colors[25] = viewBlockColor.G;
            colors[26] = viewBlockColor.B;
            colors[27] = 1.0f;

            colors[28] = viewBlockColor.R;
            colors[29] = viewBlockColor.G;
            colors[30] = viewBlockColor.B;
            colors[31] = 1.0f;

            return colors;
        }
    }
}
