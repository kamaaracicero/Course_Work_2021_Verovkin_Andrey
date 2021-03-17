using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreasureGameLib.Environment.GameMap
{
    public interface IMapSaver
    {
        /// <summary>
        /// Save map in bmp format
        /// </summary>
        /// <param name="map">Map</param>
        void SaveMapBmp(Map map);

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
