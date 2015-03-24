/*
Problem 2. Compare arrays

Write a program that reads two integer arrays from the console and compares them element by element.
*/

using System;

class CompareTwoArrays
{
    static void CompareElements(int[] arrayOne, int[] arrayTwo)
    {
        for (int index = 0; index < arrayOne.Length; index++)
        {
            if (arrayOne[index] == arrayTwo[index])
            {
                Console.WriteLine("The elements are equal: {0} = {1}", arrayOne[index], arrayTwo[index]);
            }
            else
            {
                Console.WriteLine("The elements are not equal: {0} != {1}", arrayOne[index], arrayTwo[index]);
            }
        }
    }

    static void Main()
    {
        Console.Write("Please enter positive number for the length of your arrays: ");
        int number = Int32.Parse(Console.ReadLine());

        while (number <= 0)
        {
            Console.Write("Please enter a positive number: ");
            number = Int32.Parse(Console.ReadLine());
        }

        int[] arrayOne = new int[number];
        int[] arrayTwo = new int[number];

        Console.WriteLine("Enter the elements of your first array: ");

        for (int index = 0; index < arrayOne.Length; index++)
        {
            Console.Write("element [{0}] = ", index);
            arrayOne[index] = Int32.Parse(Console.ReadLine());
        }

        Console.WriteLine(new string ('-', 20));

        Console.WriteLine("Enter the elements of your second array: ");

        for (int index = 0; index < arrayTwo.Length; index++)
        {
            Console.Write("element [{0}] = ", index);
            arrayTwo[index] = Int32.Parse(Console.ReadLine());
        }

        Console.WriteLine(new string('-', 20));

        CompareElements(arrayOne, arrayTwo); // Compare the elements
    }
}

