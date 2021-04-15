using TreasureGameLib.Environment;
using TreasureGameLib;
using System.Collections.Generic;

namespace VerovkinGameEngine.EngineHelpers
{
    public static class GameObjectConverter 
    {
        public static float[] GetMapVertexs(Map map)
        {
            List<float> vertexList = new List<float>();
            foreach (GameObject obj in map.tilesList)
            {
                if (obj.IsVisiable)
                    vertexList.AddRange(obj.GetCoords());
            }

            return vertexList.ToArray();
        }

        public static float[] GetMapColors(Map map)
        {
            List<float> colorList = new List<float>();
            foreach (GameObject obj in map.tilesList)
            {
                if (obj.IsVisiable)
                    colorList.AddRange(obj.GetColors());
            }

            return colorList.ToArray();
        }

        public static float[] GetPlayerVertexs(Player player) => player.GetCoords();

        public static float[] GetPlayerColors(Player player) => player.GetColors();

        public static float[] GetPointsVertexs(Map map)
        {
            List<float> vertexList = new List<float>();
            foreach (Place place in map.tilesList)
            {
                if (place.Points != null && place.Points.IsVisiable)
                    vertexList.AddRange(place.Points.GetCoords());
            }

            return vertexList.ToArray();
        }

        public static float[] GetPointsColors(Map map)
        {
            List<float> colorList = new List<float>();
            foreach (Place place in map.tilesList)
            {
                if (place.Points != null && place.Points.IsVisiable)
                    colorList.AddRange(place.Points.GetColors());
            }

            return colorList.ToArray();
        }
    }
}
