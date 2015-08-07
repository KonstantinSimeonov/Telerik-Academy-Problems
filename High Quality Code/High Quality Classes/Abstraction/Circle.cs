namespace Abstraction
{
    using System;

    public class Circle : IFigure
    {
        public double Radius { get; private set; }

        public Circle(double radius)
            : base()
        {
            this.Radius = radius;
        }

        public double CalculatePerimeter()
        {
            var perimeter = 2 * Math.PI * this.Radius;

            return perimeter;
        }

        public double CalculateSurface()
        {
            var surface = Math.PI * this.Radius * this.Radius;

            return surface;
        }
    }
}
