/*
Problem 4. Maximal sequence

Write a program that finds the maximal sequence of equal elements in an array.
*/

using System;

class FindMaximalSequence
{
    static void Main()
    {
        Console.Write("Please enter your sequence of numbers on the first line: ");
        string sequence = Console.ReadLine();

        int counter = 1;
        int currentElement = 0;
        int currentMax = 0;

        string[] numberArray = sequence.Split(new char[] { ',', ' ', '\t'}, StringSplitOptions.RemoveEmptyEntries);

        for (int i = 0; i < numberArray.Length - 1; i++)
        {
            if (numberArray[i] == numberArray[i + 1])
            {
                counter++;
                if (counter > currentMax)
                {
                    currentMax = counter;
                    currentElement = Int32.Parse(numberArray[i]);
                }
            }
            else
            {
                counter = 1;
            }

        }

        Console.Write("Maximal sequence of equal elements: ");

        for (int i = 0; i < currentMax; i++)
        {
            Console.Write(currentElement);
            
            if (i != currentMax - 1)
            {
                Console.Write(", ");
            }
        }
        Console.WriteLine();
    }
}

