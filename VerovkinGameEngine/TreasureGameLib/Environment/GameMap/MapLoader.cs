using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TreasureGameLib.Environment.Walls;

namespace TreasureGameLib.Environment.GameMap
{
    public class MapLoader : IMapLoader
    {
        #region Fields

        private string _path;

        MapBmpSettings Settings { get; set; }

        #endregion
        #region Constructors

        public MapLoader(string path)
            : this (path, new MapBmpSettings())
        { }

        public MapLoader(string path, MapBmpSettings settings)
        {
            _path = path;
            Settings = settings;
        }

        #endregion

        public Map LoadMapFromBmp()
        {
            int[,] arr;
            using (Bitmap bitmap = new Bitmap(_path))
            {
                arr = new int[bitmap.Width, bitmap.Height];

                for (int row = 0; row < bitmap.Height; row++)
                {
                    for (int col = 0; col < bitmap.Width; col++)
                    {
                        int color = bitmap.GetPixel(col, row).ToArgb();
                        if (color == Settings.Empty.ToArgb())
                            arr[row, col] = (int)WallTypes.Empty;
                        else if (color == Settings.Common.ToArgb())
                            arr[row, col] = (int)WallTypes.Common;
                        else if (color == Settings.Destructible.ToArgb())
                            arr[row, col] = (int)WallTypes.Destructible;
                        else if (color == Settings.Improved.ToArgb())
                            arr[row, col] = (int)WallTypes.Improved;
                        else
                            arr[row, col] = 10;
                    }
                }
            }
            return new Map(arr);
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
