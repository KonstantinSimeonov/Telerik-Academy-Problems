namespace Methods
{
    using System; 

    /// <summary>
    /// Provides basic operations with points in the 2-dimensional Euclidean space.
    /// </summary>
    public class CoordinateSystemOperations
    {
        /// <summary>
        /// Calculates the distance between two points with given coordinates in the 2-dimensional Euclidean space.
        /// </summary>
        /// <param name="x1">X-coordinates of the first point.</param>
        /// <param name="y1">Y-coordinates of the first point.</param>
        /// <param name="x2">X-coordinates of the second point.</param>
        /// <param name="y2">Y-coordinates of the second point.</param>
        /// <returns></returns>
        public static double CalculateDistance(double x1, double y1, double x2, double y2)
        {
            var distance = Math.Sqrt((x2 - x1) * (x2 - x1) + (y2 - y1) * (y2 - y1));

            return distance;
        }

        /// <summary>
        /// Returns true if two points with given coordinates in the 2-dimensional Euclidean space define a horizontal line.
        /// </summary>
        /// <param name="x1">X-coordinates of the first point.</param>
        /// <param name="y1">Y-coordinates of the first point.</param>
        /// <param name="x2">X-coordinates of the second point.</param>
        /// <param name="y2">Y-coordinates of the second point.</param>
        /// <returns></returns>
        public static bool DefineHorizontalLine(double x1, double y1, double x2, double y2)
        {
            return x1 != x2 && y1 == y2;
        }

        /// <summary>
        /// Returns true if two points with given coordinates in the 2-dimensional Euclidean space define a vertical line.
        /// </summary>
        /// <param name="x1">X-coordinates of the first point.</param>
        /// <param name="y1">Y-coordinates of the first point.</param>
        /// <param name="x2">X-coordinates of the second point.</param>
        /// <param name="y2">Y-coordinates of the second point.</param>
        /// <returns></returns>
        public static bool DefineVerticalLine(double x1, double y1, double x2, double y2)
        {
            return x1 == x2 && y1 != y2;
        }
    }
}
