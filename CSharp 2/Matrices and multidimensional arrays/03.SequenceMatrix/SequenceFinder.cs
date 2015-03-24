using System;

//Problem 3. Sequence n matrix

//We are given a matrix of strings of size N x M. Sequences in the matrix we define
//as sets of several neighbour elements located on the same line, column or diagonal.
//Write a program that finds the longest sequence of equal strings in the matrix.

class SequenceFinder
{
    
    static void Main()
    {
        // demo
        //string[,] matrix = { { "hh", "hh", "hh" }, { "fifi", "ha", "lol" }, { "xx", "lolo", "ha" }, { "lolo", "xx", "xx" } };

        // initialize own matrix
        string[,] matrix = new string[int.Parse(Console.ReadLine()), int.Parse(Console.ReadLine())];

        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                matrix[i, j] = Console.ReadLine();
            }
        }

        
        // declare helpers
        int maxLength = 0, currentLength = 0;
        string maxElement = "";

        // for all elements
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                currentLength = 0;
                // calculate the length of the vertical sequence beggining from an element
                for (int k = i; k < matrix.GetLength(0); k++ )
                {
                    currentLength += (matrix[i, j] == matrix[k, j]) ? 1 : 0;
                }

                // if bigger
                if (currentLength > maxLength)
                {
                    maxLength = currentLength;
                    maxElement = matrix[i, j];
                }

                currentLength = 0;
                // calculate length of the horizontal sequence beggining from the element
                for (int k = j; k < matrix.GetLength(1); k++)
                {
                    currentLength += (matrix[i, j] == matrix[i, k]) ? 1 : 0;
                }

                if (currentLength > maxLength)
                {
                    maxLength = currentLength;
                    maxElement = matrix[i, j];
                }

                currentLength = 0;
                // calculate length of the one diagonal sequence
                for (int k = i, n = j; k < matrix.GetLength(0) && n < matrix.GetLength(1); k++, n++)
                {
                    currentLength += (matrix[i, j] == matrix[k, n]) ? 1 : 0;
                }

                if (currentLength > maxLength)
                {
                    maxLength = currentLength;
                    maxElement = matrix[i, j];
                }

                currentLength = 0;
                // do the same for the other diagonal
                for (int k = i, n = j; k < matrix.GetLength(0) && n >=0; k++, n--)
                {
                    currentLength += (matrix[i, j] == matrix[k, n]) ? 1 : 0;
                }

                if (currentLength > maxLength)
                {
                    maxLength = currentLength;
                    maxElement = matrix[i, j];
                }

            }
        }

        // print
        Console.WriteLine("'{0}' {1}", maxElement, maxLength);

    }

    
}

