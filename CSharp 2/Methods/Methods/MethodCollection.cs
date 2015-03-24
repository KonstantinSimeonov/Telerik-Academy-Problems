using System;

// Problems 1-7. Don't hate me, they're small methods, a project for each problem would be an overkill

class MethodCollection
{
    /// <summary>
    ///Problem 1. Say Hello
    ///
    ///Write a method that asks the user for his name and prints “Hello, "name"”.
    ///Write a program to test this method.
    /// </summary>
    public static void SayHello()
    {
        Console.WriteLine("Whats yo name:");
        Console.WriteLine("Hello, {0}", Console.ReadLine());
    }




    /// <summary>
    /// Problem 2. Get largest number
    /// 
    ///Write a method GetMax() with two parameters that returns the larger of two integers.
    ///Write a program that reads 3 integers from the console and prints the largest of them using the method GetMax().
    /// </summary>
    /// <param name="a"></param>
    /// <param name="b"></param>
    /// <returns></returns>
    public static double getMax(double a, double b)
    {
        return a > b ? a : b;
    }

    /// <summary>
    /// Prints the larget of three numbers using the getMax() method.
    /// </summary>
    /// <param name="a"></param>
    /// <param name="b"></param>
    /// <param name="c"></param>
    public static void PrintLargest(double a, double b, double c)
    {
        double bigger = getMax(a, b);
        Console.WriteLine(getMax(bigger, c));
    }





    /// <summary>
    /// Problem 3. English digit
    /// 
    ///Write a method that returns the last digit of given integer as an English word.
    /// </summary>
    /// <param name="number"></param>
    /// <returns></returns>
    public static string LastDigitToString(int number)
    {
        switch (number % 10)
        {
            case 0: return "zero";
            case 1: return "one";
            case 2: return "two";
            case 3: return "three";
            case 4: return "four";
            case 5: return "five";
            case 6: return "six";
            case 7: return "seven";
            case 8: return "eight";
            case 9: return "nine";
            default: return "";
        }
    }





    /// <summary>
    /// Used by the recursive function to store appereance(Problem 4).
    /// </summary>
    public static int appereanceCount = 0; // before calling the recursive function, make sure it's set to 0!

    /// <summary>
    /// Problem 4. Appearance count
    /// 
    ///Write a method that counts how many times given number appears in given array.
    ///Write a test program to check if the method is workings correctly.
    /// </summary>
    /// <param name="k"></param>
    /// <param name="index"></param>
    /// <param name="arr"></param>
    /// <returns></returns>
    private static int GetAppereanceCount(int k, int index, int[] arr) // Don't use this, use the test function below!
    {
        if (index == arr.Length)
        {
            return appereanceCount;
        }
        else
        {
            if (arr[index] == k)
            {
                return GetAppereanceCount(k, index + 1, arr) + 1;
            }
            else
            {
                return GetAppereanceCount(k, index + 1, arr);
            }
        }
    }

    /// <summary>
    /// Test the recursive function for problem 4 with user-defined input.
    /// </summary>
    /// <param name="k"></param>
    /// <param name="arr"></param>
    public static void testProblem4(int k, int[] arr)
    {
        Console.WriteLine(GetAppereanceCount(k, 0, arr));
        appereanceCount = 0;
    }


    /// <summary>
    /// Problem 5. Larger than neighbours:
    /// 
    /// Write a method that checks if the element at given position
    /// in given array of integers is larger than its two neighbours (when such exist).
    /// </summary>
    /// <param name="pos"></param>
    /// <param name="arr"></param>
    /// <returns></returns>
    public static bool IsLargerThanNeighbors(int pos, int[] arr)
    {
        bool largerThanLeft = false;

        if (pos > 0)
        {
            largerThanLeft = arr[pos] > arr[pos - 1];
        }
        else if (pos == 0)
        {
            largerThanLeft = true;
        }

        bool largerThanRight = false;

        if (pos < arr.Length - 1)
        {
            largerThanRight = arr[pos] > arr[pos + 1];
        }
        else if (pos == arr.Length - 1)
        {
            largerThanRight = true;
        }

        return largerThanLeft && largerThanRight;

    }



    /// <summary>
    /// Problem 6. First larger than neighbours:
    ///
    ///Write a method that returns the index of the first element
    ///in array that is larger than its neighbours, or -1, if there’s no such element.
    ///
    /// </summary>
    /// <param name="arr"></param>
    /// <returns></returns>
    public static int FirstLargerThanNeighbors(int[] arr)
    {
        int index = -1;
        for (int i = 0; i < arr.Length; i++)
        {
            if (IsLargerThanNeighbors(i, arr))
            {
                index = i;
                break;
            }
        }
        return index;
    }


    /// <summary>
    /// Problem 7. Reverse number

    ///Write a method that reverses the digits of given decimal number.
    /// </summary>
    /// <param name="number"></param>
    public static void ReverseNumber(decimal number)
    {
        Console.Write(number > 0 ? "" : "-"); // the sign stays at the front

        number = number >= 0 ? number : -number; // make the number positive

        recReverseString(number.ToString(), number.ToString().Length - 1); // use recursion for shitz and giggles
    }

    /// <summary>
    /// Recursive function which prints a reversed string.
    /// </summary>
    /// <param name="str"></param>
    /// <param name="last"></param>
    private static void recReverseString(string str, int last)
    {
        // if no more elements to print
        if (last < 0)
        {
            return;
        }
        else
        {
            // print the string starting from the last element
            Console.Write(str[last]);
            // recursive call, which will print the element before the last
            recReverseString(str, last - 1);
        }
    }




    static void Main()
    {
        //SayHello();
        //Console.WriteLine();
        // max number
        Console.WriteLine(getMax(2, 3) + " " + getMax(1, 1) + " " + getMax(-6, -7));
        Console.WriteLine();

        // largest of three
        PrintLargest(-3, -2, -5);
        Console.WriteLine();

        // appereance count
        testProblem4(99, new int[] { 5, -5, 99, -99, 8, 16, -2, -3, 99, 99, 98, 199, 99 });
        Console.WriteLine();

        // larger than neighbors
        int[] test = { -1, 2, 3, 4, -15, 18, -18, 22, 34, -33 };
        Console.WriteLine(IsLargerThanNeighbors(3, test) + " " + IsLargerThanNeighbors(4, test));
        Console.WriteLine();

        int index = FirstLargerThanNeighbors(test);
        Console.WriteLine(index >= 0 ? test[index].ToString() : "No such element");

        // revers digits
        decimal dec = (decimal)-12345.0678;
        Console.WriteLine(dec);
        ReverseNumber(dec);
    }
}

