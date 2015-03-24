/*
Problem 11. Binary search

Write a program that finds the index of given element in a sorted array of integers by using the Binary search algorithm.
*/

using System;

class BinarySearchAlgorithm
{
    static void SelectionSorting(int[] array)
    {
        for (int i = 0; i < array.Length - 1; i++)
        {
            for (int j = i + 1; j < array.Length; j++)
            {
                if (array[i] > array[j])
                {
                    int saver = array[i];
                    array[i] = array[j];
                    array[j] = saver;
                }
            }
        }
    }

    static int BinarySearch(int[] sequence, int element, int min, int max)
    {
        while(max >= min)
        {
            int middle = (min + max) / 2;

            if (sequence[middle] == element)
            {
                return middle;
            }
            else if (sequence[middle] < element)
            {
                min = middle + 1;
            }
            else
            {
                max = middle - 1;
            }//1 2 3 4 5 6 7 -1
        }
        int message = -1;
        return message;
    }

    static void Main()
    {
        Console.WriteLine("Please enter your sequence of numbers: ");
        string text = Console.ReadLine();

        Console.Write("Please enter the element which index you want to find: ");
        int element = Int32.Parse(Console.ReadLine());

        string[] numberArray = text.Split(new char[] { ',', ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);

        int[] sequence = new int[numberArray.Length];

        // Parsing the elements from the string array
        for (int i = 0; i < sequence.Length; i++)
        {
            sequence[i] = Int32.Parse(numberArray[i].ToString());
        }

        // Selection sort algorithm
        SelectionSorting(sequence);

        int min = 0;
        int max = sequence.Length - 1;
        int middle = (min + max) / 2;

        // Finding the element using Binary Search
        int index = BinarySearch(sequence, element, min, max);

        if (index == -1)
        {
            Console.WriteLine("Your element doesn't exist in the array.");
        }
        else
        {
            Console.WriteLine("The index of your element is {0}", index);
        }
        Console.WriteLine();
    }
}

