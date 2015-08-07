namespace Methods
{
    using System;

    public class TriangleOperations
    {
        private const string INVALID_TRIANGLE_SIDES = "The values {0}, {1}, {2} cannot be sides of a triangle.";

        public static double CalculateTriangleArea(double a, double b, double c)
        {
            if (Validator.AreInvalidTriangleSides(a, b, c))
            {
                throw new ArgumentException(string.Format(INVALID_TRIANGLE_SIDES, a, b, c));
            }

            var p = (a + b + c) / 2;
            var area = Math.Sqrt(p * (p - a) * (p - b) * (p - c));

            return area;
        }

        
    }
}
