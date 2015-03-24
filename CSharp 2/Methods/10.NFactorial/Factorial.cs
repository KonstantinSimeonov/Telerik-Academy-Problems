using System;
using System.Numerics;

//Problem 10. N Factorial

//Write a program to calculate n! for each n in the range [1..100].

class Factorial
{
    static void Main()
    {
        Console.WriteLine("N:");
        int N = int.Parse(Console.ReadLine());
        BigInteger n = new BigInteger(N);
        for (int i = N-1; i > 0; i--)
        {
            n = n * i;
        }

        Console.WriteLine(n);
    }
}

