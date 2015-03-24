namespace BinarySearchTree
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Runtime.Serialization.Formatters.Binary;
    using System.Reflection;

    //Problem 6.* Binary search tree

    //Define the data structure binary search tree with operations
    //for "adding new element", "searching element" and "deleting elements". It is not necessary to keep the tree balanced.
    //Implement the standard methods from System.Object – ToString(), Equals(…), GetHashCode() and the operators for comparison == and !=.
    //Add and implement the ICloneable interface for deep copy of the tr
    //and class TreeNode (for the tree elements). Implement IEnumerable<T> to traverse the tree.
    [Serializable]
    class Node<T>
    {
        public const int NUMBER_OF_CHIDLREN = 2;
        public T Item { get; private set; } // hold the value
        public int Key { get; private set; } // hold the key
        public Node<T>[] child; // hold pointers to children

        // CONSTRUCTORS

        public Node(T item, int key)
        {
            this.Item = item;
            this.Key = key;
            child = new Node<T>[NUMBER_OF_CHIDLREN];
        }

        public override string ToString()
        {
            return string.Format("Value: {0}, key: {3} left child: {1}, right child: {2}", Item, child[0] == null ? "no left child" : child[0].Key.ToString(), child[1] == null ? "no right child" : child[1].Key.ToString(), Key);
        }
    }
    [Serializable]
    class BinarySearchTree<T> : IEnumerable<T>, ICloneable
        where T : IComparable<T>
    {

        public Node<T> Root { get; private set; }

        /// <summary>
        /// Constructor for empty tree.
        /// </summary>
        public BinarySearchTree()
        {
            Root = null;
        }

        /// <summary>
        /// Constructor for a tree with a given node as a root.
        /// </summary>
        /// <param name="root"></param>
        /// <param name="key"></param>
        public BinarySearchTree(T root, int key) // create a tree with a root
        {
            this.Root = new Node<T>(root, key);
        }

        /// <summary>
        /// Inserts an item with the corresponding key in the tree. If an element with this key already exists, an exception will be thrown.
        /// </summary>
        /// <param name="item"></param>
        /// <param name="key"></param>
        public void Insert(T item, int key)
        {
            if (Root == null)
            {
                Root = new Node<T>(item, key);
                return;
            }

            if (Root.Key == key)
            {
                throw new ArgumentException("Key is already present in the tree!");
            }

            var parent = Root;
            var current = Root.child[Root.Key > key ? 0 : 1];

            while (current != null)
            {
                if (current.Key == key)
                    return;
                parent = current;
                current = current.child[current.Key > key ? 0 : 1];

            }

            parent.child[parent.Key > key ? 0 : 1] = new Node<T>(item, key);

        }

        /// <summary>
        /// Returns the item corresponding to the key. Throws an exception if no such item exists.
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public T GetItemWithKey(int key)
        {
            return GetRef(Root, key).Item;
        }

        /// <summary>
        /// Deletes an item with the corresponding key from the tree
        /// </summary>
        /// <param name="key"></param>
        public void DeleteItemWithKey(int key)
        {
            // it's too ugly

            if (Root.Key == key) // remove root if the keys match
            {
                RemoveRoot();
                return;
            }

            var current = Root;
            var parent = Root;
            int direction = 0;

            while (current.Key != key) // search for the element
            {
                parent = current;
                direction = current.Key > key ? 0 : 1;
                current = current.child[direction];
                if (current == null) // if no such element found, throw an exception
                {
                    throw new KeyNotFoundException();
                }
            }

            if (current.child[0] == null && current.child[1] == null) // if the node is a leaf, remove
            {
                parent.child[direction] = null;
            }
            else if (current.child[0] == null) // if the node has only a left child
            {
                parent.child[direction] = parent.child[direction].child[1];
            }
            else if (current.child[1] == null) // if the node has only a right child
            {
                parent.child[direction] = parent.child[direction].child[0];
            }
            else
            {
                // if the node has two children, find its successor

                var successor = GetSuccessor(current, direction); // get the successor and its parent
                parent.child[direction] = successor.Key; // put it in the place of the node
                successor.Value.child[successor.Value.Key > successor.Key.Key ? 0 : 1] = null; // remove the successor from the bottom of the tree
                parent.child[direction].child[0] = current.child[0]; // set the children of the successor to be the children of the deleted node
                parent.child[direction].child[1] = current.child[1];
            }
        }

        /// <summary>
        /// Returns true if the invoking tree is equal to the object passes as parameter.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            var objAsBinarySearchTree = obj as BinarySearchTree<T>;

            if (objAsBinarySearchTree == null)
            {
                return false;
            }

            if (ReferenceEquals(this.Root, objAsBinarySearchTree.Root))
            {
                return true;
            }

            foreach (var node in objAsBinarySearchTree.Traversal(objAsBinarySearchTree.Root))
            {
                try
                {
                    GetItemWithKey(node.Key);
                }
                catch (KeyNotFoundException e)
                {
                    return false;
                }
            }

            foreach (var node in this.Traversal(Root))
            {
                try
                {
                    objAsBinarySearchTree.GetItemWithKey(node.Key);
                }
                catch (KeyNotFoundException e)
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// Returns true if the two trees contain the same elements(independent of element distribution in the tree).
        /// </summary>
        /// <param name="lhs"></param>
        /// <param name="rhs"></param>
        /// <returns></returns>
        public static bool operator ==(BinarySearchTree<T> lhs, BinarySearchTree<T> rhs)
        {
            foreach (var node in rhs.Traversal(rhs.Root))
            {
                try
                {
                    lhs.GetItemWithKey(node.Key);
                }
                catch (KeyNotFoundException e)
                {
                    return false;
                }
            }

            foreach (var node in lhs.Traversal(lhs.Root))
            {
                try
                {
                    rhs.GetItemWithKey(node.Key);
                }
                catch (KeyNotFoundException e)
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// Return true if the trees differ in content.
        /// </summary>
        /// <param name="lhs"></param>
        /// <param name="rhs"></param>
        /// <returns></returns>
        public static bool operator !=(BinarySearchTree<T> lhs, BinarySearchTree<T> rhs)
        {
            return !(lhs == rhs);
        }


        /// <summary>
        /// Return the hash-code for the current instance of the BST.
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            int hash = 37;

            foreach (var item in this)
            {
                hash = hash * 101 ^ item.GetHashCode();
            }

            return hash;
        }

        /// <summary>
        /// Prints the tree recursively. Provides aditional information.
        /// </summary>
        /// <param name="current"></param>
        public void Print(Node<T> current)
        {
            if (current == null)
                return;

            Console.WriteLine(current);
            Print(current.child[0]);
            Print(current.child[1]);
        }

        /// <summary>
        /// Return the enumerator for the type.
        /// </summary>
        /// <returns></returns>
        public IEnumerator<T> GetEnumerator()
        {
            foreach (Node<T> node in Traversal(Root))
            {
                yield return node.Item;
            }
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            yield return GetEnumerator();
        }

        /// <summary>
        /// Performs a deep copy on the tree.
        /// </summary>
        /// <returns></returns>
        public object Clone()
        {
            var stream = new MemoryStream();
            var formatter = new BinaryFormatter();

            formatter.Serialize(stream, this);

            stream.Position = 0;

            var clone = formatter.Deserialize(stream);

            return clone as BinarySearchTree<T>;
        }

        public override string ToString()
        {
            return string.Join(", ", this);
        }

        /// <summary>
        /// ugly as fekk
        /// </summary>
        protected void RemoveRoot()
        {
            if (Root.child[0] == null && Root.child[1] == null) // if the root has no children, simply remove
            {
                Root = null;
            }
            else if (Root.child[0] == null) // if the root has only a left child
            {
                Root = Root.child[1];
            }
            else if (Root.child[1] == null) // if the root has only a right child
            {
                Root = Root.child[0];
            }
            else
            {
                // if the root has two children, find its successor
                int direction = 1;
                var successor = GetSuccessor(Root, direction); // get the successor and its parent

                // store the children of the root
                var left = Root.child[0];
                var right = Root.child[1];

                Root = successor.Key; // put the successor in the place of the root
                successor.Value.child[successor.Value.Key > successor.Key.Key ? 0 : 1] = null; // remove the successor from the bottom of the tree
                Root.child[0] = left; // set the children of the successor to be the children of the deleted root
                Root.child[1] = right;
            }
        }

        /// <summary>
        /// Yields a collection out of the tree.
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        protected IEnumerable<Node<T>> Traversal(Node<T> node)
        {
            if (node.child[0] != null) // if there is a left subtree
            {
                foreach (Node<T> LeftNode in Traversal(node.child[0])) // should enumerate the left tree, call by call.
                    yield return LeftNode;
            }

            yield return node; // return the starting node

            if (node.child[1] != null)
            {
                foreach (Node<T> RightNode in Traversal(node.child[1]))
                    yield return RightNode;
            }

        }

        /// <summary>
        /// Returns a reference to the node with the corresponding key
        /// </summary>
        /// <param name="current"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        protected Node<T> GetRef(Node<T> current, int key)
        {
            if (current == null)
            {
                throw new KeyNotFoundException();
            }
            else if (current.Key == key)
            {
                return current;
            }

            return GetRef(current.child[current.Key > key ? 0 : 1], key);
        }

        /// <summary>
        /// Returns a KeyValuePair<Node<T>, Node<T>> which consists of successor of a given node and its parent.
        /// </summary>
        /// <param name="start"></param>
        /// <param name="direction"></param>
        /// <returns></returns>
        protected KeyValuePair<Node<T>, Node<T>> GetSuccessor(Node<T> start, int direction) // we need a direction to find the successor
        {
            var current = start.child[direction == 1 ? 0 : 1];
            var parent = start;
            var grandParent = Root;

            while (current != null) // walk down the tree while till the end
            {
                grandParent = parent;
                parent = current;
                current = current.child[direction];
            }

            return new KeyValuePair<Node<T>, Node<T>>(parent, grandParent);
        }

    }



}