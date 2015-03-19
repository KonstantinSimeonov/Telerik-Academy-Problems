class Rectangle : Shape
{
    // CONSTRUCTORS

    public Rectangle(double width, double height)
        : base(width, height)
    {  }

    // METHODS

    public override double CalculateSurface()
    {
        return Width * Height;
    }

    public override string ToString()
    {
        return string.Format("Rectangle: w={0} h={1} S={2:0.000}", Width, Height, CalculateSurface());
    }
}