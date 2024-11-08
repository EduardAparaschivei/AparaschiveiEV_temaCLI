using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;
using OpenTK.Graphics.OpenGL;
using OpenTK.Input;
using OpenTK.Platform;

namespace Eduard_Test
{
     class SimpleWindow : GameWindow
    {
        private float PosX = 0.0f;
        private float PosY = 0.0f;
        public SimpleWindow() : base(800, 600)
        {
          
        }

        protected override void OnLoad(EventArgs e)
        {
            GL.ClearColor(Color.MidnightBlue);
        }

        protected override void OnResize(EventArgs e)
        {
            GL.Viewport(0, 0, Width, Height);

            //transformările care urmează vor afecta matricea de modelare și vizualizare, nu matricea de proiecție.
            GL.MatrixMode(MatrixMode.Modelview);
            GL.LoadIdentity();
            GL.Ortho(-1.0, 1.0, -1.0, 1.0, 0.0, 4.0);
        }

        protected override void OnUpdateFrame(FrameEventArgs e)
        {
            //verificare apasare tasta sageata stanga
           if(Keyboard.GetState().IsKeyDown(Key.Left))
            {
                PosX -= 0.01f; //deplasare stanga
            }
           if(Keyboard.GetState().IsKeyDown(Key.Right))
            {
                PosX += 0.01f;//deplasare dreapta
            }
            if (Keyboard.GetState().IsKeyDown(Key.Down))
            {
                PosY -= 0.01f; //deplasare stanga
            }
            if (Keyboard.GetState().IsKeyDown(Key.Up))
            {
                PosY += 0.01f;//deplasare dreapta
            }
        }

        protected override void OnRenderFrame(FrameEventArgs e)
        {
            GL.Clear(ClearBufferMask.ColorBufferBit);

            GL.PushMatrix();//salvare matrice curenta

            //Se aplica transformarile
            GL.Translate(PosX, PosY, 0.0f);

            GL.Begin(PrimitiveType.Triangles);

            GL.Color3(Color.MidnightBlue);
            GL.Vertex2(-1.0f, 1.0f);
            GL.Color3(Color.SpringGreen);
            GL.Vertex2(0.0f, -1.0f);
            GL.Color3(Color.Ivory);
            GL.Vertex2(1.0f, 1.0f);

            GL.End();

            GL.PopMatrix();//Restaurare matrice

            this.SwapBuffers();
        }

        protected override void OnMouseMove(MouseMoveEventArgs e)
        {
            //Modificare pozitie pe verticala
            //Am pus '-' deoarece Y este inversat de OpenGL fata de coordonata Y a ferestrei
            PosY = -(float)e.Y / Height;
            PosX = (float)e.X / Width * 2.0f - 1.0f;
        }
        [STAThread]
        static void Main(string[] args)
        {
            using(SimpleWindow example = new SimpleWindow())
            {
                example.Run(30.0, 0.0);
            }
        }
     }
}
