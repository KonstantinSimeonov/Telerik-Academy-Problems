using System;

//Problem 1. Fill the matrix

//Write a program that fills and prints a matrix of size (n, n);


class MatrixFiller
{
    static void Main()
    {
        Console.WriteLine("N:");
        int n = int.Parse(Console.ReadLine());

        int[,] matrix = new int[n, n];

        // a)
        for (int i = 0, val = 1; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                // just put j as first index, so we go down istead of right
                matrix[j, i] = val++;
            }
        }

        // put printing code in a method, nothing too fancy, just saves some space
        PrintMultiArray(matrix,'a');


        // b)
        for (int i = 0, cellVal = 1; i < n; i++)
        {   // if the number of the current column is even, then start from row 0 and increment row, else start from n-1 and decrement row
            for (int j = ((i & 1) == 0 ? 0 : n - 1); j < n && j >= 0; j += ((i & 1) == 0 ? 1 : -1))
            {
                matrix[j, i] = cellVal++;
            }
        }

        PrintMultiArray(matrix,'b');

        // c)
        int cellValue = 1;
        // draw left side
        for (int i = n - 1; i >= 0; i--)
        {
            for (int j = 0; j < n - i; j++)
            {
                matrix[i + j, j] = cellValue++;
            }
        }
        // draw right side
        for (int i = 0; i < n - 1; i++)
        {
            for (int k = 0, j = 1 + i; j < n; j++, k++)
            {
                matrix[k, j] = cellValue++;
            }
        }

        PrintMultiArray(matrix,'c');


        // d)
        // set up helpers
        int size = n;
        int row = 0, col = 0;
        int value = 1;
        int counter = 0;

        while (value <= n * n) // the n*n will be the last value which we'll assign, so it's convenient to iterate until we assign it
        {
            // we're at the top now, start going down until we've done enough iterations
            while (counter++ < size)
            {
                matrix[row++, col] = value++;
            }
            row--; // if !(count < size), then counter = size. that's why we'll decrement it, so we're back into the matrix
            
            col++; // start going right from the next element on this row
            counter = 0; // set the counter to 0
            while (counter++ < size - 1) // our size is less now, because the first column is full
            {
                matrix[row, col++] = value++; // assign value
            }
            col--; // col = size, so we decrement in by 1

            row--; // start going up from the element direct above matrix[size,size]
            counter = 0;
            while (counter++ < size - 1) // the size is less, because the last row is full
            {
                matrix[row--, col] = value++;
            }
            row++; // row is out of out workspace now, so we need to increment it by one

            col--; // start going left from the rightmost unassigned element
            counter = 0;
            size -= 1;
            while (counter++ < size - 1)
            {
                matrix[row, col--] = value++;
            }
            col++;
            row++;
            counter = 0;
            size -= 1;

        }

        PrintMultiArray(matrix,'d');






    }

    public static void PrintMultiArray(int[,] arr, char part)
    {
        Console.WriteLine(part+")");
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

