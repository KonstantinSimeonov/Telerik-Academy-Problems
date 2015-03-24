/*Problem 13.* Merge sort

Write a program that sorts an array of integers using the Merge sort algorithm.*/

using System;

class MergeSortAlgorithm
{
    static void MergeSorting(int[] array, int [] temp, int start, int end)
    {
        if (start >= end)
        {
            return;
        }

        int middle =  start + (end - start) / 2;

        MergeSorting(array, temp, start, middle);
        MergeSorting(array, temp, middle + 1, end);
        CompareAndSorting(array, temp, start, middle, end);
    }

    static void CompareAndSorting(int[] array, int[] temp, int start, int middle, int end)
    {
        // int[] temp index:
        int k = start;
        
        // int[] array indexes
        int j = start;
        int i = middle + 1;

        while (j <= middle && i <= end) // while (start <= middle) and (middle + 1 <= end)
        {
            if (array[j] > array[i]) // array[start] > array[middle + 1]
            {
                temp[k++] = array[i++]; // temp[start++] = array[(middle + 1)++]
            }
            else
            {
                temp[k++] = array[j++]; // temp[start++] = array[start++]
            }
        }

        while (j <= middle)
        {
            temp[k++] = array[j++]; // temp[start++] = array[start++]
        }

        while (i <= end)
        {
            temp[k++] = array[i++]; // temp[start++] = array[(middle + 1)++]
        }

        for (int p = start; p <= end; p++)
        {
            array[p] = temp[p];
        }
    }
    static void Main()
    {
        Console.Write("Please enter the length of your array: ");
        int length = Int32.Parse(Console.ReadLine());

        int[] array = new int[length];

        Console.WriteLine("Enter the elements of your array: ");

        for (int i = 0; i < array.Length; i++)
        {
            Console.Write("Element[{0}] = ", i);
            array[i] = Int32.Parse(Console.ReadLine());
        }

        Console.WriteLine(new string ('-', 50));

        //Print the unsorted array
        Console.WriteLine("Your array before the sorting: {0}", string.Join(", ", array));

        Console.WriteLine(new string ('-', 50));

        int[] temp = new int[length];

        // Sorting the array with Merge Sort
        MergeSorting(array, temp, 0, array.Length - 1);

        // Print the sorted array
        Console.WriteLine("Your array after the sorting: {0}", string.Join(", ", array));


    }
}

