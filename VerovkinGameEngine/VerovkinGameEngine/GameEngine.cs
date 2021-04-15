using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL4;
using System;
using System.Collections.Generic;
using System.Threading;
using TreasureGameLib;
using TreasureGameLib.Environment;
using VerovkinGameEngine.EngineHelpers;

namespace VerovkinGameEngine
{
    public class GameEngine
    {
        public Color4 BackgroundColor { get; set; } = new Color4(1.0f, 1.0f, 1.0f, 1.0f);

        public Map map;
        public Player player1;
        public Player player2;

        public float[] mapVertexArray;
        public int mapBufferObject;
        public int mapArrayObject;

        public float[] mapColorArray;
        public int mapColorBufferObject;

        public float[] itemsVertexArray;
        public int itemsBufferObject;
        public int itemsArrayObject;

        public float[] itemsColorArray;
        public int itemsColorBufferObject;

        public float[] firstPlayerVertexArray;
        public int firstPlayerBufferObject;
        public int firstPlayerArrayObject;

        public float[] secondPlayerVertexArray;
        public int secondPlayerBufferObject;
        public int secondPlayerArrayObject;

        public float[] playersColorArray;
        public int playersColorBufferObject;

        public GameEngine(Map map)
        {
            this.map = map;
        }

        public void AddPlayer(Player player)
        {
            if (player1 == null)
                player1 = player;
            else
                player2 = player;
        }

        public void BufferMap()
        {
            mapVertexArray = GameObjectConverter.GetMapVertexs(map);
            mapBufferObject = GL.GenBuffer();
            GL.BindBuffer(BufferTarget.ArrayBuffer, mapBufferObject);
            GL.BufferData(BufferTarget.ArrayBuffer, mapVertexArray.Length * sizeof(float), mapVertexArray, BufferUsageHint.StaticDraw);

            mapArrayObject = GL.GenVertexArray();
            GL.BindVertexArray(mapArrayObject);

            GL.EnableVertexAttribArray(0);
            GL.VertexAttribPointer(0, 3, VertexAttribPointerType.Float, false, 0, 0);
        }

        public void BufferFirstPlayer()
        {
            player1 = map.SpawnPlayer();
            firstPlayerVertexArray = GameObjectConverter.GetPlayerVertexs(player1);

            firstPlayerBufferObject = GL.GenBuffer();
            GL.BindBuffer(BufferTarget.ArrayBuffer, firstPlayerBufferObject);
            GL.BufferData(BufferTarget.ArrayBuffer, firstPlayerVertexArray.Length * sizeof(float), firstPlayerVertexArray, BufferUsageHint.DynamicDraw);
            
            firstPlayerArrayObject = GL.GenVertexArray();
            GL.BindVertexArray(firstPlayerArrayObject);

            GL.EnableVertexAttribArray(0);
            GL.VertexAttribPointer(0, 3, VertexAttribPointerType.Float, false, 0, 0);
        }

        public void BufferSecondePlayer()
        {
            player2 = map.SpawnPlayer();
            secondPlayerVertexArray = GameObjectConverter.GetPlayerVertexs(player2);

            secondPlayerBufferObject = GL.GenBuffer();
            GL.BindBuffer(BufferTarget.ArrayBuffer, secondPlayerBufferObject);
            GL.BufferData(BufferTarget.ArrayBuffer, secondPlayerVertexArray.Length * sizeof(float), secondPlayerVertexArray, BufferUsageHint.DynamicDraw);

            secondPlayerArrayObject = GL.GenVertexArray();
            GL.BindVertexArray(secondPlayerArrayObject);

            GL.EnableVertexAttribArray(0);
            GL.VertexAttribPointer(0, 3, VertexAttribPointerType.Float, false, 0, 0);
        }

        public void BufferItems()
        {
            itemsVertexArray = GameObjectConverter.GetPointsVertexs(map);
            itemsBufferObject = GL.GenBuffer();
            GL.BindBuffer(BufferTarget.ArrayBuffer, itemsBufferObject);
            GL.BufferData(BufferTarget.ArrayBuffer, itemsVertexArray.Length * sizeof(float), itemsVertexArray, BufferUsageHint.DynamicDraw);

            itemsArrayObject = GL.GenVertexArray();
            GL.BindVertexArray(itemsArrayObject);

            GL.EnableVertexAttribArray(0);
            GL.VertexAttribPointer(0, 3, VertexAttribPointerType.Float, false, 0, 0);
        }

        public void BufferMapColors()
        {
            mapColorArray = GameObjectConverter.GetMapColors(map);

            mapColorBufferObject = GL.GenBuffer();
            GL.BindBuffer(BufferTarget.ArrayBuffer, mapColorBufferObject);
            GL.BufferData(BufferTarget.ArrayBuffer, sizeof(float) * mapColorArray.Length, mapColorArray, BufferUsageHint.DynamicDraw);

            GL.BindVertexArray(mapArrayObject);
            GL.EnableVertexAttribArray(1);
            GL.VertexAttribPointer(1, 4, VertexAttribPointerType.Float, false, 0, 0);
        }

        public void BufferPlayersColors()
        {
            List<float> colorsList = new List<float>();
            colorsList.AddRange(GameObjectConverter.GetPlayerColors(player1));
            colorsList.AddRange(GameObjectConverter.GetPlayerColors(player2));
            playersColorArray = colorsList.ToArray();

            playersColorBufferObject = GL.GenBuffer();
            GL.BindBuffer(BufferTarget.ArrayBuffer, playersColorBufferObject);
            GL.BufferData(BufferTarget.ArrayBuffer, sizeof(float) * playersColorArray.Length, playersColorArray, BufferUsageHint.StaticDraw);

            GL.BindVertexArray(firstPlayerArrayObject);
            GL.EnableVertexAttribArray(1);
            GL.VertexAttribPointer(1, 4, VertexAttribPointerType.Float, false, 0, 0);

            GL.BindVertexArray(secondPlayerArrayObject);
            GL.EnableVertexAttribArray(1);
            GL.VertexAttribPointer(1, 4, VertexAttribPointerType.Float, false, 0, 128);
        }

        public void BufferItemsColors()
        {
            itemsColorArray = GameObjectConverter.GetPointsColors(map);

            itemsColorBufferObject = GL.GenBuffer();
            GL.BindBuffer(BufferTarget.ArrayBuffer, itemsColorBufferObject);
            GL.BufferData(BufferTarget.ArrayBuffer, sizeof(float) * itemsColorArray.Length, itemsColorArray, BufferUsageHint.DynamicDraw);

            GL.BindVertexArray(itemsArrayObject);
            GL.EnableVertexAttribArray(1);
            GL.VertexAttribPointer(1, 4, VertexAttribPointerType.Float, false, 0, 0);
        }


        public void RewritePlayerBuffer(int player)
        {
            if (player == 1)
            {
                GL.BindVertexArray(firstPlayerArrayObject);
                GL.BindBuffer(BufferTarget.ArrayBuffer, firstPlayerBufferObject);
                GL.BufferData(BufferTarget.ArrayBuffer, firstPlayerVertexArray.Length * sizeof(float), firstPlayerVertexArray, BufferUsageHint.DynamicDraw);
            }
            else
            {
                GL.BindVertexArray(secondPlayerArrayObject);
                GL.BindBuffer(BufferTarget.ArrayBuffer, secondPlayerBufferObject);
                GL.BufferData(BufferTarget.ArrayBuffer, secondPlayerVertexArray.Length * sizeof(float), secondPlayerVertexArray, BufferUsageHint.DynamicDraw);
            }
        }

        public void RewriteMapBuffers()
        {
            GL.BindVertexArray(mapArrayObject);
            mapVertexArray = GameObjectConverter.GetMapVertexs(map);

            GL.BindBuffer(BufferTarget.ArrayBuffer, mapBufferObject);
            GL.BufferData(BufferTarget.ArrayBuffer, mapVertexArray.Length * sizeof(float), mapVertexArray, BufferUsageHint.StaticDraw);

            mapColorArray = GameObjectConverter.GetMapColors(map);

            GL.BindBuffer(BufferTarget.ArrayBuffer, mapColorBufferObject);
            GL.BufferData(BufferTarget.ArrayBuffer, mapColorArray.Length * sizeof(float), mapColorArray, BufferUsageHint.StaticDraw);

        }

        public void RewriteItemsBuffer()
        {
            GL.BindVertexArray(itemsArrayObject);
            itemsVertexArray = GameObjectConverter.GetPointsVertexs(map);

            GL.BindBuffer(BufferTarget.ArrayBuffer, itemsBufferObject);
            GL.BufferData(BufferTarget.ArrayBuffer, itemsVertexArray.Length * sizeof(float), itemsVertexArray, BufferUsageHint.DynamicDraw);

            itemsColorArray = GameObjectConverter.GetPointsColors(map);
            GL.BindBuffer(BufferTarget.ArrayBuffer, itemsColorBufferObject);
            GL.BufferData(BufferTarget.ArrayBuffer, itemsColorArray.Length * sizeof(float), itemsColorArray, BufferUsageHint.DynamicDraw);

        }
    }
}
