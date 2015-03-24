/*
Problem 7. Selection sort

Sorting an array means to arrange its elements in increasing order. Write a program to sort an array.
Use the Selection sort algorithm: Find the smallest element, move it at the first position, find the smallest from the rest, 
move it at the second position, etc.
 */

using System;

class SelectionSortAlgorithm
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

    static void Main()
    {
        int[] array = { 748, 10, 1, 42, 13, 8, 37, 12, 9, 1022, 5, 51, 15, 10411, 37, 101, 21, 24, 25, 71, 78, 48, 855, 11 };

        Console.WriteLine("The array before the Selection sort: ");

        for (int i = 0; i < array.Length; i++)
        {
            Console.Write(array[i]);

            if (i != array.Length - 1)
            {
                Console.Write(", ");
            }
        }
        Console.WriteLine();

        // Selection sort algorithm
        SelectionSorting(array);

        // Priting the array after the Selection sort 
        Console.WriteLine("The array after the Selection sort: ");

        for (int i = 0; i < array.Length; i++)
        {
            Console.Write(array[i]);

            if (i != array.Length - 1)
            {
                Console.Write(", ");
            }
        }
        Console.WriteLine();
    }

}

