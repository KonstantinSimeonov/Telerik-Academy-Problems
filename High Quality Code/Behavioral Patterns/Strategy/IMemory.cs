namespace GenericMemento
{
    public interface IMemory<T>
    {
        T GetItem();
        bool IsEmpty { get; }

        void PushItem(T item);
    }
}