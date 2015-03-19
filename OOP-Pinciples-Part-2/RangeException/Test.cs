using System;

class Test
{
    public static int[] numbers = { 1, 2, 5, 13, 15, 60, -1, 20 };

    public static DateTime[] dates = { new DateTime(1992, 2, 3), new DateTime(1981, 12, 13), new DateTime(2012, 3, 8), new DateTime(2020, 12, 12)};

    public static void Main()
    {
        // INT

        try
        {
            int start = 1, end = 100;

            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] < start || numbers[i] > end)
                {
                    throw new InvalidRangeException<int>(1, 100, string.Format("The value which caused the exception was {0}. The range does not encompass all the values: ", numbers[i]));
                }

            }
        }
        catch (InvalidRangeException<int> e)
        {
            Console.WriteLine(e.message);
            Console.WriteLine(e.StackTrace);
        }
        
        // DATE

        try
        {
            var start = new DateTime(1980, 1, 1);
            var end = new DateTime(2013, 12, 31);

            for (int i = 0; i < dates.Length; i++)
            {
                if (dates[i] < start || dates[i] > end)
                {
                    throw new InvalidRangeException<DateTime>(start, end, string.Format("The given range doesn't encompass all values. Value which cause the exception: {0}", dates[i]));
                }
                

            }
        }
        catch(InvalidRangeException<DateTime> e)
        {
            Console.WriteLine(e.message);
            Console.WriteLine(e.StackTrace);
        }
    }
}