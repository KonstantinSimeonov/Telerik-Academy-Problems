using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Konspiration
{
    private const string OPENING_BRACKET = "(";
    private const string APPEND_FORMAT = "{0} -> {1}";
    private const string STATIC = " static ";
    private const string METHOD_SEPARATOR = ", ";
    private const string NONE = "None";
    private const int NOT_FOUND = -1;

    public static void Run()
    {
        var linesCountAsString = Console.ReadLine();
        var linesCount = int.Parse(linesCountAsString);

        var currentMethodCalls = new List<string>();
        string currentMethodName = null;
        var result = new StringBuilder();

        var inMethod = false;
        var openBracketsCount = 0;

        for (var line = 0; line < linesCount || openBracketsCount > 0; line++)
        {
            var currentLine = Console.ReadLine();

            if (!inMethod)
            {
                var indexOfKeyWordStatic = currentLine.IndexOf(STATIC);

                if (indexOfKeyWordStatic != NOT_FOUND)
                {
                    currentMethodName = currentLine.GetMethodNames().First();
                    inMethod = true;
                }
            }
            else
            {
                openBracketsCount += currentLine.OpenBracketsCount();

                if (openBracketsCount == 0)
                {
                    string callsToAppend = null;

                    if (currentMethodCalls.Count > 0)
                    {
                        var joinedMethods = string.Join(METHOD_SEPARATOR, currentMethodCalls);

                        callsToAppend = string.Format(APPEND_FORMAT, currentMethodCalls.Count, joinedMethods);
                    }
                    else
                    {
                        callsToAppend = NONE;
                    }

                    var formattedCalls = string.Format(APPEND_FORMAT, currentMethodName, callsToAppend);

                    result.AppendLine(formattedCalls);
                    currentMethodCalls.Clear();
                    inMethod = false;

                    continue;
                }

                var methodCalls = currentLine.GetMethodNames();

                if (methodCalls.Count > 0)
                {
                    foreach (var methodName in methodCalls)
                    {
                        currentMethodCalls.Add(methodName);
                    }
                }
            }
        }
        Console.WriteLine(result);
    }
}