using System;

/// <summary>
/// Abstract class Shape with only one abstract method CalculateSurface() and fields width and height.
/// </summary>
abstract class Shape
{
    // FIELDS

    private double width, height;

    // PROPERTIES

    public double Width
    {
        get
        {
            return width;
        }

        private set
        {
            try
            {
                width = value;
            }
            catch(Exception e)
            {
                Console.WriteLine(e.StackTrace);
                Console.WriteLine("Value that cause the exception: {0}", value);
            }
            
        }
    }

    public double Height
    {
        get
        {
            return height;
        }

        private set
        {
            try
            {
                height = value;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                Console.WriteLine("Value that cause the exception: {0}", value);
            }

        }
    }

    // CONSTRUCTORS

    public Shape(double width, double height)
    {
        this.Width = width;
        this.Height = height;
    }

    // METHODS

    public abstract double CalculateSurface();
}