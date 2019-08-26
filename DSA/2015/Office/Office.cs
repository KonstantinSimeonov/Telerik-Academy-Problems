namespace Office
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Solution
    {
        public const int MaxTasksCount = 50;

        private static int[] memory;
        private static bool[] beenThereDoneThat = new bool[MaxTasksCount];

        public static void Main()
        {
            var n = int.Parse(Console.ReadLine());
            memory = new int[n];
            var executionTimes = Console.ReadLine()
                                            .Split(' ')
                                            .Select(int.Parse)
                                            .ToArray();

            var tasks = new KeyValuePair<int, List<int>>[n];

            for (int i = 0; i < n; i++)
            {
                var dependencies = Console.ReadLine()
                                                .Split(' ')
                                                .Select(x => int.Parse(x) - 1)
                                                .ToList();

                tasks[i] = new KeyValuePair<int, List<int>>(executionTimes[i], dependencies);
            }

            for (int i = 0; i < n; i++)
            {
                if (memory[i] == 0)
                {
                    memory[i] = CalculateExecutionTime(tasks, i);
                }
            }

            Console.WriteLine(memory.Max());
        }

        private static int CalculateExecutionTime(KeyValuePair<int, List<int>>[] tasks, int taskId)
        {
            if (memory[taskId] != 0)
            {
                return memory[taskId];
            }

            var executionTime = tasks[taskId].Key;
            var max = int.MinValue;

            for (int i = 0; i < tasks[taskId].Value.Count; i++)
            {
                var nextId = tasks[taskId].Value[i];
                if (nextId != -1)
                {
                    if (beenThereDoneThat[nextId])
                    {
                        Console.WriteLine(-1);
                        Environment.Exit(0);
                    }

                    beenThereDoneThat[nextId] = true;
                    var next = CalculateExecutionTime(tasks, nextId);

                    if (next > max)
                    {
                        max = next;
                    }
                    beenThereDoneThat[nextId] = false;
                }

            }

            memory[taskId] = (max > 0 ? max : 0) + executionTime;

            return memory[taskId];
        }
    }
}