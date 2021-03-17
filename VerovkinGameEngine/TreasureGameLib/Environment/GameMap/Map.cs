using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreasureGameLib.Environment.GameMap
{
    public class Map
    {
        #region Fields

        /// <summary>
        /// Map tiles array
        /// </summary>
        public readonly int[,] tiles;

        /// <summary>
        /// Map saver
        /// </summary>
        IMapSaver saver;
        

        #endregion
        #region Constructors

        /// <summary>
        /// Constructor. An array with filled values
        /// </summary>
        /// <param name="tilesMap">An array with filled values</param>
        public Map(int[,] tilesMap)
        {
            tiles = tilesMap;
        }

        /// <summary>
        /// Standart constructor
        /// </summary>
        /// <param name="width"></param>
        /// <param name="height"></param>
        public Map(int width, int height)
        {
            tiles = new int[width, height];
        }

        #endregion

    }
}
