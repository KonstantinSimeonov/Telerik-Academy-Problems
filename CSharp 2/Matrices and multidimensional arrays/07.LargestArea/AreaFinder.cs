using System;

//Problem 7.* Largest Area in matrix

//Write a program that finds the largest Area of equal neighbour elements in a rectangular matrix and prints its size.




class recAreaFinder
{
    // reference to a a bool array which will represent the fields in the matrix that we've already visited
    private static bool[,] notUsed;
    private static int currentArea = 0;
    private static int callCount = 0;

    /// <summary>
    /// Return the maximum area of equal integers in a matrix.
    /// </summary>
    /// <param name="arr"></param>
    /// <returns></returns>
    public static int getMaxArea(int[,] arr)
    {
        // allocate a bool array that will be bigger than the int matrix
        // and pad it with on the sides
        notUsed = new bool[arr.GetLength(0) + 2, arr.GetLength(1) + 2];

        for (int i = 0; i < notUsed.GetLength(0); i++)
        {
            notUsed[i, 0] = notUsed[i, notUsed.GetLength(1) - 1] = true;
        }

        for (int i = 0; i < notUsed.GetLength(1); i++)
        {
            notUsed[0, i] = notUsed[notUsed.GetLength(0) - 1, i] = true;
        }


        int maxArea = 0;
        for (int i = 0; i < arr.GetLength(0); i++)
        {

            for (int j = 0; j < arr.GetLength(1); j++)
            {
                currentArea = 0;
                // if we haven't visited that field, calculate the area which it is a part of
                if (!notUsed[i + 1, j + 1])
                {
                    // calculate the area for that field
                    recArea(arr, i, j);

                    if (maxArea < currentArea)
                    {
                        maxArea = currentArea;
                    }
                }
            }
        }



        return maxArea;

    }

    // prints the bool array
    private static void PrintPaddedBoolArray(bool[,] arr)
    {
        for (int i = 0; i < arr.GetLength(0) + 2; i++)
        {
            for (int j = 0; j < arr.GetLength(1) + 2; j++)
            {
                if (i == 0 || i == arr.GetLength(0) + 1 || j == 0 || j == arr.GetLength(1) + 1)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                }
                Console.Write((notUsed[i, j] ? 1 : 0) + "  ");
                Console.ForegroundColor = ConsoleColor.White;
            }
            Console.WriteLine("\n");
        }
    }


    public static void recArea(int[,] arr, int row, int col)
    {
        callCount++; // counting the operations, just out of curiosity

        if (!notUsed[row, col + 1]) // if the field above hasn't been visited
        {
            if (arr[row, col] == arr[row - 1, col]) // if it's equal
            {
                currentArea++; // increase area
                notUsed[row, col + 1] = true; // mark it as visited
                recArea(arr, row - 1, col); // visit it
            }
        }

        // same idea as above for the next 3 comparisons
        if (!notUsed[row + 2, col + 1])
        {
            if (arr[row, col] == arr[row + 1, col])
            {
                currentArea++;
                notUsed[row + 2, col + 1] = true;
                recArea(arr, row + 1, col);
            }
        }

        if (!notUsed[row + 1, col])
        {
            if (arr[row, col] == arr[row, col - 1])
            {
                currentArea++;
                notUsed[row + 1, col] = true;
                recArea(arr, row, col - 1);
            }
        }

        if (!notUsed[row + 1, col + 2])
        {
            if (arr[row, col] == arr[row, col + 1])
            {
                currentArea++;
                notUsed[row + 1, col + 2] = true;
                recArea(arr, row, col + 1);
            }
        }

        return;
    }
    static void Main()
    {


        int[,] demo = {
                        {3,3,2,2,2,4},
                        {3,3,3,2,4,4},
                        {3,3,1,2,3,3},
                        {4,3,3,3,3,3},
                        {4,3,1,1,1,3},
                        {4,3,3,2,1,10},
                        {9,9,9,9,9,9}
                      };
        for (int i = 0; i < demo.GetLength(0); i++)
        {
            for (int j = 0; j < demo.GetLength(1); j++)
            {
                Console.Write(demo[i, j] + "  ");
            }
            Console.Write("\n\n");
        }

        Console.WriteLine(getMaxArea(demo));
        Console.Write(callCount);
    }
}

