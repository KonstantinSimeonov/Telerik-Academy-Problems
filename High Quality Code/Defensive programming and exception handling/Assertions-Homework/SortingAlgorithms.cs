using System;
using System.Collections.Generic;
using System.Diagnostics;

public class SortingAlgorithms
{
    public static void SelectionSort<T>(T[] arr) where T : IComparable<T>
    {
        Debug.Assert(arr != null, "The array was null");
        Debug.Assert(arr.Length > 0, "Length was less than or equal to zero.");

        for (int index = 0; index < arr.Length - 1; index++)
        {
            int minElementIndex = FindMinElementIndex(arr, index, arr.Length - 1);
            Swap(ref arr[index], ref arr[minElementIndex]);
        }

        Debug.Assert(AssertionUtilities.IsSortedByAscending(arr), "The array is not sorted");
    }

    private static int FindMinElementIndex<T>(T[] arr, int startIndex, int endIndex)
        where T : IComparable<T>
    {
        Debug.Assert(0 <= startIndex && startIndex < arr.Length, "Starting index was out of the array boundaries.");
        Debug.Assert(0 <= endIndex && endIndex < arr.Length, "End index was out of the array boundaries.");
        Debug.Assert(startIndex <= endIndex, "Starting index was larger than end index");

        int minElementIndex = startIndex;
        for (int i = startIndex + 1; i <= endIndex; i++)
        {
            if (arr[i].CompareTo(arr[minElementIndex]) < 0)
            {
                minElementIndex = i;
            }
        }

        Debug.Assert(AssertionUtilities.IsMinElementIn(arr[minElementIndex], arr, startIndex, endIndex), "The result of find minimal element index was not the minimal element index");

        return minElementIndex;
    }

    private static void Swap<T>(ref T x, ref T y)
    {
        // i should also assert this but i'm lazy
        T oldX = x;
        x = y;
        y = oldX;
    }
}