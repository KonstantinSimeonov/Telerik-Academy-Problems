using System;

public class AssertionUtilities
{
    public static bool IsMinElementIn<T>(T element, T[] arr, int start, int end)
        where T : IComparable<T>
    {
        var isInCollection = false;

        for (int i = start; i <= end; i++)
        {
            if (element.CompareTo(arr[i]) > 0)
            {
                return false;
            }
            else if (element.CompareTo(arr[i]) == 0)
            {
                isInCollection = true;
            }
        }

        return isInCollection;
    }

    public static bool IsSortedByAscending<T>(T[] arr)
        where T : IComparable<T>
    {
        for (int i = 1; i < arr.Length; i++)
        {
            if(arr[i -1].CompareTo(arr[i]) > 0)
            {
                return false;
            }
        }

        return true;
    }

    public static bool IsNotInArray<T>(T value, T[] arr)
    {
        for (int i = 0; i < arr.Length; i++)
        {
            if(arr[i].Equals(value))
            {
                return false;
            }
        }

        return true;
    }
}