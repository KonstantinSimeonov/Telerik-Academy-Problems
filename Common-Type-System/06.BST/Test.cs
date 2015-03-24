using System;
using BinarySearchTree;

class Test
{
    static void Main()
    {
        var testTree = new BinarySearchTree<int>(); // constructor test

        // addition test

        testTree.Insert(10, 10);
        testTree.Insert(5, 5);
        testTree.Insert(2, 2);
        testTree.Insert(7, 7);
        testTree.Insert(6, 6);
        testTree.Insert(8, 8);
        testTree.Insert(3, 3);
        testTree.Insert(15, 15);

        // clone test
        var clone = (BinarySearchTree<int>)testTree.Clone();

        Console.WriteLine(testTree+"\n\n"); // print testTree
        Console.WriteLine(clone);

        Console.WriteLine(testTree.Equals(clone));

        // deletion test
        testTree.DeleteItemWithKey(10);
        testTree.DeleteItemWithKey(3);
        testTree.DeleteItemWithKey(5);
        testTree.DeleteItemWithKey(15);

        Console.WriteLine(testTree.Equals(clone));
        // print testTree after
        Console.WriteLine(testTree);

        foreach (var item in testTree)
        {
            Console.WriteLine(item + 10 +" I am an enumerator test!");
        }

        
    }
}