using System;


class Calcs
{
    public static dynamic Max(params dynamic[] sequence)
    {
        dynamic max = long.MinValue;
        foreach (var item in sequence)
        {
            if (item > max)
            {
                max = item;
            }
        }
        return max;
    }

    public static dynamic Min(params dynamic[] sequence)
    {
        dynamic max = long.MaxValue;
        foreach (var item in sequence)
        {
            if (item < max)
            {
                max = item;
            }
        }
        return max;
    }

    public static dynamic Sum(params dynamic[] sequence)
    {
        dynamic sum = 0;
        foreach (var item in sequence)
        {
            sum += item;
        }
        return sum;
    }

    public static dynamic Product(params dynamic[] sequence)
    {
        dynamic product = 1;
        foreach (var item in sequence)
        {
            product *= item;
        }
        return product;
    }

    public static dynamic Average(params dynamic[] sequence)
    {
        dynamic sum = 0;
        foreach (var item in sequence)
        {
            sum += item;
        }
        return (decimal)sum / (decimal)sequence.Length;
    }

}

class Test
{
    static void Main()
    {
        Console.WriteLine(Calcs.Max(1, 5.5, -3, 5, 6, 1, 1, 12.0, 12.1, 0, -9.9));
        Console.WriteLine(Calcs.Min(1, 5.5, -3, 5, 6, 1, 1, 12.0, 12.1, 0, -9.9));
        Console.WriteLine(Calcs.Sum(1, 5.5, -3, 5, 6, 1, 1, 12.0, 12.1, 0, -9.9));
        Console.WriteLine(Calcs.Product(1, 0.5, -3, 5, 6, 1, 0.1, 12.0, 12.1, 0.5, -9.9));
        Console.WriteLine(Calcs.Average(1, 5.5, -3, 5, 6, 1, 1, 12.0, 12.1, 0, -9.9));


    }
}

