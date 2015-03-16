using System;

class Matrix<T>
    where T : struct, IComparable, IFormattable // put some constraints
{
    // 2-dimensional array reference holding the matrix
    private T[,] matrix;

    /// <summary>
    /// Constructor with size parameters for internal use by the class.
    /// </summary>
    /// <param name="n"></param>
    /// <param name="m"></param>
    private Matrix(int n, int m)
    {
        matrix = new T[n, m];
    }

    /// <summary>
    /// Constructor that wraps a two-dimensional array in the Matrix class.
    /// </summary>
    /// <param name="matrix"></param>
    public Matrix(T[,] matrix)
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
    public T this[int row, int col]
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
    public static Matrix<T> operator +(Matrix<T> lhs, Matrix<T> rhs)
    {
        // check for correct dimensions
        if (lhs.RowCount == rhs.RowCount && lhs.ColCount == rhs.ColCount)
        {
            // create a new matrix which will hold the sum of the two arguments
            Matrix<T> sum = new Matrix<T>(lhs.RowCount, lhs.ColCount);

            // iterate through the matrices
            for (int i = 0; i < sum.RowCount; i++)
            {
                for (int j = 0; j < sum.ColCount; j++)
                {
                    // use dynamic cause sad
                    sum.matrix[i, j] = ((dynamic)lhs[i, j] + rhs[i, j]);
                }
            }
            // return the result
            return sum;

        }
        else
        {
            throw new ArgumentException("Dimension are different.");
        }
    }

    /// <summary>
    /// Subtracts two given matrices and returns the result.
    /// If the dimensions are incompatible, returns the left-hand side value.
    /// </summary>
    /// <param name="lhs"></param>
    /// <param name="rhs"></param>
    /// <returns></returns>
    public static Matrix<T> operator -(Matrix<T> lhs, Matrix<T> rhs)
    {
        if (lhs.RowCount == rhs.RowCount && lhs.ColCount == rhs.ColCount)
        {
            Matrix<T> sum = new Matrix<T>(lhs.RowCount, lhs.ColCount);

            for (int i = 0; i < sum.RowCount; i++)
            {
                for (int j = 0; j < sum.ColCount; j++)
                {
                    sum.matrix[i, j] = ((dynamic)lhs[i, j] - rhs[i, j]);
                }
            }

            return sum;

        }
        else
        {
            throw new ArgumentException("Dimension are different.");
        }
    }


    /// <summary>
    /// Multiplies two given matrices and returns the result.
    /// If the dimensions are incompatible, returns the left-hand side.
    /// </summary>
    /// <param name="lhs"></param>
    /// <param name="rhs"></param>
    /// <returns></returns>
    public static Matrix<T> operator *(Matrix<T> lhs, Matrix<T> rhs)
    {
        // multiplication of matrices is different from addition/subtraction, dimension requirement are also different
        if (lhs.ColCount == rhs.RowCount)
        {
            Matrix<T> product = new Matrix<T>(lhs.RowCount, rhs.ColCount);

            for (int i = 0; i < product.RowCount; i++)
            {
                for (int j = 0; j < product.ColCount; j++)
                {
                    // calculate the element at position (i,j) in the product
                    dynamic prod = 0;

                    for (int k = 0, m = 0; k < lhs.ColCount && m < rhs.RowCount; k++, m++)
                    {
                        prod += ((dynamic)lhs[i, k] *rhs[m, j]);
                    }
                    // initialize the element at (i,j) in the product
                    product.matrix[i, j] = (T)prod;
                }
            }

            return product;
        }
        else
        {
            throw new ArgumentException("Uncompatible dimensions");
        }
    }

    /// <summary>
    /// Returns true if the given matrix has a non-zero item.
    /// </summary>
    /// <param name="m"></param>
    /// <returns></returns>
    public static bool operator true(Matrix<T> m)
    {
        for (int i = 0; i < m.RowCount; i++)
        {
            for (int j = 0; j < m.ColCount; j++)
            {
                if ((dynamic)m[i, j] != 0)
                    return true;
            }
        }

        return false;
    }

    /// <summary>
    /// Returns true if the matrix doesn't have a non-zero item.
    /// </summary>
    /// <param name="m"></param>
    /// <returns></returns>
    public static bool operator false(Matrix<T> m)
    {
        return m ? false : true;
    }

    
}

