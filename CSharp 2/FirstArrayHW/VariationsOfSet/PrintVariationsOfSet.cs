/*
Problem 20.* Variations of set

Write a program that reads two numbers N and K and generates all the variations of K elements from the set [1..N].
*/

using System;

class PrintVariationsOfSet
{
    static void GenerateVariations(int[] array, int index, int number)
    {
        if (index == array.Length)
        {
            PrintVariations(array);
        }
        else
        {
            for (int i = 1; i <= number; i++)
            {
                array[index] = i;
                GenerateVariations(array, index + 1, number);
            }
        }
    }

    static void PrintVariations(int[] array)
    {
        for (int i = 0; i < array.Length; i++)
        {
            Console.Write(array[i] + " ");
        }
        Console.WriteLine();
    }

    static void Main()
    {
        Console.Write("Please enter a number N: ");
        int number = Int32.Parse(Console.ReadLine());

        Console.Write("Please enter a number K: ");
        int element = Int32.Parse(Console.ReadLine());

        int[] array = new int[element];

        Console.WriteLine("All the variations of {0} elements from the set [1...{1}]:", element, number);
        GenerateVariations(array, 0, number);
    }
}

