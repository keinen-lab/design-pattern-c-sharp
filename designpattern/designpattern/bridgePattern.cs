using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace designpattern
{

    // implementor
    interface IDrawingAPI
    {
        void DrawCircle(double x, double y, double radius);
    }

    // concrete implementor 1/2 
    class DrawingAPI1 : IDrawingAPI
    {
        public void DrawCircle(double x, double y, double radius)
        {
            Console.WriteLine("API1. Circle at {0}:{1} radius {2}", x, y, radius);
        }
    }

    // concrete implementor 2/2
    class DrawingAPI2 : IDrawingAPI
    {
        public void DrawCircle(double x, double y, double radius)
        {
            Console.WriteLine("API2. Circle at {0}:{1} radius {2}", x, y, radius);
        }
    }

    // Abstraction
    interface IShape
    {
        void Draw();
        void ResizeByPercentage(double pct);
    }

    // Refined Abstraction
    class CircleShape : IShape
    {
        private double x, y, radius;
        private IDrawingAPI drawingAPI;

        public CircleShape(double x, double y, double radius, IDrawingAPI drawingAPI)
        {
            this.x = x;
            this.y = y;
            this.radius = radius;
            this.drawingAPI = drawingAPI;
        }

        public void Draw()
        {
            drawingAPI.DrawCircle(x, y, radius);
        }

        public void ResizeByPercentage(double pct)
        {
            radius += pct;
        }
    }

    // client
    class bridgePattern
    {
        public static void Main(string[] args)
        {
            IShape[] shapes = new IShape[2];
            shapes[0] = new CircleShape(1, 2, 3, new DrawingAPI1());
            shapes[1] = new CircleShape(5, 7, 11, new DrawingAPI2());

            foreach(IShape shape in shapes)
            {
                shape.ResizeByPercentage(2.5);
                shape.Draw();
            }

            Console.ReadKey();
        }
    }
}
