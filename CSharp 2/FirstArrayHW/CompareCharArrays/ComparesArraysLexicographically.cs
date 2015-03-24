/*
Problem 3. Compare char arrays

Write a program that compares two char arrays lexicographically (letter by letter).
*/

using System;

class ComparesArraysLexicographically
{
    static void Main()
    {
        Console.Write("Enter you first word (example: plane): ");
        string firstWord = Console.ReadLine(); // Note: The string is actually an array of chars

        Console.Write("Enter you second word: ");
        string secondWord = Console.ReadLine(); // Note: The string is actually an array of chars

        int counter = 0;

        // Compare char arrays
        for (int i = 0; i < firstWord.Length; i++)
        {
            if (firstWord.Length > secondWord.Length || firstWord.Length < secondWord.Length)
            {
                Console.WriteLine("Your words are different");
                return;
            }

            if (firstWord[i] == secondWord[i])
            {
                counter++;
            }
            else
            {
                continue;
            }
            
        }
        
        if (counter == firstWord.Length)
        {
            Console.WriteLine("Your words are the same. All elements of the two char arrays are equal.");
        }
        else
        {
            Console.WriteLine("Your words are different. Not all elements of the two char arrays are equal.");
        }
        
    }
}

