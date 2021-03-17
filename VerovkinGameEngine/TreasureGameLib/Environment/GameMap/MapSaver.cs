using System;
using System.Drawing;
using System.IO;
using TreasureGameLib.Environment.Walls;

namespace TreasureGameLib.Environment.GameMap
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
        public MapBmpSettings Settings { get; set; }

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
            this.Settings = settings;
        }

        #endregion

        public void SaveMapBmp(Map map)
        {
            using (Bitmap bitmap = new Bitmap(map.tiles.GetLength(0), map.tiles.GetLength(1)))
            { 
                for (int row = 0; row < map.tiles.GetLength(0); row++)
                {
                    for (int col = 0; col < map.tiles.GetLength(1); col++)
                    {
                        switch (map.tiles[row, col])
                        {
                            case (int)WallTypes.Empty:
                                bitmap.SetPixel(col, row, Settings.Empty);
                                break;
                            case (int)WallTypes.Common:
                                bitmap.SetPixel(col, row, Settings.Common);
                                break;
                            case (int)WallTypes.Destructible:
                                bitmap.SetPixel(col, row, Settings.Destructible);
                                break;
                            case (int)WallTypes.Improved:
                                bitmap.SetPixel(col, row, Settings.Improved);
                                break;
                        }
                    }
                }
                bitmap.Save(_path);
            }
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
