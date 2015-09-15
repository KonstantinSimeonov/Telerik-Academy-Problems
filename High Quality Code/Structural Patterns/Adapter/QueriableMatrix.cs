namespace Adapter
{
    using System.Collections;
    using System.Collections.Generic;

    /// <summary>
    /// The wrapper class that serves as adapter.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class QueriableMatrix<T> : IEnumerable<T>
    {
        // The actual matrix
        public T[,] Value { get; set; }

        // Wrapping constructor
        public QueriableMatrix(T[,] matrix)
        {
            this.Value = matrix;
        }

        // Constructor for creating a new matrix and wrapping it automatically
        public QueriableMatrix(int rows, int cols)
            : this(new T[rows, cols])
        {
        }

        // implementing this two methods from IEnumerable<T> part actually allows the client to use matrices with LINQ

        public IEnumerator<T> GetEnumerator()
        {
            foreach (var field in this.Value)
            {
                yield return field;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}