namespace GenericMemento.CloningStrategies
{
    using System;

    using GenericMemento.Cloneables;

    /// <summary>
    /// Provides a custom implementation of cloning.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class CustomCloning<T> : ICloningStrategy<T>
    {
        public CustomCloning()
        {
        }

        public bool IsMatch(T obj)
        {
            return obj as IDeepClonable<T> != null;
        }

        public T Clone(T obj)
        {
            return (obj as IDeepClonable<T>).DeepClone();
        }
    }
}
