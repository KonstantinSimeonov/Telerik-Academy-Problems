using System;
using System.Linq;

//Problem 17. Longest string

//Write a program to return the string with maximum length from an array of strings.
//Use LINQ.

class Program
{
    static void Main()
    {
        var hardCodedNames = new string[] { "pesho", "peshokelesho", "telerig-akademi-lol" };

        var longest = (from str in hardCodedNames 
                      orderby str.Length descending
                      select str).ToArray()[0];

        Console.WriteLine(longest);
    }
}