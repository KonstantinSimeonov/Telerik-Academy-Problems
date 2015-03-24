using System;
using System.Linq;

//Problem 4. Binary search

//Write a program, that reads from the console an array of N integers and an integer K, sorts the array and
//using the method Array.BinSearch() finds the largest number in the array which is ≤ K.

class BSearch
{
    static void Main()
    {
        // demo array
        int[] numbers = { 1, 2, 3, 7, 8, 9, 13, 14, 16, 28 };

        // just change k here
        int k = 4;
        // get a result from binary search
        int index = Array.BinarySearch(numbers, k);
        
        // if binary search returns -1
        if (index < 0)
        {
            // while the index isn't a valid position in the array
            while (index < 0 || index >= numbers.Length)
            {
                // decrement k
                k--;
                // and see if binary search return anything reasonable
                index = Array.BinarySearch(numbers, k);
            }
        }

        Console.WriteLine(numbers[index]);
    }
}

