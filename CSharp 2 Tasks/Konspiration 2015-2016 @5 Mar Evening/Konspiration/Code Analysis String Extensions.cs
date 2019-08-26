using System.Text;
using System.Collections.Generic;

public static class CodeAnalysisStringExtensions
{
    private const char OPENING_CURLY_BRACKET = '{';
    private const char CLOSING_CURLY_BRACKET = '}';
    private const char OPENING_BRACKET = '(';
    private const char WHITESPACE = ' ';
    private const char UNDERSCORE = '_';
    private const string NEW_KEYWORD = "new";
    private const int NOT_FOUND = -1;


    public static bool IsValidInMethodName(this char character)
    {
        return char.IsLetter(character) || character == UNDERSCORE;
    }

    public static List<string> GetMethodNames(this string cSharpCode)
    {
        var calls = new List<string>();

        var openingBracketIndex = cSharpCode.IndexOf(OPENING_BRACKET);

        while (openingBracketIndex != NOT_FOUND)
        {
            var methodName = new StringBuilder();
            var methodNameEnd = openingBracketIndex - 1;

            while (cSharpCode[methodNameEnd] == WHITESPACE)
            {
                methodNameEnd--;
            }

            for (var i = methodNameEnd; i >= 0 && cSharpCode[i].IsValidInMethodName(); i--)
            {
                methodName.Insert(0, cSharpCode[i]);
            }

            var currentMethodIsConstructor = IsConstructor(cSharpCode, methodNameEnd - methodName.Length);

            if (methodName.Length != 0 && !char.IsLower(methodName[0]) && !currentMethodIsConstructor)
            {
                calls.Add(methodName.ToString());
            }

            openingBracketIndex = cSharpCode.IndexOf(OPENING_BRACKET, openingBracketIndex + 1);
        }

        return calls;
    }

    public static int OpenBracketsCount(this string cSharpCode)
    {
        var result = 0;

        for (var i = 0; i < cSharpCode.Length; i++)
        {
            if (cSharpCode[i] == OPENING_CURLY_BRACKET)
            {
                result++;
            }
            else if (cSharpCode[i] == CLOSING_CURLY_BRACKET)
            {
                result--;
            }
        }

        return result;
    }

    private static bool IsConstructor(string cSharpCode, int methodNameStart)
    {
        var isConstructorMethod = true;

        while (methodNameStart >= 0 && cSharpCode[methodNameStart] == WHITESPACE)
        {
            methodNameStart--;
        }

        while (methodNameStart >= 0 && cSharpCode[methodNameStart] != WHITESPACE)
        {
            methodNameStart--;
        }

        if (methodNameStart < 0)
        {
            isConstructorMethod = false;
        }
        else if (cSharpCode.Substring(methodNameStart + 1, NEW_KEYWORD.Length) != NEW_KEYWORD)
        {
            isConstructorMethod = false;
        }

        return isConstructorMethod;
    }
}