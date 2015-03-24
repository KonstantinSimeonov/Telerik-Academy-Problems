/*
Problem 15. Prime numbers

Write a program that finds all prime numbers in the range [1...10 000 000]. Use the Sieve of Eratosthenes algorithm.
*/

using System;

class PrintPrimeNumbers
{
    static void Main()
    {
        Console.Write("Please enter a number [1 - 10 000 000]: ");
        int number = Int32.Parse(Console.ReadLine());

        bool[] primeNumbers = new bool[number];

        for (int i = 0; i < primeNumbers.Length; i++)
        {
            primeNumbers[i] = true;
        }

        for (int i = 2; i < primeNumbers.Length; i++)
        {
            if (!primeNumbers[i])
            {
                for (int j = 2; j * i < primeNumbers.Length; j++)
                {
                    primeNumbers[j * i] = false;
                }
            }
        }

        Console.WriteLine("All prime numbers in the range [1 - {0}] are:", number);
        for (int i = 2; i < primeNumbers.Length; i++)
        {
            if (primeNumbers[i] == true)
            {
                Console.Write(i + " ");
            }
        }
        Console.WriteLine();

    }
}

