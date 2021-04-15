using System.Drawing;
using TreasureGameLib.Environment.Walls;

namespace TreasureGameLib.Environment.MapHelpers
{
    public class MapSaver : IMapSaver
    {
        #region Fields

        /// <summary>
        /// File path
        /// </summary>
        private string _path;

        /// <summary>
        /// Saver settings
        /// </summary>
        public MapBmpSettings WallSettings { get; set; }

        #endregion
        #region Constructors

        /// <summary>
        /// Standart constructor
        /// </summary>
        /// <param name="path">Path string</param>
        public MapSaver(string path)
            : this (path, new MapBmpSettings())
        { }

        /// <summary>
        /// Constructor with certain bitmap settings
        /// </summary>
        /// <param name="path">File path</param>
        /// <param name="settings">Settings</param>
        public MapSaver(string path, MapBmpSettings settings)
        {
            _path = path;
            this.WallSettings = settings;
        }

        #endregion
        public void SaveMapBmp(int[,] tileMap)
        {
            using (Bitmap bitmap = new Bitmap(tileMap.GetLength(1), tileMap.GetLength(0)))
            { 
                for (int row = 0; row < tileMap.GetLength(0); row++)
                {
                    for (int col = 0; col < tileMap.GetLength(1); col++)
                    {
                        switch (tileMap[row, col])
                        {
                            case (int)WallTypes.Empty:
                                bitmap.SetPixel(col, row, WallSettings.Empty);
                                break;
                            case (int)WallTypes.Common:
                                bitmap.SetPixel(col, row, WallSettings.Common);
                                break;
                            case (int)WallTypes.Destructible:
                                bitmap.SetPixel(col, row, WallSettings.Destructible);
                                break;
                            case (int)WallTypes.Improved:
                                bitmap.SetPixel(col, row, WallSettings.Improved);
                                break;
                        }
                    }
                }
                bitmap.Save(_path);
            }
        }


        public void SaveMapBmp(Map map)
        {
            throw new System.NotImplementedException();
        }

        public void SaveMapJson(Map map)
        {
            throw new System.NotImplementedException();
        }

        public void SaveMapXml(Map map)
        {
            throw new System.NotImplementedException();
        }
    }
}
