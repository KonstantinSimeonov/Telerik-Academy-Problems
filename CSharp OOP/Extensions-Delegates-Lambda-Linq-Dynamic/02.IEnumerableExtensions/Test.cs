using System;
using System.Text;
using IEnumerableExtensions;

class Test
{

    public static void Main()
    {
        var hardCodedNums = new int[] { 1, 6, -3, 4, 8, -10, 0, 15, -100 };
        var hardCodedNames = new string[] { "Pesho", "Gosho", "Tosho", "Ivan", "Penka" };

        Console.WriteLine("Min: {0}, {1}", hardCodedNames.MinElement(), hardCodedNums.MinElement());
        Console.WriteLine("Max: {0}, {1}", hardCodedNames.MaxElement(), hardCodedNums.MaxElement());
        Console.WriteLine("Average: {0}, {1}", hardCodedNames.AverageOf(x => x.Length), hardCodedNums.AverageOf(x => x));
        Console.WriteLine("Sum: {0}, {1}", hardCodedNames.SumElements(x => x), hardCodedNums.SumElements(x => x));

    }
}