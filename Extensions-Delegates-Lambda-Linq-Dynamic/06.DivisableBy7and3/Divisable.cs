using System;
using System.Collections.Generic;
using System.Linq;

//Problem 6. Divisible by 7 and 3

//Write a program that prints from given array of integers all numbers that are
//divisible by 7 and 3. Use the built-in extension methods and lambda expressions. Rewrite the same with LINQ.

class Divisable
{
    public static int index = 0;
    static void Main()
    {
        
        var randomNums = new int[100].Select(n => index++).ToArray(); // try removing .ToArray() and see what happens. know why? :P



        // EXTENSIONS

        var EXTnumbers = randomNums.Where(n => n % 7 == 0 && n % 3 == 0);

        Console.WriteLine(string.Join(", ", EXTnumbers));



        // LINQ

        var LINQnumbers = from number in randomNums
                          where (number % 7 == 0 && number % 3 == 0)
                          select number;

        Console.WriteLine(string.Join(", ", LINQnumbers));
    }
}

