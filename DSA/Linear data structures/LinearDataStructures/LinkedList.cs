namespace LinearDataStructures
{
    using System.Collections;
    //Implement the data structure linked list.

    //Define a class ListItem<T> that has two fields: value(of type T) and NextItem(of type ListItem<T>).
    //Define additionally a class LinkedList<T> with a single field FirstElement(of type ListItem<T>).

    using System.Collections.Generic;
    using Contracts;

    /// <summary>
    /// Concrete implementation of a linked list node.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ListItem<T> : ILinkedListNode<T>
    {
        public T Value { get; set; }

        public ILinkedListNode<T> Next { get; set; }

        public ListItem(T item)
        {
            this.Value = item;
        }
    }

    /// <summary>
    /// Concrete implementation of the linked list ADT.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class LinkedList<T> : ILinkedList<T>
    {
        public ILinkedListNode<T> First { get; private set; }
        public ILinkedListNode<T> Last { get; private set; }

        public LinkedList()
        {
            this.Clear();
        }

        public int Count { get; private set; }

        public bool IsReadOnly
        {
            get
            {
                return false;
            }
        }

        public void Add(T item)
        {
            if (this.First == null)
            {
                this.Count++;
                this.First = this.Last = new ListItem<T>(item);
                return;
            }

            this.Count++;
            this.Last.Next = new ListItem<T>(item);
            this.Last = this.Last.Next;
        }

        public bool Remove(T item)
        {
            var current = this.First;

            if (current.Value.Equals(item))
            {
                this.First = this.First.Next;
                this.Count--;
                return true;
            }

            while (current.Next != null)
            {
                if (current.Next.Value.Equals(item))
                {
                    current.Next = current.Next.Next;
                    this.Count--;
                    return true;
                }
                current = current.Next;
            }

            return false;
        }

        public IEnumerator<T> GetEnumerator()
        {
            var current = this.First;

            while (current != null)
            {
                yield return current.Value;
                current = current.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        /// <summary>
        /// Returns a list with the same content, but sorted.
        /// </summary>
        /// <returns></returns>
        public ILinkedList<T> GetSortedList()
        {
            var sorter = new SortedSet<T>();

            this.ForEach(element => sorter.Add(element));

            var result = new LinkedList<T>();

            sorter.ForEach(element => result.Add(element));

            return result;
        }

        public void Clear()
        {
            this.First = this.Last = null;
            this.Count = 0;
        }

        public bool Contains(T item)
        {
            foreach (var element in this)
            {
                if (element.Equals(item))
                {
                    return true;
                }
            }

            return false;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            var current = this.First;

            for (int i = arrayIndex; i < array.Length && current != null; i++, current = current.Next)
            {
                array[i] = current.Value;
            }
        }
    }
}