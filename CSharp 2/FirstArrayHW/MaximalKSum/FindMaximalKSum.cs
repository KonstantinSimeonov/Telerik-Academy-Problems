/*
Problem 6. Maximal K sum

Write a program that reads two integer numbers N and K and an array of N elements from the console.
Find in the array those K elements that have maximal sum.
*/

using System;

class FindMaximalKSum
{
    static void SelectionSort(int[] numbers)
    {
        for (int i = 0; i < numbers.Length - 1; i++)
        {
            for (int j = i + 1; j < numbers.Length; j++)
            {
                if (numbers[i] > numbers[j])
                {
                    int tmp = numbers[i];
                    numbers[i] = numbers[j];
                    numbers[j] = tmp;
                }
            }
        }
    }
    static void Main()
    {
        Console.Write("Please enter a integer number N: ");
        int n = Int32.Parse(Console.ReadLine());

        Console.Write("Please enter a integer K (0 < k < n): ");
        int k = Int32.Parse(Console.ReadLine());

        int[] numbers = new int[n];
        int sum = 0;

        Console.WriteLine("Now enter the elements of your array: ");

        // Reads an array of N elements from the console
        for (int i = 0; i < numbers.Length; i++)
        {
            Console.Write("element [{0}] = ", i);
            numbers[i] = Int32.Parse(Console.ReadLine());
        }

        // Sorting the array with selection sort 
        SelectionSort(numbers);

        Console.Write("The elements that have maximal sum are: ");

        // Calculate the maximal sum
        for (int i = numbers.Length - 1; i > numbers.Length - 1 - k; i--)
        {
            sum += numbers[i];
            Console.Write(numbers[i]);

            if (i != numbers.Length - 1 - k)
            {
                Console.Write(", ");
            }
        }

        Console.WriteLine("and their sum is {0}", sum);
    }
}

