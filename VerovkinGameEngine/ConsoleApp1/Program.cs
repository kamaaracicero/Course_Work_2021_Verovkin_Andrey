using System;
using TreasureGameLib.Environment.GameMap;
using System.Drawing;
using TreasureGameLib.Environment.Walls;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] tiles = new int[10, 10]
            {
                { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 },
                { 1, 0, 0, 0, 0, 3, 0, 0, 0, 1 },
                { 1, 0, 1, 1, 0, 3, 1, 1, 0, 1 },
                { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 },
                { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 },
                { 1, 1, 1, 1, 1, 3, 3, 1, 1, 1 },
                { 1, 1, 1, 0, 1, 1, 1, 1, 1, 1 },
                { 1, 1, 0, 0, 0, 1, 1, 2, 2, 1 },
                { 1, 0, 1, 1, 0, 1, 1, 1, 1, 1 },
                { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 }
            };
            string path = "map.bmp";

            Map map = new Map(tiles);

            MapSaver saver = new MapSaver(path);
            saver.SaveMapBmp(map);

            MapLoader loader = new MapLoader("map.bmp");
            Map map1 = loader.LoadMapFromBmp();

            for (int i = 0; i < map1.tiles.GetLength(0); i++)
                for (int j = 0; j < map1.tiles.GetLength(1); j++)
                    Console.WriteLine(map1.tiles[i, j]);
        }
    }
}
