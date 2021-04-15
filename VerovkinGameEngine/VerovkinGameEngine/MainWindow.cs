using OpenTK;
using OpenTK.Graphics;
using OpenTK.Input;
using OpenTK.Graphics.OpenGL4;
using TreasureGameLib;
using TreasureGameLib.Environment.Walls;
using TreasureGameLib.Environment;
using TreasureGameLib.Environment.MapHelpers;
using System.IO;
using VerovkinGameEngine.EngineHelpers;
using System.Windows.Forms;

namespace VerovkinGameEngine
{
    public partial class MainWindow : GameWindow
    {
        private ElementMovement.ObjectMover movement = new ElementMovement.ObjectMover();

        private Shader _shader;

        private GameEngine _engine;

        private string mapPath;


        public MainWindow(int width, int height, string title, string mapPath)
            : base(width, height, GraphicsMode.Default, title, GameWindowFlags.Default, DisplayDevice.Default)
        {
            Title += "GL ver:" + GL.GetString(StringName.Version);
            Load += MainWindow_Load;
            KeyDown += MainWindow_KeyDown;
            RenderFrame += MainWindow_RenderFrame;
            Unload += MainWindow_Unload;
            Resize += MainWindow_Resize;
            this.mapPath = mapPath;
        }

        private void MainWindow_Load(object sender, System.EventArgs e)
        {
            _engine = new GameEngine(new Map(mapPath));

            GL.ClearColor(_engine.BackgroundColor);
            
            _engine.BufferMap();
            _engine.BufferFirstPlayer();
            _engine.BufferSecondePlayer();
            _engine.BufferMapColors();
            _engine.BufferPlayersColors();
            _engine.BufferItems();
            _engine.BufferItemsColors();

            _shader = new Shader("Shaders\\shader1.vert", "Shaders\\shader1.frag");

            _shader.Use();
        }

        private void MainWindow_KeyDown(object sender, KeyboardKeyEventArgs e)
        {
            bool isFirstPlayerMove = false;
            bool isSecondPlayerMove = false;
            switch (e.Key)
            {
                case Key.Escape:
                    Exit();
                    break;
                case Key.W:
                    if (_engine.map.MovePlayer(_engine.player1, Direction.Up))
                    {
                        movement.MovePlayerY(_engine.map.tileHeight, ref _engine.firstPlayerVertexArray, _engine.player1);
                    }
                    isFirstPlayerMove = true;
                    break;
                case Key.S:
                    if (_engine.map.MovePlayer(_engine.player1, Direction.Down))
                    {
                        movement.MovePlayerY(-_engine.map.tileHeight, ref _engine.firstPlayerVertexArray, _engine.player1);
                    }
                    isFirstPlayerMove = true;
                    break;
                case Key.D:
                    if (_engine.map.MovePlayer(_engine.player1, Direction.Right))
                    {
                        movement.MovePlayerX(_engine.map.tileWidth, ref _engine.firstPlayerVertexArray, _engine.player1);
                    }
                    isFirstPlayerMove = true;
                    break;
                case Key.A:
                    if (_engine.map.MovePlayer(_engine.player1, Direction.Left))
                    {
                        movement.MovePlayerX(-_engine.map.tileWidth, ref _engine.firstPlayerVertexArray, _engine.player1);
                    }
                    isFirstPlayerMove = true;
                    break;
                case Key.E:
                    _engine.map.AffectWall(_engine.player1);
                    break;
                case Key.Q:
                    _engine.map.PlaceWall(_engine.player1);
                    break;
                case Key.Up:
                    if (_engine.map.MovePlayer(_engine.player2, Direction.Up))
                    {
                        movement.MovePlayerY(_engine.map.tileHeight, ref _engine.secondPlayerVertexArray, _engine.player2);
                    }
                    isSecondPlayerMove = true;
                    break;
                case Key.Down:
                    if (_engine.map.MovePlayer(_engine.player2, Direction.Down))
                    {
                        movement.MovePlayerY(-_engine.map.tileHeight, ref _engine.secondPlayerVertexArray, _engine.player2);
                    }
                    isSecondPlayerMove = true;
                    break;
                case Key.Right:
                    if (_engine.map.MovePlayer(_engine.player2, Direction.Right))
                    {
                        movement.MovePlayerX(_engine.map.tileWidth, ref _engine.secondPlayerVertexArray, _engine.player2);
                    }
                    isSecondPlayerMove = true;
                    break;
                case Key.Left:
                    if (_engine.map.MovePlayer(_engine.player2, Direction.Left))
                    {
                        movement.MovePlayerX(-_engine.map.tileWidth, ref _engine.secondPlayerVertexArray, _engine.player2);
                    }
                    isSecondPlayerMove = true;
                    break;
                case Key.KeypadPlus:
                    _engine.map.AffectWall(_engine.player2);
                    break;
                case Key.KeypadEnter:
                    _engine.map.PlaceWall(_engine.player2);
                    break;
            }
            if (isFirstPlayerMove)
            {
                movement.MovePlayerViewBox(ref _engine.firstPlayerVertexArray, _engine.player1);
                _engine.RewritePlayerBuffer(1);
            }
            if (isSecondPlayerMove)
            {
                movement.MovePlayerViewBox(ref _engine.secondPlayerVertexArray, _engine.player2);
                _engine.RewritePlayerBuffer(2);
            }
        }

        private void MainWindow_RenderFrame(object sender, FrameEventArgs e)
        {
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
            if (_engine.map.IsMapRewrite)
            {
                _engine.RewriteMapBuffers();
                _engine.map.IsMapRewrite = false;
            }
            if (_engine.map.IsItemsRewrite)
            {
                _engine.RewriteItemsBuffer();
                _engine.map.IsItemsRewrite = false;
            }
            if (_engine.map.pointsNumber == 0)
            {
                if (_engine.player1.Count > _engine.player2.Count)
                    MessageBox.Show("First player win");
                else
                    MessageBox.Show("Second player win");
                Exit();
            }

            _shader.Use();
            GL.BindVertexArray(_engine.mapArrayObject);
            GL.DrawArrays(PrimitiveType.Quads, 0, _engine.mapVertexArray.Length / 3);

            GL.BindVertexArray(_engine.itemsArrayObject);
            GL.DrawArrays(PrimitiveType.Quads, 0, _engine.itemsVertexArray.Length / 3);

            GL.BindVertexArray(_engine.firstPlayerArrayObject);
            GL.DrawArrays(PrimitiveType.Quads, 0, _engine.firstPlayerVertexArray.Length / 3);

            GL.BindVertexArray(_engine.secondPlayerArrayObject);
            GL.DrawArrays(PrimitiveType.Quads, 0, _engine.firstPlayerVertexArray.Length / 3);

            SwapBuffers();
        }

        private void MainWindow_Resize(object sender, System.EventArgs e)
        {
            GL.Viewport(0, 0, Width, Height);
        }

        private void MainWindow_Unload(object sender, System.EventArgs e)
        {
            // Buffers
            GL.DeleteBuffer(_engine.mapBufferObject);
            GL.DeleteBuffer(_engine.mapColorBufferObject);

            GL.DeleteBuffer(_engine.firstPlayerBufferObject);
            GL.DeleteBuffer(_engine.secondPlayerBufferObject);
            GL.DeleteBuffer(_engine.playersColorBufferObject);

            GL.DeleteBuffer(_engine.itemsBufferObject);
            GL.DeleteBuffer(_engine.itemsColorBufferObject);

            // Vertex Arrays
            GL.BindVertexArray(_engine.mapArrayObject);
            GL.DisableVertexAttribArray(0);
            GL.DisableVertexAttribArray(1);
            GL.DeleteVertexArray(_engine.mapArrayObject);

            GL.BindVertexArray(_engine.firstPlayerArrayObject);
            GL.DisableVertexAttribArray(0);
            GL.DisableVertexAttribArray(1);
            GL.DeleteVertexArray(_engine.firstPlayerArrayObject);

            GL.BindVertexArray(_engine.secondPlayerArrayObject);
            GL.DisableVertexAttribArray(0);
            GL.DisableVertexAttribArray(1);
            GL.DeleteVertexArray(_engine.secondPlayerArrayObject);

            GL.BindVertexArray(_engine.itemsArrayObject);
            GL.DisableVertexAttribArray(0);
            GL.DisableVertexAttribArray(1);
            GL.DeleteVertexArray(_engine.itemsArrayObject);

            // Final
            GL.BindBuffer(BufferTarget.ArrayBuffer, 0);
            GL.BindVertexArray(0);
            GL.UseProgram(0);

            GL.DeleteProgram(_shader.Handle);
        }
    }
}
