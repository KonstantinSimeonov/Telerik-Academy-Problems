using System;
using System.Linq;
using System.Collections.Generic;


/// <summary>
/// Generic container that supports a numer of operations on a sequence of a given type.
/// </summary>
/// <typeparam name="T"></typeparam>
[Version("2.11")]
class GenericList<T> : IEnumerable<T>
{
    // FIELDS

    private const int defaultCapacity = 100;
    private int capacity;
    private T[] elements;
    

    // PROPERTIES

    public int Count { get; private set; }

    // INDEXERS

    public T this[int index]
    {
        get
        {
            return elements[index];
        }
        set
        {
            elements[index] = value;
        }
    }

    // CONSTRUCTORS

    /// <summary>
    /// Initializes an instance of the GenericList class.
    /// </summary>
    /// <param name="capacity"></param>
    public GenericList(int capacity = defaultCapacity)
    {
        this.capacity = capacity;
        elements = new T[this.capacity];
        Count = 0;
    }

    // METHODS

    /// <summary>
    /// If the elements are comparable, return the minimum element in the GenericList.
    /// </summary>
    /// <returns></returns>
    public T Min()
    {
        // check if the elements are comparable
        if (elements[0] is IComparable)
        {
            if (Count > 1) // if more than one element, search
            {
                var max = elements.Min();

                return max;
            }
            else
            {
                return elements[0]; // if one elements, return that element
            }

        }
        else
        {
            throw new ArgumentException("Objects not comparable!");
        }
    }

    /// <summary>
    /// If the elements are comparable, return the maximal element in the GenericList.
    /// </summary>
    /// <returns></returns>
    public T Max()
    {
        if (elements[0] is IComparable)
        {
            var max = elements.Max();

            return max;

        }
        else
        {
            throw new ArgumentException("Objects not comparable!");
        }
    }

    /// <summary>
    /// Adds an item to the list.
    /// </summary>
    /// <param name="item"></param>
    public void Add(T item)
    {
        if (Count >= capacity) // auto-grow
            Extend();

        elements[Count++] = item; // add
    }

    /// <summary>
    /// Inserts an elements at the given position.
    /// </summary>
    /// <param name="position"></param>
    /// <param name="item"></param>
    public void Insert(int position, T item)
    {
        if (position < 0 || position > Count) // check for correct boundaries
        {
            throw new ArgumentOutOfRangeException("The position specified position was out of the list boundaries!");
        }
        else
        {
            if (Count >= capacity) // auto-grow
                Extend();

            // perform insertion

            var store = elements[position]; // store
            elements[position] = item; // add the new element

            // shift the elements after the new elements to the right
            for (int i = position + 2; i < capacity; i++)
            {
                elements[i] = elements[i - 1];
            }

            // put the element we stored back
            elements[position + 1] = store;

            Count++;
        }

    }

    /// <summary>
    /// Removes an element at the given position
    /// </summary>
    /// <param name="position"></param>
    public void RemoveAt(int position, bool keepOrder = true)
    {
        if (position < 0 || position >= Count) // check boundaries
        {
            throw new ArgumentOutOfRangeException("Specified position was out of the list boundaries!");
        }
        else
        {
            if (keepOrder) // when we remove an element at a given position, to keep the order, we need to shift all items
            {              // after it to the left, which is often slow. The user can choose to keep the order or not.

                // keep order, shift left
                for (int i = position; i < Count - 1; i++)
                {
                    elements[i] = elements[i + 1];
                }

                elements[Count - 1] = default(T);
                Count--;

            }
            else
            {
                // just put the last elements in the sequence in its place, which is a lot faster
                elements[position] = elements[Count - 1];
                elements[--Count] = default(T);
            }

        }

        // auto-shrink
        if (Count <= capacity / 2)
            Shrink();
    }

    /// <summary>
    /// Performs auto-shrink operation on the array underlying the GenericList class.
    /// </summary>
    private void Shrink()
    {
        Console.WriteLine("Shrinking."); // just to see that something is happening

        var newArr = new T[capacity / 2]; // allocate smaller array

        for (int i = 0; i < Count; i++)
        {
            newArr[i] = elements[i]; // fill it
        }

        // set it up as the new storage
        elements = newArr;
        capacity /= 2; // update capacity
    }

    /// <summary>
    /// Performs auto-grow operation on the array underlying the GenericList class.
    /// </summary>
    private void Extend()
    {
        Console.WriteLine("Extending."); // see that something is happening

        var newArr = new T[capacity * 2]; // allocate

        for (int i = 0; i < capacity; i++)
        {
            newArr[i] = elements[i]; // fill
        }

        elements = newArr; // set up as new storage
        capacity *= 2; // update
    }

    public override string ToString()
    {
        return "This is an instance of GenericList with concrete data type of " + typeof(T);
    }

    public IEnumerator<T> GetEnumerator()
    {
        for (int i = 0; i < Count; i++)
        {
            yield return elements[i];
        }
    }

    System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}

