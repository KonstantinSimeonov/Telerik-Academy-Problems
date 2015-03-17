using System;

class Test
{
    private const string IntelligentGreeting = "drastii";

    private static ConsoleColor[] colours = { ConsoleColor.Cyan, ConsoleColor.Green, ConsoleColor.Yellow, ConsoleColor.Red, ConsoleColor.Magenta };
    
    static Random vladoRandoma = new Random();

    private static void SayHello()
    {
        Console.CursorVisible = false;
        Console.ForegroundColor = colours[vladoRandoma.Next(0, colours.Length)];
        Console.SetCursorPosition(vladoRandoma.Next(2, Console.WindowWidth), vladoRandoma.Next(2, Console.WindowHeight)); // im being a douchebag
        Console.WriteLine(IntelligentGreeting);
    }

    public static void Main()
    {
        var testTimer = new Timer(1, SayHello);
        testTimer.Execute(50);
    }
}