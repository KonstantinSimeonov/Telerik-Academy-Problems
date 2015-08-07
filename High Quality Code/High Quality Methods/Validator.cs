namespace Methods
{
    using System;
    using System.Text.RegularExpressions;

    public class Validator
    {
        private const string NUMBER_PATTERN = @"^[-+]?[0-9]*(\.|,)?[0-9]+$";

        public static bool AreInvalidTriangleSides(double a, double b, double c)
        {
            if (a <= 0 || b <= 0 || c <= 0)
            {
                return true;
            }

            if (a >= b + c || b >= a + c || c >= a + b)
            {
                return true;
            }

            return false;
        }

        public static bool IsNotNumeric(object number)
        {
            var matchNumber = new Regex(NUMBER_PATTERN);
            var numberAsString = number.ToString();

            return !matchNumber.IsMatch(numberAsString);
        }

        public static bool IsNullOrEmptyArray<T>(params T[] array)
        {
            return array == null || array.Length < 1;
        }
    }
}