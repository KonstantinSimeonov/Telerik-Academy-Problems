using System;

namespace Abstraction
{
    class Rectangle : IFigure
    {
        public double Width { get; private set; }

        public double Height { get; private set; }

        public Rectangle(double width, double height)
            : base()
        {
            this.Width = width;
            this.Height = height;
        }

        public double CalculatePerimeter()
        {
            var perimeter = 2 * (this.Width + this.Height);

            return perimeter;
        }

        public double CalculateSurface()
        {
            var surface = this.Width * this.Height;

            return surface;
        }
    }
}
