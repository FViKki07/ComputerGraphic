using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Lab8
{
    /*
    internal class Camera
    {

        public PointZ Position {  get; set; }
        public double Fi { get; set; }
        public double Theta { get; set; }
        public Transform Projection { get; set; }

        public PointZ Forward { get { return new PointZ(-Math.Sin(Fi), Math.Sin(Theta), -Math.Cos(Fi)); } }
        public PointZ Left { get { return new PointZ(-Math.Sin(Fi + Math.PI / 2), 0, -Math.Cos(Fi + Math.PI / 2)); } }
        public PointZ Up { get { return PointZ.CrossProduct(Forward, Left); } }
        public PointZ Right { get { return -Left; } }
        public PointZ Backward { get { return -Forward; } }
        public PointZ Down { get { return -Up; } }

        public Transform ViewProjection
        {
            get
            {
                return Transform.Translate(-Position)
                    * Transform.RotateY(-Fi)
                    * Transform.RotateX(-Theta)
                    * Projection;
            }
        }

        public Camera(PointZ position, double angleY, double angleX, Transform projection)
        {
            Position = position;
            Fi = angleY;
            Theta = angleX;
            Projection = projection;
        }
    }*/

    internal class Camera
    {

        public PointZ Position { get; set; }
        public double Rotation { get; set; }
        public PointZ forward { get; set; }
  
        public int Width { get; set; }
        public int Height { get; set; }
        public float alpha;
        public float AspectRatio;


        public Camera(PointZ Position, double Rotation, PointZ forward, int width, int height)
        { 
            
            this.Position = Position;
            if(Math.Abs(Rotation) < 90)
                this.Rotation = Rotation;
            this.forward = forward;

            this.Width = width;
            this.Height = height;
            this.AspectRatio = Width / (float)Height;
            this.alpha = 90;
        }
    }
}
