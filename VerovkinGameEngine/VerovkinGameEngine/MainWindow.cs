using OpenTK;
using OpenTK.Graphics;
using OpenTK.Input;
using OpenTK.Graphics.OpenGL4;
using TreasureGameLib.Environment.GameMap;
using TreasureGameLib.Environment.Walls;

namespace VerovkinGameEngine
{
    public partial class MainWindow : GameWindow
    {
        private readonly float[] _vertices =
        {
            -0.5f, -0.5f, 0.0f, // Bottom-left vertex
             0.5f, -0.5f, 0.0f, // Bottom-right vertex
             0.0f,  0.5f, 0.0f  // Top vertex
        };

        private float[] _playerVertices =
        {
            -0.5f, -0.5f, 0.0f,
            -0.5f,  0.5f, 0.0f,
             0.5f,  0.5f, 0.0f,
             0.5f, 0.5f, 0.0f,
             0.5f, -0.5f, 0.0f,
             -0.5f, -0.5f, 0.0f
        };

        private int _vertexBufferObject;
        private int _vertexArrayObject;
        private Shader _shader;

        public MainWindow(int width, int height, string title)
            : base(width, height, GraphicsMode.Default, title, GameWindowFlags.Default, DisplayDevice.Default)
        {
            Title += "GL ver:" + GL.GetString(StringName.Version);
            Load += MainWindow_Load;
            KeyDown += MainWindow_KeyDown;
            RenderFrame += MainWindow_RenderFrame;
            Unload += MainWindow_Unload;
            Resize += MainWindow_Resize;
        }
        private void MainWindow_Load(object sender, System.EventArgs e)
        {
            GL.ClearColor(0.2f, 0.3f, 0.3f, 1.0f);
            _vertexBufferObject = GL.GenBuffer();
            GL.BindBuffer(BufferTarget.ArrayBuffer, _vertexBufferObject);
            GL.BufferData(BufferTarget.ArrayBuffer, _playerVertices.Length * sizeof(float), _playerVertices, BufferUsageHint.DynamicDraw);

            _vertexArrayObject = GL.GenVertexArray();
            GL.BindVertexArray(_vertexArrayObject);

            GL.VertexAttribPointer(0, 3, VertexAttribPointerType.Float, false, 0, 0);

            GL.EnableVertexAttribArray(0);

            _shader = new Shader("shader.vert", "shader.frag");

            _shader.Use();
        }

        /*
        private void MainWindow_Load(object sender, System.EventArgs e)
        {
            GL.ClearColor(0.2f, 0.3f, 0.3f, 1.0f);

            _vertexBufferObject = GL.GenBuffer();
            GL.BindBuffer(BufferTarget.ArrayBuffer, _vertexBufferObject);

            GL.BufferData(BufferTarget.ArrayBuffer, _vertices.Length * sizeof(float), _vertices, BufferUsageHint.StaticDraw);

            _vertexArrayObject = GL.GenVertexArray();
            GL.BindVertexArray(_vertexArrayObject);

            GL.VertexAttribPointer(0, 3, VertexAttribPointerType.Float, false, 3 * sizeof(float), 0);

            GL.EnableVertexAttribArray(0);

            _shader = new Shader("shader.vert", "shader.frag");

            _shader.Use();
        }
        */

        private void MainWindow_KeyDown(object sender, KeyboardKeyEventArgs e)
        {
            if (e.Key == Key.Escape) Exit();
            else if (e.Key == Key.W)
            {
                MatrPlus(0.1f);
                GL.BufferData(BufferTarget.ArrayBuffer, _playerVertices.Length * sizeof(float), _playerVertices, BufferUsageHint.DynamicDraw);
            }
        }

        private void MatrPlus(float number)
        {
            for (int i = 0; i < _playerVertices.Length; i++)
            {
                _playerVertices[i] += number;
            }
        }

        private void MainWindow_RenderFrame(object sender, FrameEventArgs e)
        {
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
            
            _shader.Use();
            GL.DrawArrays(PrimitiveType.Triangles, 0, 6);
            SwapBuffers();
        }

        private void MainWindow_Resize(object sender, System.EventArgs e)
        {
            GL.Viewport(0, 0, Width, Height);
        }

        private void MainWindow_Unload(object sender, System.EventArgs e)
        {
            GL.BindBuffer(BufferTarget.ArrayBuffer, 0);
            GL.BindVertexArray(0);
            GL.UseProgram(0);

            GL.DeleteBuffer(_vertexBufferObject);
            GL.DeleteVertexArray(_vertexArrayObject);

            GL.DeleteProgram(_shader.Handle);
        }
    }
}
