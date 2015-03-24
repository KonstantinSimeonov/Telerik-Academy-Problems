class Triangle : Shape
{
    // CONSTRUCTORS

    public Triangle(double width, double height)
        : base(width, height)
    { }

    // METHODS

    public override double CalculateSurface()
    {
        return Height * Width / 2;
    }

    public override string ToString()
    {
        return string.Format("Triangle: w={0} h={1} S={2:0.000}", Width, Height, CalculateSurface());
    }
}