namespace CohesionAndCoupling.Utils
{
    using System;

    public static class EuclideanSpaceUtils
    {
        public static double CalcDistanceBetweenPoints(double[] firstPointCoordinates, double[] secondPointCoordinates)
        {
            if (firstPointCoordinates.Length != secondPointCoordinates.Length)
            {
                throw new ArgumentException("Different number of coordinates for the two points!");
            }

            if (firstPointCoordinates == null || firstPointCoordinates.Length == 0)
            {
                throw new ArgumentException("First point coordinates are null or empty!");
            }

            if (secondPointCoordinates == null || secondPointCoordinates.Length == 0)
            {
                throw new ArgumentException("Second point coordinates are null or empty!");
            }

            if(firstPointCoordinates.Length == 1)
            {
                return Math.Abs(firstPointCoordinates[0] - secondPointCoordinates[0]);
            }

            var sumOfCoordinateDifferences = 0.0;

            for (int i = 0, length = firstPointCoordinates.Length; i < length; i++)
            {
                sumOfCoordinateDifferences += (firstPointCoordinates[i] - secondPointCoordinates[i]) * (firstPointCoordinates[i] - secondPointCoordinates[i]);
            }

            var distance = Math.Sqrt(sumOfCoordinateDifferences);

            return distance;
        }
    }

    public static class ParallelepipedUtils
    {
        private const double ZERO = 0;

        public static double CalcVolume(double width, double height, double depth)
        {
            var volume = width * height * depth;

            return volume;
        }

        public static double CalcDiagonalLengthXYZ(double width, double height, double depth)
        {
            var diagonalLength = EuclideanSpaceUtils.CalcDistanceBetweenPoints(new double[] { ZERO, ZERO, ZERO }, new double[] { width, height, depth });

            return diagonalLength;
        }

        public static double CalcDiagonalLengthXY(double width, double height)
        {
            var diagonalLength = EuclideanSpaceUtils.CalcDistanceBetweenPoints(new double[] { ZERO, ZERO }, new double[] { width, height });

            return diagonalLength;
        }

        public static double CalcDiagonalLengthXZ(double width, double depth)
        {
            var diagonalLength = EuclideanSpaceUtils.CalcDistanceBetweenPoints(new double[] { ZERO, ZERO }, new double[] { width, depth });

            return diagonalLength;
        }

        public static double CalcDiagonalYZ(double height, double depth)
        {
            var distance = EuclideanSpaceUtils.CalcDistanceBetweenPoints(new double[] { ZERO, ZERO }, new double[] { height, depth });

            return distance;
        }
    }

    public static class FileNameUtils
    {
        private const char DOT = '.';

        public static string GetFileExtension(string fileName)
        {
            var indexOfLastDot = fileName.LastIndexOf(DOT);
            if (indexOfLastDot == -1)
            {
                return string.Empty;
            }

            var fileExtension = fileName.Substring(indexOfLastDot + 1);

            return fileExtension;
        }

        public static string GetFileNameWithoutExtension(string fileName)
        {
            var indexOfLastDot = fileName.LastIndexOf(DOT);
            if (indexOfLastDot == -1)
            {
                return fileName;
            }

            var nameWithoutExtension = fileName.Substring(0, indexOfLastDot);

            return nameWithoutExtension;
        }
    }

}