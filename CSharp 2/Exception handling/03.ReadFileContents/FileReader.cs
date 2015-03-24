using System;
using System.IO;

//Problem 3. Read file contents

//Write a program that enters file name along with its full file path (e.g. C:\WINDOWS\win.ini),
//reads its contents and prints it on the console.
//Find in MSDN how to use System.IO.File.ReadAllText(…).
//Be sure to catch all possible exceptions and print user-friendly error messages.

class FileReader
{
    static void Main()
    {
        string filePath = string.Empty;

        try
        {
            filePath = Console.ReadLine();
        }
        catch(IOException e)
        {
          Console.WriteLine(e.Message);
        }

        string contents = string.Empty;

        try
        {
            contents = File.ReadAllText(filePath);
            Console.WriteLine(contents);
        }
        catch (FileNotFoundException e)
        {
            Console.WriteLine("File not found.\nFor more info press \"i\".");
            if (Console.ReadKey(true).Key == ConsoleKey.I)
            {
                Console.WriteLine(e.Message);
            }
        }
        catch (FileLoadException e)
        {
            Console.WriteLine("Could not load file.\nFor more info press \"i\".");
            if (Console.ReadKey(true).Key == ConsoleKey.I)
            {
                Console.WriteLine(e.Message);
            }
        }
        catch (DirectoryNotFoundException e)
        {
            Console.WriteLine("Could not find specified directory.\nFor more info press \"i\".");
            if (Console.ReadKey(true).Key == ConsoleKey.I)
            {
                Console.WriteLine(e.Message);
            }
        }
        catch (ArgumentException e)
        {
            Console.WriteLine("Invalid file path!\nFor more info press \"i\".");
            if (Console.ReadKey(true).Key == ConsoleKey.I)
            {
                Console.WriteLine(e.Message);
            }
        }
        catch (PathTooLongException e)
        {
            Console.WriteLine("Path to file is too long!\nFor more info press \"i\".");
            if (Console.ReadKey(true).Key == ConsoleKey.I)
            {
                Console.WriteLine(e.Message);
            }
        }
        catch (DriveNotFoundException e)
        {
            Console.WriteLine("The drive which you entered doesn't exists.\nFor more info press \"i\".");
            if (Console.ReadKey(true).Key == ConsoleKey.I)
            {
                Console.WriteLine(e.Message);
            }
        }
        catch (NotSupportedException e)
        {
            Console.WriteLine(e.Message);
        }
        catch (UnauthorizedAccessException e)
        {
            Console.WriteLine("Access to file denied.\nFor more info press \"i\".");
            if (Console.ReadKey(true).Key == ConsoleKey.I)
            {
                Console.WriteLine(e.Message);
            }
        }

    }
}

