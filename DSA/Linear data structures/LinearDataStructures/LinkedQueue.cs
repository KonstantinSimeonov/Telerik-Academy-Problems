namespace LinearDataStructures
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using Contracts;

    /// <summary>
    /// Implement the ADT queue as dynamic linked list.
    /// Use generics(LinkedQueue<T>) to allow storing different data types in the queue.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class LinkedQueue<T> : IQueue<T>
    {
        private ILinkedList<T> queue;

        public LinkedQueue()
        {
            this.queue = new LinkedList<T>();
        }

        public int Count
        {
            get
            {
                return this.queue.Count;
            }
        }

        public void Enqueue(T item)
        {
            this.queue.Add(item);
        }

        public T Peek()
        {
            return this.queue.First.Value;
        }

        public T Dequeue()
        {
            if (this.Count <= 0)
            {
                throw new InvalidOperationException("Cannot dequeue from an empty queue");
            }

            var result = this.Peek();

            this.queue.Remove(result);

            return result;
        }

        public IEnumerator<T> GetEnumerator()
        {
            return this.queue.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}