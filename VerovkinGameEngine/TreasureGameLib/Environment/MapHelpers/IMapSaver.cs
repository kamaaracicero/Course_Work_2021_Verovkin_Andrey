using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreasureGameLib.Environment.MapHelpers
{
    public interface IMapSaver
    {
        /// <summary>
        /// Save map in bmp format
        /// </summary>
        /// <param name="map">Map</param>
        void SaveMapBmp(int[,] tileMap);

        /// <summary>
        /// Save map in json format
        /// </summary>
        /// <param name="map">Map</param>
        void SaveMapJson(Map map);

        /// <summary>
        /// Save map in xml format
        /// </summary>
        /// <param name="map">Map</param>
        void SaveMapXml(Map map);
    }
}
