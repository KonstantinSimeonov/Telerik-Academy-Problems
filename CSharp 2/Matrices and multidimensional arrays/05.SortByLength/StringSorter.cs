using System;

//Problem 5. Sort by string length

//You are given an array of strings. Write a method that sorts the array by the length
//of its elements (the number of characters composing them).

    class StringSorter
    {
        static void Main()
        {
            // input size
            Console.WriteLine("Size:");
            int size = int.Parse(Console.ReadLine());
            // allocate
            string[] strings = new string[size];
            // initialize
            for (int i = 0; i < size; i++)
            {
                strings[i] = Console.ReadLine();
            }
            Console.WriteLine();
            // selectionsort
            for (int i = 0; i < size; i++)
            {
                int index = i;
                for (int j = 1+i; j < size; j++)
                {
                    if (strings[index].Length > strings[j].Length)
                    {
                        index = j;
                    }
                }
                string store = strings[i];
                strings[i] = strings[index];
                strings[index] = store;
            }

            // print
            foreach (string word in strings)
            {
                Console.WriteLine(word);
            }
        }
    }

