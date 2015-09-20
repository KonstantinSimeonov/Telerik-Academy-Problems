namespace Iterator
{
    using System;

    using Iterator.GenericTree;

    public class Program
    {
        static void Main()
        {
            var tree = new Tree<string>("grandparent");

            tree.AddChild(new Tree<string>("parent")
                                    .AddChild("child1")
                                    .AddChild("child2")
                                    .AddChild(new Tree<string>("child3")
                                                    .AddChild("grandchild of 3(1)")
                                                    .AddChild("grandchild of 3(2)")))
                                .AddChild("kuzman");

            var iterator = new Treeterator<string>(tree);

            while(!iterator.Finished)
            {
                Console.WriteLine(iterator.Next);
            }

            // or
            Console.WriteLine("\n\n");

            foreach (var item in tree)
            {
                Console.WriteLine(item);
            }
        }
    }
}