/*
Problem 9. Frequent number

Write a program that finds the most frequent number in an array.

Example:

input	                                    result
4, 1, 1, 4, 2, 3, 4, 4, 1, 2, 4, 9, 3	    4 (5 times)
*/

using System;

class FindTheMostFrequentNumber
{
    static void Main()
    {
        Console.Write("Please enter your sequence of numbers: ");
        string text = Console.ReadLine();

        string[] numberArray = text.Split(new char[] { ',', ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);

        int[] sequence = new int[numberArray.Length];

        int counter = 0;
        int maxCounter = 0;
        int number = 0;

        // Parsing the elements from the string array
        for (int i = 0; i < sequence.Length; i++)
        {
            sequence[i] = Int32.Parse(numberArray[i].ToString());
        }

        // SORT
        Array.Sort(sequence);

        // Searching the most frequent number
        for (int i = 0; i < sequence.Length; i++)
        {
            for (int j = i + 1; j < sequence.Length; j++)
            {
                if (sequence[i] == sequence[j]) // array needs to be sorted to use that approach
                {
                    counter++;
                }

                if (counter > maxCounter)
                {
                    maxCounter = counter;
                    number = sequence[i];
                }

                // counter = 0;  wrong - reset the counter every iteration
            }
            counter = 1;
        }

        Console.WriteLine("The most frequent number is {0} ({1} times)", number, maxCounter);
    }
}

