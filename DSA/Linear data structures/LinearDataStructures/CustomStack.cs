namespace LinearDataStructes
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    using LinearDataStructures.Contracts;

    public class CustomStack<T> : IStack<T>
    {
        private const int DefaultCapacity = 4;
        private const int ExpandSize = 2;

        private T[] items;

        public CustomStack()
        {
            this.items = new T[DefaultCapacity];
            this.Count = 0;
        }

        public int Count { get; private set; }

        public void Push(T item)
        {
            if (this.Count == this.items.Length)
            {
                this.Expand();
            }

            this.items[this.Count++] = item;
        }

        public T Peek()
        {
            if (this.Count - 1 < 0)
            {
                throw new InvalidOperationException("Cannot peek the top of an empty stack!");
            }

            return this.items[this.Count - 1];
        }

        public T Pop()
        {
            if (this.Count - 1 < 0)
            {
                throw new InvalidOperationException("Cannot peek the top of an empty stack!");
            }

            var result = this.items[--this.Count];

            if (this.Count < this.items.Length / ExpandSize)
            {
                this.Shrink();
            }

            return result;
        }

        private void Expand()
        {
            var store = this.items;
            this.items = new T[store.Length * ExpandSize];

            for (int i = 0; i < store.Length; i++)
            {
                this.items[i] = store[i];
            }
        }

        private void Shrink()
        {
            var store = this.items;
            this.items = new T[store.Length / ExpandSize];

            for (int i = 0; i < items.Length; i++)
            {
                this.items[i] = store[i];
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0, length = this.Count; i < length; i++)
            {
                yield return this.items[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}