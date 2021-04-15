using System;
using System.Drawing;
using TreasureGameLib.Environment.Walls;

namespace TreasureGameLib.Environment.MapHelpers
{
    public class MapLoader : IMapLoader
    {
        #region Fields

        private string _path;

        MapBmpSettings WallSettings { get; set; }

        #endregion
        #region Constructors

        public MapLoader(string path)
            : this (path, new MapBmpSettings())
        { }

        public MapLoader(string path, MapBmpSettings settings)
        {
            _path = path;
            WallSettings = settings;
        }

        #endregion

        public int[,] LoadMapFromBmp()
        {
            int[,] arr;
            using (Bitmap bitmap = new Bitmap(_path))
            {
                arr = new int[bitmap.Height, bitmap.Width];

                for (int row = 0; row < bitmap.Height; row++)
                {
                    for (int col = 0; col < bitmap.Width; col++)
                    {
                        int color = bitmap.GetPixel(col, row).ToArgb();
                        if (color == WallSettings.Empty.ToArgb())
                            arr[row, col] = (int)WallTypes.Empty;
                        else if (color == WallSettings.Common.ToArgb())
                            arr[row, col] = (int)WallTypes.Common;
                        else if (color == WallSettings.Destructible.ToArgb())
                            arr[row, col] = (int)WallTypes.Destructible;
                        else if (color == WallSettings.Improved.ToArgb())
                            arr[row, col] = (int)WallTypes.Improved;
                    }
                }
            }
            return arr;
        }

        public Map LoadMapFromJson()
        {
            throw new NotImplementedException();
        }

        public Map LoadMapFromXml()
        {
            throw new NotImplementedException();
        }
    }
}
