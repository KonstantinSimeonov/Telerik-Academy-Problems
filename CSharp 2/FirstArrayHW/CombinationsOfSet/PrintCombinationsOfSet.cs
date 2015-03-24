/*
Problem 21.* Combinations of set

Write a program that reads two numbers N and K and generates all the combinations of K distinct elements from the set [1..N].
*/

using System;

class PrintCombinationsOfSet
{
    static void GenerateCombinations(int[] array, int index, int number, int currentNumber)
    {
        if (index == array.Length)
        {
            PrintCombinations(array);
        }
        else
        {
            for (int i = currentNumber; i <= number; i++)
            {
                array[index] = i;
                GenerateCombinations(array, index + 1, number, i + 1);
            }
        }
    }
    static void PrintCombinations(int[] array)
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

        Console.WriteLine("All the combinations of {0} distinct elements from the set [1...{1}]:", element, number);
        GenerateCombinations(array, 0, number, 1);
    }
}

