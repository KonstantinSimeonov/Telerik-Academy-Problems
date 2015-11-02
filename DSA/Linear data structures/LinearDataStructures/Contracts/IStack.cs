namespace LinearDataStructures.Contracts
{
    using System.Collections.Generic;

    public interface IStack<T> : IEnumerable<T>
    {
        int Count { get; }

        void Push(T item);

        T Peek();

        T Pop();
    }
}
