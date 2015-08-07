namespace Methods
{
    using System;
    using System.Collections.Generic;
    using System.Text.RegularExpressions;

    public class NumberOperations
    {
        private static Dictionary<string, string> NumberFormats = new Dictionary<string, string>() { 

        {"%", "{0:p0}"},

        {"f", "{0:f2}"},

        {"r", "{0, 8}"}

        };

        private const string NOT_SUPPORTED_FORMAT = "The provided format({0})is not supported";
        private const string INVALID_NUMBER_VALUE = "The object passed as number({0}) is not valid.";

        public static string GetFormattedNumber(object number, string format)
        {
            if (Validator.IsNotNumeric(number))
            {
                throw new ArgumentException(string.Format(INVALID_NUMBER_VALUE, number));
            }

            if (!NumberFormats.ContainsKey(format))
            {
                throw new ArgumentException(string.Format(NOT_SUPPORTED_FORMAT, format));
            }

            return string.Format(NumberFormats[format], number);
        }
    }
}