using System.Collections.Generic;
using TreasureGameLib.BonusesRewards;

namespace TreasureGameLib.Environment.MapHelpers
{
    public interface IMapFiller
    {
        List<Place> FillMap(int[,] tilesMap, float tileWidth, float tileHeight);
        int FillMapPoints(Map map, Point[] points, int[] emptySpaces);
    }
}
