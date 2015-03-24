using System;

//Problem 9. Sorting array

//Write a method that return the maximal element in a portion of array of integers starting at given index.
//Using it write another method that sorts an array in ascending / descending order.

class Sorter
{
    public static int MaxInRange(int[] sequence, int left, int right)
    {
        int max = int.MinValue;
        for (int i = left; i <= right; i++)
        {
            if (max < sequence[i])
            {
                max = sequence[i];
            }
        }
        return max;
    }

    public static void BubbleSort(int[] arr)
    {
        bool hasSwapped = true;

        while (hasSwapped)
        {
            hasSwapped = false;
            for (int i = 0; i < arr.Length - 1; i++)
            {
                if (MaxInRange(arr, i, i + 1) != arr[i])
                {
                    arr[i] ^= arr[i + 1];
                    arr[i + 1] ^= arr[i];
                    arr[i] ^= arr[i + 1];
                    hasSwapped = true;
                }
            }
        }
    }

    static void Main()
    {
        int[] kkgay = { 2, 5, 3, -6, 4, 10, 10, 1 };
        BubbleSort(kkgay);
        Console.WriteLine(string.Join(", ", kkgay));
    }
}

