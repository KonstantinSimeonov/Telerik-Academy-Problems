namespace Adapter
{
    using System;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            var rng = new Random();
            var normalMatrix = new int[3, 4];
            var queriableMatrix = new QueriableMatrix<int>(normalMatrix) // wrap the matrix
                                    .Select(x => (rng.Next() % 20) + 51) // the adapter pattern allows the use of linq on matrices
                                    .OrderBy(x => x) // some LINQ operations just for the sake of showing off
                                    .Select(x => (char)x)
                                    .ToQueriableMatrix(4, 3)
                                    .Skip(2)
                                    .ToQueriableMatrix(2, 5);

            PrintMatrix(queriableMatrix.Value);
            Console.WriteLine("\nim kewl\n");
            PrintMatrix(queriableMatrix.ToMatrix(5, 2));
        }

        private static void PrintMatrix<T>(T[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write("{0, 4}", matrix[i, j]);
                }
                Console.WriteLine();
            }
        }
    }
}