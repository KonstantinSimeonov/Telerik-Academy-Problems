/*
Problem 12. Index of letters

Write a program that creates an array containing all letters from the alphabet (A-Z).
Read a word from the console and print the index of each of its letters in the array.
*/

using System;

class FinfIndexOfLetters
{
    static void Main()
    {
        string[] alphabet = new string[52];

        for (int i = 0; i < alphabet.Length; i++)
        {
            if (i >= 26)
            {
                alphabet[i] = ((char)('A' + i - 26)).ToString();
            }
            else
            {
                alphabet[i] = ((char)('a' + i)).ToString();
            }
        }
        Console.WriteLine(string.Join(", ", alphabet));
        Console.Write("Please enter your word: ");
        string text = Console.ReadLine();

        // Print the index
        for (int i = 0; i < text.Length; i++)
        {
            for (int j = 0; j < alphabet.Length; j++)
            {
                if (text[i].ToString() == alphabet[j])
                {
                    Console.WriteLine("{0} -> {1}", text[i], j);
                }
            }
        }

    }
}

