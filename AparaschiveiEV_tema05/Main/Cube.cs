using OpenTK;
using OpenTK.Graphics.OpenGL;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace Main
{
    class Cube
    {
        private bool visibility;
        private bool isGravityBound;
        private Color colour;
        private const int SIZE_OFFSET = 5; // Dimensiunea cubului
        private const int GRAVITY_OFFSET = 1;
        private List<Vector3> vertices;
        private List<Color> faceColors;

        public Cube()
        {
            visibility = true;
            colour = RandomColor();

            vertices = new List<Vector3>
        {
            new Vector3(-0.5f, -0.5f, -0.5f), // colțul 1
            new Vector3(0.5f, -0.5f, -0.5f),  // colțul 2
            new Vector3(0.5f, 0.5f, -0.5f),   // colțul 3
            new Vector3(-0.5f, 0.5f, -0.5f),  // colțul 4
            new Vector3(-0.5f, -0.5f, 0.5f),  // colțul 5
            new Vector3(0.5f, -0.5f, 0.5f),   // colțul 6
            new Vector3(0.5f, 0.5f, 0.5f),    // colțul 7
            new Vector3(-0.5f, 0.5f, 0.5f)    // colțul 8
        };
            faceColors = new List<Color>
        {
            RandomColor(), // Fața din față
            RandomColor(), // Fața din spate
            RandomColor(), // Fața de sus
            RandomColor(), // Fața de jos
            RandomColor(), // Fața din stânga
            RandomColor()  // Fața din dreapta
        };
        }

        private Color RandomColor()
        {
            Random rand = new Random();
            return Color.FromArgb(rand.Next(256), rand.Next(256), rand.Next(256));
        }

        public void Draw()
        {
           
                GL.Color3(colour); // Setăm culoarea cubului

                GL.Begin(PrimitiveType.Quads);

            // Fața din față
            GL.Color3(faceColors[0]);
            GL.Vertex3(vertices[0]);
            GL.Vertex3(vertices[1]);
            GL.Vertex3(vertices[2]);
            GL.Vertex3(vertices[3]);

            // Fața din spate
            GL.Color3(faceColors[1]);
            GL.Vertex3(vertices[4]);
            GL.Vertex3(vertices[5]);
            GL.Vertex3(vertices[6]);
            GL.Vertex3(vertices[7]);

            // Fața de sus
            GL.Color3(faceColors[2]);
            GL.Vertex3(vertices[3]);
            GL.Vertex3(vertices[2]);
            GL.Vertex3(vertices[6]);
            GL.Vertex3(vertices[7]);

            // Fața de jos
            GL.Color3(faceColors[3]);
            GL.Vertex3(vertices[0]);
            GL.Vertex3(vertices[1]);
            GL.Vertex3(vertices[5]);
            GL.Vertex3(vertices[4]);

            // Fața din stânga
            GL.Color3(faceColors[4]);
            GL.Vertex3(vertices[0]);
            GL.Vertex3(vertices[3]);
            GL.Vertex3(vertices[7]);
            GL.Vertex3(vertices[4]);

            // Fața din dreapta
            GL.Color3(faceColors[5]);
            GL.Vertex3(vertices[1]);
            GL.Vertex3(vertices[2]);
            GL.Vertex3(vertices[6]);
            GL.Vertex3(vertices[5]);

            GL.End();
           
        }

        public void ChangeFaceColor(int faceIndex)
        {
            if (faceIndex >= 0 && faceIndex < faceColors.Count)
            {
                faceColors[faceIndex] = RandomColor(); // Schimbă culoarea feței respective
            }
        }

    }
}
