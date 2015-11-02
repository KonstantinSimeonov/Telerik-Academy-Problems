namespace LinearDataStructures.Contracts
{
    using System.Collections.Generic;

    public interface ILinkedList<T> : ICollection<T>
    {
        ILinkedListNode<T> First { get; }

        ILinkedListNode<T> Last { get; }

        ILinkedList<T> GetSortedList();
    }
}
