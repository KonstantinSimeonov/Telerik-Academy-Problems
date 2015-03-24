/*
Problem 10. Find sum in array

Write a program that finds in given array of integers a sequence of given sum S (if present).
Example:

array	                    S	        result
4, 3, 1, 4, 2, 5, 8	        11	        4, 2, 5
 
*/
using System;

class SumInArray
{
    static void Main()
    {
        Console.Write("Please enter your sequence of numbers: ");
        string text = Console.ReadLine();

        Console.Write("Please enter the sum you want to check: ");
        int checkSum = Int32.Parse(Console.ReadLine());

        string[] numberArray = text.Split(new char[] { ',', ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);

        int[] sequence = new int[numberArray.Length];

        int sum = 0;
        int bestStart = -1;
        int bestLength = -1;

        

        // Parsing the elements from the string array
        for (int i = 0; i < sequence.Length; i++)
        {
            sequence[i] = Int32.Parse(numberArray[i].ToString());
        }

        // Searching for a sequence
        for (int i = 0; i < sequence.Length; i++)
        {
            sum = sequence[i];
            for (int j = i + 1; j < sequence.Length; j++)
            {
                if (sum == checkSum)
                {
                    bestStart = i;
                    bestLength = j;
                }
                sum += sequence[j];
            }
        }

        // Printing the result
        if (bestStart == -1 && bestLength == -1)
        {
            Console.WriteLine("There isn't a sequence of numbers which sum is {0}", checkSum);
        }
        else
        {
            Console.Write("The sequence of sum is ");
            for (int i = bestStart; i < bestLength; i++)
            {
                Console.Write(sequence[i]);

                if (i != bestLength - 1)
                {
                    Console.Write(", ");
                }
            }
            Console.WriteLine(" and their sum is {0}", checkSum);
        }
    }
}

