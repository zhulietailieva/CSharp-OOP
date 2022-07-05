using System;
using System.Collections.Generic;
using System.Text;

namespace StartUp
{
    public class Box
    {
        public Box(double length,double width,double height)
        {
            if (length <= 0) throw new ArgumentException("Length cannot be zero or negative.");
            if(width <= 0 ) throw new ArgumentException("Width cannot be zero or negative.");
            if (height <= 0) throw new ArgumentException("Height cannot be zero or negative.");
            this.Length = length;
            this.Width = width;
            this.Height = height;

        }
        public double Length { get;private set; }
        public double Width { get;private set; }
        public double Height { get;private set; }
        public double SurfaceArea()
        {
            return 2 * Length * Width + 2 * Length * Height + 2 * Width * Height;
        }
        public double LateralSurfaceArea()
        {
            return 2 * Length * Height + 2 * Width * Height;
        }
        public double Voulume()
        {
            return Length * Width * Height;
        }
    }
}
