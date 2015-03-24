using System;

class Test
{
    public const int numberOfShapes = 10;

    public static double[] widths = { 1.2, 2.0, 3.5, 4, 18, 3.6, 8.9, 10 };
    public static double[] heights = { 2.5, 3.4, 0.2, 0.1, 0.15, 18.5, 10, 11 };

    public static Random vladoRandoma = new Random();

    static void Main()
    {
        var shapes = new Shape[numberOfShapes];

        for (int i = 0; i < shapes.Length; i++)
        {
            switch (vladoRandoma.Next() % 3)
            {
                case 0:
                    shapes[i] = new Triangle(widths[vladoRandoma.Next(0, widths.Length)],
                                                 heights[vladoRandoma.Next(0, heights.Length)]);
                    break;
                case 1: shapes[i] = new Rectangle(widths[vladoRandoma.Next(0, widths.Length)],
                                                 heights[vladoRandoma.Next(0, heights.Length)]);
                    break;
                case 2: shapes[i] = new Circle(heights[vladoRandoma.Next(0, heights.Length)]);
                    break;

                default:
                    break;
            }
        }

        foreach (var item in shapes)
        {
            Console.WriteLine(item.ToString().Replace(',', '.'));
        }
    }
}