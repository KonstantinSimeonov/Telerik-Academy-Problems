/*
Problem 1. Allocate array

Write a program that allocates array of 20 integers and initializes each element by its index multiplied by 5.
Print the obtained array on the console.
*/

using System;

class ArrayOfIntegers
{
    static void Main()
    {
        int[] arrayOfIntegers = new int[20];

        for (int index = 0; index < arrayOfIntegers.Length; index++)
        {
            arrayOfIntegers[index] = index * 5;
            Console.Write(arrayOfIntegers[index] + " ");
        }
        Console.WriteLine();
    }
}
