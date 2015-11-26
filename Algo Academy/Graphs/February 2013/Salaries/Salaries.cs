namespace GraphAlgorithms
{
    using System;

    public class Gopo
    {
        private static ulong[] memory;

        public static void Solve()
        {
            var n = int.Parse(Console.ReadLine());

            var graph = new string[n];
            memory = new ulong[n];

            for (int i = 0; i < n; i++)
            {
                graph[i] = Console.ReadLine();
            }

            ulong salaries = 0;

            for (int i = 0; i < n; i++)
            {
                salaries += GetSalaryForEmployee(graph, i);
            }

            Console.WriteLine(salaries);
        }

        public static ulong GetSalaryForEmployee(string[] graph, int row)
        {
            if(memory[row] != 0)
            {
                return memory[row];
            }

            ulong salary = 0;
            bool hasSubordinates = false;

            for (int j = 0; j < graph[row].Length; j++)
            {
                if (graph[row][j] == 'Y')
                {
                    salary += GetSalaryForEmployee(graph, j);
                    hasSubordinates = true;
                }
            }

            salary = hasSubordinates ? salary : 1;

            memory[row] = salary;
            return salary;
        }
    }
}