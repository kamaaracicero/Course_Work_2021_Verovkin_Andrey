using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreasureGameLib.Environment.GameMap
{
    public interface IMapLoader
    {
        /// <summary>
        /// Load map data from bmp image
        /// </summary>
        /// <returns>Map</returns>
        Map LoadMapFromBmp();

        /// <summary>
        /// Load map data from json file
        /// </summary>
        /// <returns>Map</returns>
        Map LoadMapFromJson();

        /// <summary>
        /// Load map data from xml file
        /// </summary>
        /// <returns>Map</returns>
        Map LoadMapFromXml();
    }
}
