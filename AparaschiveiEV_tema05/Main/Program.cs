using System;
using System.Drawing;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using OpenTK.Input;

namespace Main
{

    class Program
    {
        [STAThread]
        static void Main(string[] args) {

            using (Window3D example = new Window3D()) {
                example.Run(30.0, 0.0);
            }

        }
    }

}
