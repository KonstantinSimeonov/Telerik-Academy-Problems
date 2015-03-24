using System;

//Problem 2. Enter numbers

//Write a method ReadNumber(int start, int end) that enters an integer number in a given range [start…end].
//If an invalid number or non-number text is entered, the method should throw an exception.
//Using this method write a program that enters 10 numbers: a1, a2, … a10, such that 1 < a1 < … < a10 < 100

class EnterNumbers
{

    public static bool increase;

    public static int ReadNumber(int last)
    {
        increase = true;

        int number = 0;
        try
        {
            number = int.Parse(Console.ReadLine());

            if (number >= 100 || number <= 1)
            {
                throw new OutOfRangeException();
            }

            if (number <= last)
            {
                throw new NotIncreasingException();
            }

        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            increase = false;
        }


        return number;
    }
    static void Main()
    {
        int magicNumber = 10;
        int[] arr = new int[magicNumber];

        Console.WriteLine("Enter an increasing sequence of number that follows the rule 1 < a1 < a2 < ... < 100");

        for (int i = 0; i < magicNumber; i += increase ? 1 : 0)
        {
            Console.Write("N[{0}]=", i);
            arr[i] = ReadNumber(i > 0 ? arr[i - 1] : 1);
        }

        Console.WriteLine(string.Join(",", arr));
    }
}

