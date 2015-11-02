namespace LinearDataStructures.Contracts
{
    public interface ILinkedListNode<T>
    {
        T Value { get; set; }

        ILinkedListNode<T> Next { get; set; }
    }
}
