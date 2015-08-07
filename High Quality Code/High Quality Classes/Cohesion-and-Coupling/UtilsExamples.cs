namespace CohesionAndCoupling
{
    using System;
    using CohesionAndCoupling.Utils;

    public class UtilsExamples
    {
        public static void Main()
        {
            Console.WriteLine(FileNameUtils.GetFileExtension("example"));
            Console.WriteLine(FileNameUtils.GetFileExtension("example.pdf"));
            Console.WriteLine(FileNameUtils.GetFileExtension("example.new.pdf"));

            Console.WriteLine(FileNameUtils.GetFileNameWithoutExtension("example"));
            Console.WriteLine(FileNameUtils.GetFileNameWithoutExtension("example.pdf"));
            Console.WriteLine(FileNameUtils.GetFileNameWithoutExtension("example.new.pdf"));

            Console.WriteLine("Distance in the 2D space = {0:f2}",
                EuclideanSpaceUtils.CalcDistanceBetweenPoints(new double[]{1, -2}, new double[]{3, 4}));
            Console.WriteLine("Distance in the 3D space = {0:f2}",
                EuclideanSpaceUtils.CalcDistanceBetweenPoints(new double[]{5, 2, -1}, new double[]{3, -6, 4}));

            var width = 3;
            var height = 4;
            var depth = 5;

            Console.WriteLine("Volume = {0:f2}", ParallelepipedUtils.CalcVolume(width, height, depth));
            Console.WriteLine("Diagonal XYZ = {0:f2}", ParallelepipedUtils.CalcDiagonalLengthXYZ(width, height, depth));
            Console.WriteLine("Diagonal XY = {0:f2}", ParallelepipedUtils.CalcDiagonalLengthXY(width, height));
            Console.WriteLine("Diagonal XZ = {0:f2}", ParallelepipedUtils.CalcDiagonalLengthXZ(width, depth));
            Console.WriteLine("Diagonal YZ = {0:f2}", ParallelepipedUtils.CalcDiagonalYZ(height, depth));
        }
    }
}