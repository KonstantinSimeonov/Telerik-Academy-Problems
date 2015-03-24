using System;
using System.Collections.Generic;


//Problem 13. Solve tasks

//Write a program that can solve these tasks:
//Reverses the digits of a number
//Calculates the average of a sequence of integers
//Solves a linear equation a * x + b = 0
//Create appropriate methods.
//Provide a simple text-based menu for the user to choose which task to solve.
//Validate the input data:
//The decimal number should be non-negative
//The sequence should not be empty
//a should not be equal to 0


struct TaskSolver
{

    /// <summary>
    /// Reverse the digits of a given integer.
    /// </summary>
    /// <param name="number"></param>
    public static void ReverseDigits(ref decimal number)
    {
        char[] rev = number.ToString().ToCharArray();
        for (int i = 0; i < rev.Length / 2; i++)
        {
            char swap = rev[i];
            rev[i] = rev[rev.Length - 1 - i];
            rev[rev.Length - 1 - i] = swap;
        }

        number = (decimal)double.Parse(new string(rev));
    }

    /// <summary>
    /// Finds the average of an integer sequence.
    /// </summary>
    /// <param name="seq"></param>
    /// <returns></returns>
    private static double Average(ref List<int> seq)
    {
        double sum = 0;

        foreach (double number in seq)
        {
            sum += number;
        }

        return sum / (double)seq.Count;
    }

    /// <summary>
    /// Calculates the root of a linear equation.
    /// </summary>
    /// <param name="a"></param>
    /// <param name="b"></param>
    /// <returns></returns>
    private static double LinearRoot(int a, int b)
    {
        return (double)-b / (double)a;
    }

    /// <summary>
    /// Prints the given message, takes user input, verifies it and returns it as an integer if it is correct.
    /// Else prompts the user to make a correct input.
    /// </summary>
    /// <param name="message"></param>
    /// <returns></returns>
    private static int TakeUserInt(string message)
    {
        int userInput = 0;
        try
        {
            Console.Write(message);
            userInput = int.Parse(Console.ReadLine());
        }
        catch (Exception e)
        {
            Console.Write("Enter a valid value: ");
            userInput = TakeUserInt(message);
        }
        return userInput;
    }

    /// <summary>
    /// Prints the given message, takes user input, verifies it and returns it as a decimal if it is correct.
    /// Else prompts the user to make a correct input.
    /// </summary>
    /// <returns></returns>
    private static decimal TakeUserDec()
    {
        decimal userInput = 0;
        try
        {
            Console.Write("Input a decimal number: ");
            userInput = decimal.Parse(Console.ReadLine());
        }
        catch (Exception e)
        {
            Console.Write("Invalid value. ");
            userInput = TakeUserDec();
        }

        if (userInput <= 0)
        {
            Console.Write("Value must be a positive number: ");
            userInput = TakeUserDec();
        }
        return userInput;
    }

    /// <summary>
    /// Starts the task solver.
    /// </summary>
    public static void Run()
    {
        Console.Write("1.Reverse a number's digits\n2.Calculate the average of a integer sequence\n3.Solve a linear EQ:\nor type 'exit' to exit\n");
        string command = Console.ReadLine();
        switch (command)
        {
            case "1":
                {
                    decimal dec = TakeUserDec();
                    ReverseDigits(ref dec);
                    Console.Write(dec);
                } break;

            case "2":
                {
                    Console.WriteLine("How long is the sequence? ");
                    int co = int.Parse(Console.ReadLine());

                    List<int> li = new List<int>();

                    for (int i = 0; i < co; i++)
                    {
                        li.Add(TakeUserInt("Integer "+(i+1)+": "));
                    }

                    Console.WriteLine("Average: {0}", Average(ref li));

                } break;
            case "3":
                {
                    int a = TakeUserInt("a= ");

                    while (a == 0)
                    {
                        Console.WriteLine("a should not be equal to 0");
                        a = TakeUserInt("a= ");
                    }

                    int b = TakeUserInt("b= ");
                    
                    Console.WriteLine("Root is: {0}", LinearRoot(a, b));
                } break;
            case "exit": break;
            default: Console.WriteLine("Provide correct input:"); break;
        }


    }

}

class Tasks
{

    static void Main()
    {
        TaskSolver.Run();

    }
}

