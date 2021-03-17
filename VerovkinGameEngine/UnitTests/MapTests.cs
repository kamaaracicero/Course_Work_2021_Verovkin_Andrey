using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using TreasureGameLib.Environment.GameMap;
using TreasureGameLib.Environment.Walls;

namespace UnitTests
{
    [TestClass]
    public class MapTests
    {
        [TestMethod]
        public void Test_MapSave()
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
        }

        [TestMethod]
        public void Test_MapLoader()
        {
            MapLoader loader = new MapLoader("map.bmp");
            Map map = loader.LoadMapFromBmp();

            MapSaver saver = new MapSaver("map.bmp");
            saver.SaveMapBmp(map);

            Assert.IsTrue(true);
        }
    }
}
