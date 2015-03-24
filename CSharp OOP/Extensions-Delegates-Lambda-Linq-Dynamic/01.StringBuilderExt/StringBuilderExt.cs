using System;
using System.Text;

// Problem 1. StringBuilder.Substring

// Implement an extension method Substring(int index, int length) for the class StringBuilder
// that returns new StringBuilder and has the same functionality as Substring in the class String.

public static class StringBuilderExt
{
    public static StringBuilder Substring(this StringBuilder builder, int start, int length)
    {
        var substring = new StringBuilder();

        for (int i = start; i < length + start; i++)
        {
            substring.Append(builder[i]);
        }

        return substring;
    }
}