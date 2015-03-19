using System;

class Circle : Shape
{
    // PROPERTIES

    public double Radius { get; private set; }

    // CONSTRUCTORS

    public Circle(double radius)
        : base(radius * 2, radius * 2)
    {
        this.Radius = radius;
    }

    // METHODS

    public override double CalculateSurface()
    {
        return Math.PI * Radius * Radius;
    }

    public override string ToString()
    {
        return string.Format("Circle: r={0} S={1:0.000}", Radius, CalculateSurface());
    }
}