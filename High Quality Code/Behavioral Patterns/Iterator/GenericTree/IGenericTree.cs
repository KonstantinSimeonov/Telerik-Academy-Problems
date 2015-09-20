namespace Iterator.GenericTree
{
    using System.Collections.Generic;

    public interface IGenericTree<T>
    {
        T Value { get; set; }

        IGenericTree<T> Parent { get; set; }
        IList<IGenericTree<T>> Children { get; set; }

        // chaining is nice :D
        IGenericTree<T> AddChild(T value);
        IGenericTree<T> AddChild(IGenericTree<T> subtree);
    }
}