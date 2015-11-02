namespace LinearDataStructures
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public static class SequenceOperations
    {
        /// <summary>
        /// Write a program that reads from the console a sequence of positive integer numbers.
        /// The sequence ends when empty line is entered.
        /// Calculate and print the sum and average of the elements of the sequence.
        /// Keep the sequence in List<int>.
        /// </summary>
        public static void PrintSumAndAverage()
        {
            string input = Console.ReadLine();
            var container = new List<int>();
            double sum = 0;

            while (input != string.Empty)
            {
                container.Add(int.Parse(input));
                sum += container[container.Count - 1];
                input = Console.ReadLine();
            }

            Console.WriteLine("sum: {0}\naverage: {1}", sum, sum / (double)container.Count);
        }

        /// <summary>
        /// Write a program that reads N integers from the console and reverses them using a stack.
        /// Use the Stack<int> class.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sequence"></param>
        public static void ReverseSequence<T>(IEnumerable<T> sequence)
        {
            var stack = new Stack<T>();

            sequence.ForEach(item => stack.Push(item));

            while (stack.Count > 0)
            {
                stack.Pop().Print();
            }
        }

        /// <summary>
        /// Write a program that reads a sequence of integers (List<int>) 
        /// ending with an empty line and sorts them in an increasing order.
        /// </summary>
        /// <param name="integerSequence"></param>
        /// <returns></returns>
        public static ICollection<int> GetSortedNumbers(IEnumerable<int> integerSequence)
        {
            var container = new SortedSet<int>();

            int max = int.MinValue;

            string input = Console.ReadLine();

            while (input != string.Empty)
            {
                var parsedInput = input.ToInt32();
                container.Add(parsedInput);

                if (parsedInput > max)
                {
                    max = parsedInput;
                }

                input = Console.ReadLine();
            }

            return container;
        }

        /// <summary>
        /// Write a program that removes from given sequence all numbers that occur odd number of times.
        /// Example:
        /// {4, 2, 2, 5, 2, 3, 2, 3, 1, 5, 2} → {5, 3, 3, 5}
        /// </summary>
        /// <param name="sequence"></param>
        /// <returns></returns>
        public static IDictionary<int, int> RemoveAllThatOccurOddTimes(IList<int> sequence)
        {
            var groups = new Dictionary<int, int>();

            foreach (var number in sequence)
            {
                if (groups.ContainsKey(number))
                {
                    groups[number]++;
                }
                else
                {
                    groups.Add(number, 1);
                }
            }

            foreach (var pair in groups)
            {
                if ((pair.Value & 1) == 1)
                {
                    for (int i = 0; i < pair.Value; i++)
                    {
                        sequence.Remove(pair.Key);
                    }
                }

            }

            return groups;
        }

        /// <summary>
        /// Write a method that finds the longest subsequence of equal numbers in given List and returns the result as new List<int>.
        /// Write a program to test whether the method works correctly.
        /// </summary>
        /// <param name="sequence"></param>
        /// <returns></returns>
        public static List<int> FindLongestEqualNumbersSubsequence(IList<int> sequence)
        {
            var longestSubsequence = new List<int>();

            var distinct = new Dictionary<int, int>();

            foreach (var item in sequence)
            {
                if (distinct.ContainsKey(item))
                {
                    distinct[item]++;
                }
                else
                {
                    distinct.Add(item, 1);
                }
            }

            var longest = new KeyValuePair<int, int>(0, 0);

            foreach (var item in distinct)
            {
                if (item.Value > longest.Value)
                {
                    longest = item;
                }
            }

            var result = new List<int>(longest.Value);

            for (int i = 0; i < result.Capacity; i++)
            {
                result.Add(longest.Key);
            }

            return result;
        }

        /// <summary>
        /// Write a program that removes from given sequence all negative numbers.
        /// </summary>
        /// <param name="numbers"></param>
        public static void RemoveNegativeNumbersFromCollection(IList<double> numbers)
        {
            for (int i = 0; i < numbers.Count; i++)
            {
                if (numbers[i] < 0)
                {
                    numbers.RemoveAt(i);
                    i--;
                }
            }
        }

        /// <summary>
        /// Write a program that finds in given array of integers (all belonging to the range [0..1000]) how many times each of them occurs.

        ///         Example: array = {3, 4, 4, 2, 3, 3, 4, 3, 2}
        /// 2 → 2 times
        /// 3 → 4 times
        /// 4 → 3 times
        /// </summary>
        /// <param name="numbers"></param>
        /// <returns></returns>
        public static int[] GetOccurenceCount(ICollection<int> numbers)
        {
            var result = new int[1001];

            foreach (var n in numbers)
            {
                result[n]++;
            }

            return result;
        }

        /// <summary>
        /// We are given numbers N and M and the following operations:
        /// N = N+1
        /// N = N+2
        /// N = N*2
        /// 
        /// Write a program that finds the shortest sequence of operations from the list above that starts from N and finishes in M.
        /// 
        /// Hint: use a queue.
        /// Example: N = 5, M = 16
        /// Sequence: 5 → 7 → 8 → 16
        /// </summary>
        /// <param name="sequence"></param>
        /// <returns></returns>
        public static void GetShortestSequence()
        {
            "Start number".Print();
            var start = Console.ReadLine().ToInt32();
            "End number".Print();
            var end = Console.ReadLine().ToInt32();

            var shortestWayAsQueue = new Queue<int>();

            while (start <= end)
            {
                shortestWayAsQueue.Enqueue(end);

                if (start <= (end >> 1))
                {
                    if ((end & 1) == 0)
                    {
                        end >>= 1;
                    }
                    else
                    {
                        end--;
                    }
                }
                else
                {
                    if (start <= end - 2)
                    {
                        end -= 2;
                    }
                    else
                    {
                        end--;
                    }
                }
            }

            shortestWayAsQueue.Reverse().StringJoin(" -> ").Print();
        }

        /// <summary>
        /// *The majorant of an array of size N is a value that occurs in it at least N/2 + 1 times.
        /// Write a program to find the majorant of given array(if exists).
        /// Example:
        /// {2, 2, 3, 3, 2, 3, 4, 3, 3} → 3
        /// </summary>
        /// <param name="numbers"></param>
        /// <returns></returns>
        public static int? FindMajorant(int[] numbers)
        {
            var occurences = new Dictionary<int, int>();
            var stack = new Stack<int>();

            foreach (var item in numbers)
            {
                if (stack.Count == 0 || stack.Peek() == item)
                {
                    stack.Push(item);

                    if (!occurences.ContainsKey(item))
                    {
                        occurences.Add(item, 1);
                        
                    }

                    occurences[item]++;
                }
                else
                {
                    stack.Pop();
                }
            }

            if (stack.Count > 0)
            {
                if (occurences[stack.Peek()] > (numbers.Length / 2))
                {
                    return stack.Peek();
                }
            }

            return null;
        }


        /// <summary>
        /// We are given the following sequence:
        /// S1 = N;
        /// S2 = S1 + 1;
        /// S3 = 2*S1 + 1;
        /// S4 = S1 + 2;
        /// S5 = S2 + 1;
        /// S6 = 2*S2 + 1;
        /// S7 = S2 + 2;
        /// ...
        /// Using the Queue<T> class write a program to print its first 50 members for given N.
        /// Example: N= 2 → 2, 3, 5, 4, 4, 7, 5, 6, 11, 7, 5, 9, 6, ...
        /// </summary>
        public static void PrintSequence()
        {
            "N:".Print();

            int n = Console.ReadLine().ToInt32();

            var queue = new Queue<int>();

            int current = n;

            (n + ", ").Print();

            var actions = new Action[]
            {
                 () =>
                 {
                     queue.Enqueue(current + 2);
                     current = queue.Dequeue();
                     (current + ", ").Print();
                 },
                 () => queue.Enqueue(current + 1),
                 () => queue.Enqueue(2 * current + 1)

            };

            for (int i = 1; i < 51; i++)
            {
                // long if/else constructions are simply disgusting, sorry :D
                actions[i % 3]();
            }

            queue.StringJoin(", ").Print();
        }
    }
}