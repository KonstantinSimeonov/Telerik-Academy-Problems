namespace Iterator
{
    /// <summary>
    /// Interface for a custom generic interator.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IIterator<T>
    {
        T First { get; }
        T Current { get; }
        T Next { get; }
        bool Finished { get; }

        void Reset();
    }
}