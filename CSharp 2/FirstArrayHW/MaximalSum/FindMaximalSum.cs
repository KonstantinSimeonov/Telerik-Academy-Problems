/*Problem 8. Maximal sum

Write a program that finds the sequence of maximal sum in given array.

Example:

input	                                result
2, 3, -6, -1, 2, -1, 6, 4, -8, 8	    2, -1, 6, 4
*/

using System;

class FindMaximalSum
{
    static void Main()
    {
        Console.Write("Please enter your sequence of numbers: ");
        string text = Console.ReadLine();

        string[] numberArray = text.Split(new char[] { ',', ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);

        int[] sequence = new int[numberArray.Length];
        int sum = 0;
        int maxSum = 0;
        int bestStart = 0;
        int bestLength = 0;

        // Parsing the elements from the string array
        for (int i = 0; i < sequence.Length; i++)
        {
            sequence[i] = Int32.Parse(numberArray[i].ToString());
        }

        // Searching the max sum
        for (int i = 0; i < sequence.Length; i++)
        {
            sum = sequence[i];
            for (int j = i + 1; j < sequence.Length; j++)
            {
                if (sum > maxSum)
                {
                    maxSum = sum;
                    bestStart = i;
                    bestLength = j;
                }
                sum += sequence[j];
            }
        }

        // Printing the result
        Console.Write("The sequence of maximal sum is ");
        for (int i = bestStart; i < bestLength; i++)
        { 
            Console.Write(sequence[i]);

            if (i != bestLength - 1)
            {
                Console.Write(", ");
            }
        }
        Console.WriteLine(" and their sum is {0}", maxSum);
    }
}

