namespace Iterator.GenericTree
{
    using System.Collections;
    using System.Collections.Generic;

    /// <summary>
    /// A sample generic tree class which we'll write an iterator for.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Tree<T> : IGenericTree<T>, IEnumerable<T>
    {
        public T Value { get; set; }

        public IGenericTree<T> Parent { get; set; }

        public IList<IGenericTree<T>> Children { get; set; }

        public Tree()
        {
            this.Parent = null;
            this.Children = new List<IGenericTree<T>>();
        }

        public Tree(T value)
            :this()
        {
            this.Value = value;
        }

        public IGenericTree<T> AddChild(T value)
        {
            var childToAdd = new Tree<T>(value);

            return this.AddChild(childToAdd);
        }

        public IGenericTree<T> AddChild(IGenericTree<T> subtree)
        {
            subtree.Parent = this;
            this.Children.Add(subtree);

            return this;
        }

        // return a convential .NET iterator using the Treetarator class
        public IEnumerator<T> GetEnumerator()
        {
            var iterator = new Treeterator<T>(this);

            while (!iterator.Finished)
            {
                yield return iterator.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
