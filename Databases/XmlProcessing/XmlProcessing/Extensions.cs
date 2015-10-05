namespace XmlProcessing
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// I'm getting lazy when i write long assignments.
    /// </summary>
    public static class Extensions
    {
        public static IEnumerable<T> ForEach<T>(this IEnumerable<T> collection, Action<T> action)
        {
            foreach (var item in collection)
            {
                action(item);
            }

            return collection;
        }

        public static string Formatted(this string format, params object[] insertees)
        {
            return string.Format(format, insertees);
        }

        public static void PrintTrimmed(this string str)
        {
            if(!string.IsNullOrWhiteSpace(str))
            {
                Console.WriteLine(str.Trim());
            }
        }
    }
}