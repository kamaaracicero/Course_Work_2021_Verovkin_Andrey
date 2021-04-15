using TreasureGameLib.Environment;

namespace TreasureGameLib.Environment.MapHelpers
{
    public interface IMapLoader
    {
        /// <summary>
        /// Load map data from bmp image
        /// </summary>
        /// <returns>Map</returns>
        int[,] LoadMapFromBmp();

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
