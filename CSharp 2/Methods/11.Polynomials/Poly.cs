using System;

class Poly
{
    private double[] poly; // hold coeffs here

    /// <summary>
    /// Creates a poly from an array of doubles.
    /// </summary>
    /// <param name="coeffs"></param>
    public Poly(double[] coeffs)
    {
        poly = (double[])coeffs.Clone();
    }

    /// <summary>
    /// Clones the parameter poly into a new poly.
    /// </summary>
    /// <param name="p"></param>
    public Poly(Poly p)
    {
        poly = (double[])p.poly.Clone();
    }

    public int Power
    {
        get
        {
            return poly.Length - 1;
        }
    }

    // addition
    public static Poly operator +(Poly lhs, Poly rhs)
    {
        Poly p = new Poly(lhs.Power > rhs.Power ? lhs : rhs);
        int smallerPower = lhs.Power > rhs.Power ? rhs.Power : lhs.Power;

        for (int i = 0; i <= smallerPower; i++)
        {
            p.poly[i] = lhs.poly[i] + rhs.poly[i];
        }

        return p;
    }

    // subtraction
    public static Poly operator -(Poly lhs, Poly rhs)
    {
        Poly p = new Poly(lhs.Power > rhs.Power ? lhs : rhs);
        int smallerPower = lhs.Power > rhs.Power ? rhs.Power : lhs.Power;

        for (int i = 0; i <= smallerPower; i++)
        {
            p.poly[i] = lhs.poly[i] - rhs.poly[i];
        }

        return p;
    }

    // printing (ugly)
    public void Print()
    {

        for (int i = this.Power; i > 0; i--)
        {
            string nextSign = poly[i - 1] <= 0 || poly[i - 1] == 1 ? "" : "+ ";
            if (poly[i] == 0)
            {
                Console.Write(nextSign);
                continue;
            }

            string coeff = poly[i] == 1 ? "" : poly[i].ToString();
            string pow = i == 1 ? "" : "^" + i;


            Console.Write("{0}x{1} {2}", coeff, pow, nextSign);
        }

        if (poly[0] != 0)
        {
            Console.Write(poly[0]);
        }

        Console.WriteLine();
    }



    public static Poly operator *(Poly lhs, Poly rhs)
    {
        Poly product = new Poly(new double[(lhs.Power + 1) * (rhs.Power + 1)]);

        for (int i = 0; i <= lhs.Power; i++)
        {
            for (int j = 0; j <= rhs.Power; j++)
            {
                product.poly[i + j] = lhs.poly[i] * rhs.poly[j];
            }
        }

        return product;
    }
}

class PolyAddition
{

    static void Main()
    {
        Poly test = new Poly(new double[] { 6,5, 0, 1 ,6});
        Poly test1 = new Poly(new double[] { 3, -4, -5 });
        test.Print();
        test1.Print();
        (test - test1).Print();
        (test + test1).Print();
        (test * test1).Print();
    }
}

