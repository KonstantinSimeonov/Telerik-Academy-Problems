namespace GenericMemento
{
    public interface IStateSaver<T>
    {
        T GetState();
        bool HasStates { get; }

        void SaveState(T obj);
    }
}