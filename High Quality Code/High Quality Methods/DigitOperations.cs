namespace Methods
{
    using System;

    public class DigitOperations
    {
        private static readonly string[] DigitsAsWord = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };
        private const string NOT_A_DIGIT_MESSAGE = "The provided input({0}) is not a digit!";

        public static string DigitToWord(int digit)
        {
            if(digit < 0 || 9 < digit)
            {
                throw new ArgumentOutOfRangeException(string.Format(NOT_A_DIGIT_MESSAGE, digit));
            }

            return DigitsAsWord[digit];
        }
    }
}
