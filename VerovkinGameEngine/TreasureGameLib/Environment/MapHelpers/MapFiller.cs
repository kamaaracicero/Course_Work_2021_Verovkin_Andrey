using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TreasureGameLib.Environment.Walls;
using TreasureGameLib.BonusesRewards;

namespace TreasureGameLib.Environment.MapHelpers
{
    public class MapFiller : IMapFiller
    {
        public List<Place> FillMap(int[,] tilesMap, float tileWidth, float tileHeight)
        {
            decimal curHeightCoord = 1.0m;
            decimal curWidthCoord = -1.0m;
            List<Place> tilesList = new List<Place>();

            decimal tileWidthM = (decimal)tileWidth;
            decimal tileHeightM = (decimal)tileHeight;

            int index = 0;

            for (int row = 0; row < tilesMap.GetLength(0); row++)
            {
                for (int col = 0; col < tilesMap.GetLength(1); col++)
                {
                    switch (tilesMap[row, col])
                    {
                        case (int)WallTypes.Empty:
                            tilesList.Add(new Place(new Position((float)curWidthCoord, (float)curHeightCoord, 0f), tileWidth, tileHeight, index));
                            index++;
                            break;
                        case (int)WallTypes.Common:
                            tilesList.Add(new CommonWall(new Position((float)curWidthCoord, (float)curHeightCoord, 0f), tileWidth, tileHeight, index));
                            index++;
                            break;
                        case (int)WallTypes.Destructible:
                            tilesList.Add(new DestructibleWall(new Position((float)curWidthCoord, (float)curHeightCoord, 0f), tileWidth, tileHeight, index));
                            index++;
                            break;
                        case (int)WallTypes.Improved:
                            tilesList.Add(new ImprovedWall(new Position((float)curWidthCoord, (float)curHeightCoord, 0f), tileWidth, tileHeight, index));
                            index++;
                            break;
                    }
                    curWidthCoord += tileWidthM;
                }
                curWidthCoord = -1m;
                curHeightCoord -= tileHeightM;
            }
            return tilesList;
        }

        public int FillMapPoints(Map map, Point[] points, int[] emptySpaces)
        {
            int index = 0;
            foreach (int place in emptySpaces)
            {
                map.tilesList[place].SetPoints(points[index]);
                index++;
            }

            return emptySpaces.Length;
        }
    }
}
