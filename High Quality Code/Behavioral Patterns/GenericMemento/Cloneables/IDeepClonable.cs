namespace GenericMemento.Cloneables
{
    public interface IDeepClonable<T>
    {
        T DeepClone();
    }
}