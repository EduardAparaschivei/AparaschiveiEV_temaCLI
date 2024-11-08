using System;
using System.Drawing;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using OpenTK.Input;
using System.IO;

namespace OpenTK_ChangeColor
{
    class ChangeColorApp : GameWindow
    {
        private float[] triangleVertices;
        private float[,] triangleColors; // Array pentru culorile RGB ale fiecărui vertex
        private float angle = 0f;

        public ChangeColorApp() : base(800, 600, new GraphicsMode(32, 24, 0, 8))
        {
            VSync = VSyncMode.On;
            Title = "Schimbă culoarea triunghiului";
        }

        // Încărcarea coordonatelor triunghiului și a culorilor din fișier
        private void LoadTriangleData()
        {
            string[] lines = File.ReadAllLines("triangle.txt");
            triangleVertices = new float[9]; 
            triangleColors = new float[3, 3]; 

            int i = 0;
            int colorIndex = 0;

            foreach (string line in lines)
            {
                string[] parts = line.Split(' ');
                if (i < 9)
                {
                    triangleVertices[i++] = float.Parse(parts[0]);
                    triangleVertices[i++] = float.Parse(parts[1]);
                    triangleVertices[i++] = float.Parse(parts[2]);
                }
                else
                {
                    triangleColors[colorIndex, 0] = float.Parse(parts[0]); 
                    triangleColors[colorIndex, 1] = float.Parse(parts[1]); 
                    triangleColors[colorIndex, 2] = float.Parse(parts[2]); 
                    colorIndex++;
                }
            }
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            LoadTriangleData();

            GL.ClearColor(Color.CornflowerBlue);
            GL.Enable(EnableCap.DepthTest);
            GL.Enable(EnableCap.Blend);
            GL.BlendFunc((BlendingFactor)BlendingFactorSrc.SrcAlpha, (BlendingFactor)BlendingFactorDest.OneMinusSrcAlpha);
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            GL.Viewport(0, 0, Width, Height);

            double aspect_ratio = Width / (double)Height;
            Matrix4 perspective = Matrix4.CreatePerspectiveFieldOfView(MathHelper.PiOver4, (float)aspect_ratio, 1, 64);
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadMatrix(ref perspective);

            Matrix4 lookat = Matrix4.LookAt(3, 3, 3, 0, 0, 0, 0, 1, 0);
            GL.MatrixMode(MatrixMode.Modelview);
            GL.LoadMatrix(ref lookat);
        }

        protected override void OnUpdateFrame(FrameEventArgs e)
        {
            base.OnUpdateFrame(e);

            KeyboardState keyboard = Keyboard.GetState();
            MouseState mouse = Mouse.GetState();

            // Modificarea unghiului camerei cu ajutorul mouse-ului
            if (mouse[MouseButton.Left])
            {
                angle += 0.1f;
            }


        }

        protected override void OnRenderFrame(FrameEventArgs e)
        {
            base.OnRenderFrame(e);

            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

            GL.PushMatrix();
            GL.Rotate(angle, 0.0f, 1.0f, 0.0f);  // Rotirea triunghiului pe axa Y

            GL.Begin(PrimitiveType.Triangles);

            // Desenarea triunghiului cu culori pentru fiecare vertex
            for (int i = 0; i < 3; i++)
            {
                // Setează culoarea pentru fiecare vertex
                GL.Color3(triangleColors[i, 0], triangleColors[i, 1], triangleColors[i, 2]);
                GL.Vertex3(triangleVertices[i * 3], triangleVertices[i * 3 + 1], triangleVertices[i * 3 + 2]);

                // Afișează valorile RGB pentru fiecare vertex în consolă
                Console.WriteLine($"Vertex {i + 1}: RGB = ({triangleColors[i, 0]}, {triangleColors[i, 1]}, {triangleColors[i, 2]})");
            }

            GL.End();
            GL.PopMatrix();

            SwapBuffers();
        }

        [STAThread]
        static void Main(string[] args)
        {
            using (ChangeColorApp app = new ChangeColorApp())
            {
                app.Run(30.0, 0.0);
            }
        }
    }
}
