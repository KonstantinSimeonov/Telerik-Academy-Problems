using System;
using System.Diagnostics;

public class AssertionsHomework
{
    public static void Main()
    {
        Demo();
    }

    private static void Demo()
    {
        int[] arr = new int[] { 3, -1, 15, 4, 17, 2, 33, 0 };
        var arr2 = new int[] { 1, 2 };
        Console.WriteLine("arr = [{0}]", string.Join(", ", arr));
        SortingAlgorithms.SelectionSort(arr);
        Console.WriteLine("sorted = [{0}]", string.Join(", ", arr));

        // SortingAlgorithms.SelectionSort(new int[0]); // Test sorting empty array
        SortingAlgorithms.SelectionSort(new int[1]); // Test sorting single element array

        Console.WriteLine(SearchAlgorithms.BinarySearch(arr, -1000));
        Console.WriteLine(SearchAlgorithms.BinarySearch(arr, 0));
        Console.WriteLine(SearchAlgorithms.BinarySearch(arr, 17));
        Console.WriteLine(SearchAlgorithms.BinarySearch(arr, 10));
        Console.WriteLine(SearchAlgorithms.BinarySearch(arr, 1000));
    }
}