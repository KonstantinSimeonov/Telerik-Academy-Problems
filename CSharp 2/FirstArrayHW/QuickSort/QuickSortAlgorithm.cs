/*
Problem 14. Quick sort

Write a program that sorts an array of integers using the Quick sort algorithm.
*/

using System;
using System.Collections.Generic;

class QuickSortAlgorithm
{
    static List<int> QuickSortRecursive(List<int> elements)
    {

        if (elements.Count <= 1)
        {
            return elements;
        }

        int middlePosition = elements.Count / 2;
        int pivot = elements[middlePosition];

        elements.RemoveAt(middlePosition);

        List<int> less = new List<int>();
        List<int> greater = new List<int>();

        foreach (var element in elements)
        {
            if (element <= pivot)
            {
                less.Add(element);
            }
            else
            {
                greater.Add(element);
            }
        }

        return Concatenate(QuickSortRecursive(less), pivot, QuickSortRecursive(greater));
    }

    static List<int> Concatenate(List<int> less, int pivot, List<int> greater)
    {
        List<int> elements = new List<int>();
        for (int i = 0; i < less.Count; i++)
        {
            elements.Add(less[i]);
        }

        elements.Add(pivot);

        for (int i = 0; i < greater.Count; i++)
        {
            elements.Add(greater[i]);
        }
        return elements;
    }
    static void Main()
    {
        List<int> unsortedArray = new List<int>() { 87, 47, 1, 9882, 9, 15, 1044, 0, 387, -1, 4, 17, 6, 94, 21, 25, 66 };

        Console.WriteLine("The array before the Quick sort:");
        Console.WriteLine(string.Join(", ", unsortedArray));


        Console.WriteLine("The array after the Quick sort:");
        Console.WriteLine(string.Join(", ", QuickSortRecursive(unsortedArray)));

    }
}

