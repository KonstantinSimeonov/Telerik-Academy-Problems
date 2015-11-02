namespace LinearDataStructures.Contracts
{
    using System.Collections.Generic;

    public interface IQueue<T> : IEnumerable<T>
    {
        int Count { get; }

        void Enqueue(T item);

        T Peek();

        T Dequeue();
    }
}
