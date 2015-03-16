using System;

struct Point3D
{
    // FIELDS

    private double x, y, z;
    private static readonly Point3D systemStart = new Point3D(0,0,0);

    // PROPERTIES

    public double X 
    {
        get
        {
            return x;
        }
        private set
        {
            x = value;
        }
    }

    public double Y
    {
        get
        {
            return y;
        }
        private set
        {
            y = value;
        }
    }

    public double Z
    {
        get
        {
            return z;
        }
        private set
        {
            z = value;
        }
    }

    /// <summary>
    /// Returns the start of the coordinate system.
    /// </summary>
    public static Point3D PointO
    {
        get
        {
            return systemStart;
        }
    }

    // CONSTRUCTORS

    public Point3D(double a, double b, double c)
    {
        x = a;
        y = b;
        z = c;
    }

    // METHODS

    public override string ToString()
    {
        return "{"+X+", "+Y+", "+Z+"}";
    }
}
