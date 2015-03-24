using System;

class Matrix
{
    // 2-dimensional array reference holding the matrix
    private int[,] matrix;

    /// <summary>
    /// Default constructor for the Matrix class that supports user-initialized matrices.
    /// </summary>
    public Matrix()
    {
        // get size input
        Console.WriteLine("Rows:");
        int n = int.Parse(Console.ReadLine());
        Console.WriteLine("Cols:");
        int m = int.Parse(Console.ReadLine());

        // allocate
        matrix = new int[n, m];

        // initialize
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                Console.Write("A[{0},{1}]=", i+1, j+1);
                matrix[i, j] = int.Parse(Console.ReadLine());
            }
            Console.WriteLine();
        }
    }

    /// <summary>
    /// Constructor with size parameters for internal use by the class.
    /// </summary>
    /// <param name="n"></param>
    /// <param name="m"></param>
    private Matrix(int n, int m)
    {
        matrix = new int[n, m];
    }

    /// <summary>
    /// Constructor that wraps a two-dimensional array in the Matrix class.
    /// </summary>
    /// <param name="matrix"></param>
    public Matrix(int[,] matrix)
    {
        this.matrix = matrix;
    }

    /// <summary>
    /// Convert the given Matrix object to a string.
    /// </summary>
    /// <returns></returns>
    public override string ToString()
    {
        string stringedMatrix = "";

        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                stringedMatrix += matrix[i, j] + "  ";
            }
            stringedMatrix += "\n";
        }

        return stringedMatrix;

    }

    /// <summary>
    /// Returns the number of rows in the matrix.
    /// </summary>
    public int RowCount
    {
        get
        {
            return matrix.GetLength(0);
        }
    }

    /// <summary>
    /// Returns the number of columns in the matrix.
    /// </summary>
    public int ColCount
    {
        get
        {
            return matrix.GetLength(1);
        }
    }

    /// <summary>
    /// Indexer, which return the element on the specified row and column.
    /// </summary>
    /// <param name="row"></param>
    /// <param name="col"></param>
    /// <returns></returns>
    public int this[int row, int col]
    {
        get
        {
            return matrix[row, col];
        }
    }

    /// <summary>
    /// Supports addition of two matrices of compatible dimensions.
    /// Returns the left-hand side argument if the dimensions are incompatible.
    /// </summary>
    /// <param name="lhs"></param>
    /// <param name="rhs"></param>
    /// <returns></returns>
    public static Matrix operator +(Matrix lhs, Matrix rhs)
    {
        // check for correct dimensions
        if (lhs.RowCount == rhs.RowCount && lhs.ColCount == rhs.ColCount)
        {
            // create a new matrix which will hold the sum of the two arguments
            Matrix sum = new Matrix(lhs.RowCount, lhs.ColCount);

            // iterate through the matrices
            for (int i = 0; i < sum.RowCount; i++)
            {
                for (int j = 0; j < sum.ColCount; j++)
                {
                                        // use the indexer here
                    sum.matrix[i, j] = lhs[i, j] + rhs[i, j];
                }
            }
            // return the result
            return sum;

        }
        else
        {
            Console.WriteLine("Dimension are different.");
            return lhs;
        }
    }

    /// <summary>
    /// Subtracts two given matrices and returns the result.
    /// If the dimensions are incompatible, returns the left-hand side value.
    /// </summary>
    /// <param name="lhs"></param>
    /// <param name="rhs"></param>
    /// <returns></returns>
    public static Matrix operator -(Matrix lhs, Matrix rhs)
    {
        if (lhs.RowCount == rhs.RowCount && lhs.ColCount == rhs.ColCount)
        {
            Matrix sum = new Matrix(lhs.RowCount, lhs.ColCount);

            for (int i = 0; i < sum.RowCount; i++)
            {
                for (int j = 0; j < sum.ColCount; j++)
                {
                    sum.matrix[i, j] = lhs[i, j] - rhs[i, j];
                }
            }

            return sum;

        }
        else
        {
            Console.WriteLine("Dimension are different.");
            return lhs;
        }
    }


    /// <summary>
    /// Multiplies two given matrices and returns the result.
    /// If the dimensions are incompatible, returns the left-hand side.
    /// </summary>
    /// <param name="lhs"></param>
    /// <param name="rhs"></param>
    /// <returns></returns>
    public static Matrix operator*(Matrix lhs, Matrix rhs)
    {
        // multiplication of matrices is different from addition/subtraction, dimension requirement are also different
        if (lhs.ColCount == rhs.RowCount)
        {
            Matrix product = new Matrix(lhs.RowCount, rhs.ColCount);

            for (int i = 0; i < product.RowCount; i++)
            {
                for (int j = 0; j < product.ColCount; j++)
                {
                    // calculate the element at position (i,j) in the product
                    int prod = 0;

                    for (int k = 0, m = 0; k < lhs.ColCount && m < rhs.RowCount; k++, m++)
                    {
                        prod += lhs[i, k] * rhs[m, j];
                    }
                    // initialize the element at (i,j) in the product
                    product.matrix[i, j] = prod;
                }
            }

            return product;
        }
        else
        {
            Console.WriteLine("Uncompatible dimensions");
            return lhs;
        }
    }
}

