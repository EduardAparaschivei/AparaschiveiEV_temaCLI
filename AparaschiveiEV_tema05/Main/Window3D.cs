using System;
using System.Drawing;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using OpenTK.Input;

namespace Main
{
    internal class Window3D : GameWindow
    {
        private const float rotation_speed = 180.0f;
        private float angle;
        private bool showCube = true;
        private KeyboardState lastKeyPress;
        private Cube cube;
        private int transStep = 0;
        private int radStep = 0;
        private int attStep = 0;

        public Window3D() : base(800, 600, new GraphicsMode(32, 24, 0, 8)) { }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            // Setează culoarea de fundal și activarea testului de adâncime
            GL.ClearColor(Color.MidnightBlue);
            GL.Enable(EnableCap.DepthTest);  // Pentru a evita desenarea obiectelor din spatele altora

            // Setează perspectiva de proiecție
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadIdentity();
            Matrix4 projection = Matrix4.CreatePerspectiveFieldOfView(MathHelper.DegreesToRadians(45.0f), Width / (float)Height, 0.1f, 100f);
            GL.LoadMatrix(ref projection);

            // Schimbă la matricea modelului
            GL.MatrixMode(MatrixMode.Modelview);
            GL.LoadIdentity();

            // Crează cubul
            cube = new Cube();  // Setează dacă cubul va fi influențat de gravitație
            DisplayHelp();
        }

        protected override void OnUpdateFrame(FrameEventArgs e)
        {
            base.OnUpdateFrame(e);

            KeyboardState keyboard = Keyboard.GetState();

            if (keyboard[Key.Escape])
            {
                Exit();
                return;
            }
            if (keyboard[Key.Q])
            {
                cube.ChangeFaceColor(0);  // Schimbă culoarea feței 0 (fața din față)
            }
            if (keyboard[Key.W])
            {
                cube.ChangeFaceColor(1);// Schimbă culoarea feței 0 (fața din față)
            }
            if (keyboard[Key.E])
            {
                cube.ChangeFaceColor(2);  // Schimbă culoarea feței 0 (fața din față)
            }
            if (keyboard[Key.R])
            {
                cube.ChangeFaceColor(3);  // Schimbă culoarea feței 0 (fața din față)
            }
            if (keyboard[Key.T])
            {
                cube.ChangeFaceColor(4);// Schimbă culoarea feței 0 (fața din față)
            }
            if (keyboard[Key.Y])
            {
                cube.ChangeFaceColor(5);  // Schimbă culoarea feței 0 (fața din față)
            }

            lastKeyPress = keyboard;
        }

        protected override void OnRenderFrame(FrameEventArgs e)
        {
            base.OnRenderFrame(e);

            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);  // Curăță buffer-ul de culoare și de adâncime

            GL.LoadIdentity();  // Resetează matricea modelului

            // Aplicați o translație pentru a muta scena
            GL.Translate(0.0f, 0.0f, -5.0f);  // Mută scena pe axa Z pentru a nu fi prea aproape de cameră

            angle += rotation_speed * (float)e.Time;  // Crește unghiul de rotație în funcție de timpul între cadre
            if (angle >= 360.0f)
                angle -= 360.0f;  // Asigură-te că unghiul rămâne între 0 și 360 grade

            // Rotește pe axa X și Y
            GL.Rotate(angle, 1.0f, 1.0f, 0.0f);  // Rotație pe diagonala între X și Y

            // Poți aplica și o rotație pe axa Z pentru un efect complet pe diagonala
            GL.Rotate(angle, 1.0f, 0.0f, 1.0f);  // Rotește pe diagonala între X și Z

            cube.Draw();  // Desenează cubul
            

            SwapBuffers();  // Schimbă buffer-ele pentru a reda scena
        }
        private void DisplayHelp()
        {
            Console.WriteLine("\n      MENIU");
            Console.WriteLine("(Q...Y)  Schimba culoarea unei fete\n");
        }
    }
}