/*
Problem 19.* Permutations of set

Write a program that reads a number N and generates and prints all the permutations of the numbers [1 … N].
*/

using System;
using System.Linq;

class PrintPermutationsOfSet
{
    static void GeneratePermutations<T>(T[] array, int startPosition, int endPosition)
    {
        if (startPosition == endPosition)
        {
            Print(array);
        }
        else
        {
            //Permutations<T>(array, element + 1);
            for (int i = startPosition; i < endPosition; i++)
            {
                Swap(array, startPosition,i);
                GeneratePermutations(array, startPosition + 1, endPosition);
                Swap(array, startPosition, i);
            }
        }
    }

    static void Print<T>(T[] array)
    {
        for (int i = 0; i < array.Length; i++)
        {
            Console.Write(array[i] + " ");
        }
        Console.WriteLine();
    }

    static void Swap<T>(T[] array, int startPosition, int endPosition)
    {
        T temp = array[startPosition];
        array[startPosition] = array[endPosition];
        array[endPosition] = temp;
    }
    static void Main()
    {
        Console.Write("Please enter a number: ");
        int number = Int32.Parse(Console.ReadLine());

        int[] array = new int[number];

        for (int i = 0; i < array.Length; i++)
        {
            array[i] = i + 1; 
        }

        Console.WriteLine("All the permutations of the numbers from 1 to {0}:", number);
        GeneratePermutations(array, 0, number);
    }
}

