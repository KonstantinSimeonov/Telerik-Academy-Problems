namespace Iterator
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Iterator.GenericTree;

    /// <summary>
    /// Supports the iteration operations defined in the interface using DFS.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    internal class Treeterator<T> : IIterator<T>
    {
        private Stack<IGenericTree<T>> dfsNodes;

        private IGenericTree<T> tree;

        private IGenericTree<T> currentNode;

        private bool finished;

        public Treeterator(IGenericTree<T> tree)
        {
            this.Tree = tree;
            this.finished = false;
            this.dfsNodes = new Stack<IGenericTree<T>>();
            this.dfsNodes.Push(this.Tree);
        }

        public IGenericTree<T> Tree
        {
            get
            {
                return this.tree;
            }

            set
            {
                this.tree = value;
                this.Reset();
            }
        }

        public bool Finished
        {
            get
            {
                return this.finished;
            }
        }

        public T First
        {
            get
            {
                return this.tree.Value;
            }
        }

        public T Current
        {
            get
            {
                return this.currentNode.Value;
            }
        }

        public T Next
        {
            get
            {
                var result = this.currentNode.Value;

                foreach (var childNode in this.currentNode.Children)
                {
                    this.dfsNodes.Push(childNode);
                }


                this.currentNode = this.dfsNodes.Pop();

                this.finished = this.dfsNodes.Count == 0;

                return result;
            }
        }

        public void Reset()
        {
            this.currentNode = this.tree;
        }
    }
}
