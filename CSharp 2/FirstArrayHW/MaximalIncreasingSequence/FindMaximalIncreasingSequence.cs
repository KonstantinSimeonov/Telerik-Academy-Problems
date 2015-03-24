/*
Problem 5. Maximal increasing sequence

Write a program that finds the maximal increasing sequence in an array.
*/

using System;

class FindMaximalIncreasingSequence
{
    static void Main()
    {
        Console.Write("Please enter your sequence of numbers: ");
        string text = Console.ReadLine();

        string[] numberArray = text.Split(new char[] { ',', ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);

        int[] sequence = new int[numberArray.Length];

        int counter = 1;
        int maxCounter = 0;
        int bestStart = 0;
        int i;

        // Parsing the elements from the string array
        for (int k = 0; k < sequence.Length; k++)
        {
            sequence[k] = Int32.Parse(numberArray[k].ToString());
        }

        // Searching for the maximal increasing sequence
        for (i = 0; i < sequence.Length - 1; i++)
        {
            if (sequence[i] < sequence[i + 1])
            {
                counter++;
            }
            else if (sequence[i] > sequence[i + 1])
            {
                if (counter > maxCounter)
                {
                    maxCounter = counter;
                    counter = 1;
                    bestStart = i - maxCounter + 1;
                }
                counter = 1;
            }

        }

        if (counter >= maxCounter)
        {
            maxCounter = counter;
            bestStart = i - maxCounter + 1;
        }

        Console.Write("The maximal increasing sequence in an array is: ");

        // Printing the maximal increasing sequence
        for (int j = bestStart; j < bestStart + maxCounter; j++)
        {
            Console.Write(sequence[j]);

            if (j != (bestStart + maxCounter - 1))
            {
                Console.Write(", ");
            }
        }
        Console.WriteLine();
    }
}

