using System;
using System.Diagnostics;

    public class SearchAlgorithms
    {
        public static int BinarySearch<T>(T[] arr, T value) where T : IComparable<T>
        {
            Debug.Assert(arr != null, "The array was null.");
            Debug.Assert(arr.Length > 0, "The length was less than 1");

            return BinarySearch(arr, value, 0, arr.Length - 1);
        }

        private static int BinarySearch<T>(T[] arr, T value, int startIndex, int endIndex)
            where T : IComparable<T>
        {
            Debug.Assert(startIndex < endIndex, "Starting index was larger than ending index");
            
            while (startIndex <= endIndex)
            {
                Debug.Assert(startIndex < arr.Length, "Start index became larger than array length.");
                Debug.Assert(endIndex >= 0, "End index became less than zero");

                int midIndex = (startIndex + endIndex) / 2;
                if (arr[midIndex].Equals(value))
                {
                    return midIndex;
                }
                if (arr[midIndex].CompareTo(value) < 0)
                {
                    // Search on the right half
                    startIndex = midIndex + 1;
                }
                else
                {
                    // Search on the right half
                    endIndex = midIndex - 1;
                }
            }

            // Searched value not found
            Debug.Assert(AssertionUtilities.IsNotInArray(value, arr), "The value was in the array.");
            return -1;
        }
    }
