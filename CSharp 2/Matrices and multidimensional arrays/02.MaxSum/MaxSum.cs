using System;

//Problem 2. Maximal sum

//Write a program that reads a rectangular matrix of size N x M and finds in it the square 3 x 3
//that has maximal sum of its elements.

class MaxSum
{
    static void Main()
    {
        Console.WriteLine("Rows:");
        int n = int.Parse(Console.ReadLine());
        Console.WriteLine("Cols:");
        int m = int.Parse(Console.ReadLine());

        int[,] matrix = new int[n, m];

        // initialize code
        //for (int i = 0; i < n; i++)
        //{
        //    for (int j = 0; j < m; j++)
        //    {
        //        matrix[i, j] = int.Parse(Console.ReadLine());
        //    }
        //}

        // DEMO MATRICES:

        //for (int i = 0, value = 1; i < n; i++)
        //{
        //    for (int j = 0; j < m; j++)
        //    {
        //        matrix[i, j] = value++;
        //    }
        //}

        //for (int i = 0, value = 1; i < n; i++)
        //{
        //    for (int j = 0; j < m; j++)
        //    {
        //        matrix[i, j] = (value & 3) == 0 ? -value : value;
        //        value++;
        //    }
        //}

        for (int i = 0, value = 1; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                matrix[i, j] = (value & 3) == 0 ? value : -value / 2;
                value++;
            }
        }


        Console.WriteLine("Matrix:");
        PrintMultiArray(matrix);

        int maxSum = int.MinValue;
        int startI = 0, startJ = 0; // somewhere to store the indecis of the biggest sum found

        // for every element in the range [0,n-3][0,m-3], there is a square
        for (int i = 0; i <= n - 3; i++)
        {
            for (int j = 0; j <= m - 3; j++)
            {
                int currentSum = 0;
                // for every element, find the sum of those squares
                for (int k = 0; k < 3; k++)
                {
                    for (int t = 0; t < 3; t++)
                    {
                        currentSum += matrix[i + k, j + t];
                    }
                }
                // compare it to the current maximum sum
                if (currentSum > maxSum)
                {
                    // save indecies if new maxSum
                    startI = i;
                    startJ = j;
                    // save sum
                    maxSum = currentSum;
                }

            }
        }

        // print the square using the indeces we stored. Sorry for the bad formatting!
        for (int i = startI; i < startI + 3 && i < n; i++)
        {
            for (int j = startJ; j < startJ + 3 && j < m; j++)
            {
                
                Console.Write(matrix[i, j] + " ");
                if (matrix[i, j] < 10)
                {
                    Console.Write("  ");
                }
                else if (matrix[i, j] < 100)
                {
                    Console.Write(" ");
                }

            }
            Console.WriteLine("\n");
        }

    }

    public static void PrintMultiArray(int[,] arr)
    {
        for (int k = 0; k < arr.GetLength(0); k++)
        {
            for (int m = 0; m < arr.GetLength(1); m++)
            {
                Console.Write(arr[k, m] + " ");

                if (arr[k, m] < 10)
                {
                    Console.Write("  ");
                }
                else if (arr[k, m] < 100)
                {
                    Console.Write(" ");
                }
            }
            Console.WriteLine("\n");
        }

        Console.WriteLine("\n\n");
    }

}

