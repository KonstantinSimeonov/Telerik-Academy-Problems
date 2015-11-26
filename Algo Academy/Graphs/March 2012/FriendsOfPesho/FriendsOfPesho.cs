namespace GraphAlgorithms
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class PeshoToTheHospital
    {
        public static void Solve()
        {
            var nmh = Console.ReadLine()
                                    .Split(' ')
                                    .Select(int.Parse)
                                    .ToArray();

            var hospitals = Console.ReadLine()
                                    .Split(' ')
                                    .Select(x => int.Parse(x) - 1)
                                    .ToArray();

            var graph = Enumerable
                                .Range(0, nmh[0])
                                .Select(i => new List<Edge>())
                                .ToArray();

            for (int i = 0; i < nmh[1]; i++)
            {
                var input = Console.ReadLine().Split(' ').Select(x => int.Parse(x) - 1).ToArray();

                graph[input[0]].Add(new Edge(input[1], input[2] + 1));
                graph[input[1]].Add(new Edge(input[0], input[2] + 1));
            }

            var result = hospitals.Select(h => GetSum(h, hospitals, graph)).Min();

            Console.WriteLine(result);
        }

        private static int GetSum(int hospital, int[] hospitals, List<Edge>[] graph)
        {
            var distances = Enumerable
                                .Range(0, graph.Length)
                                .Select(x => int.MaxValue)
                                .ToArray();

            distances[hospital] = 0;

            var nodes = new Queue<int>();
            nodes.Enqueue(hospital);

            while (nodes.Count > 0)
            {
                var current = nodes.Dequeue();

                foreach (var edge in graph[current])
                {
                    var currentDistance = distances[current] + edge.Length;

                    if(distances[edge.To] > currentDistance)
                    {
                        distances[edge.To] = currentDistance;
                        nodes.Enqueue(edge.To);
                    }
                }
            }

            foreach (var h in hospitals)
            {
                distances[h] = 0;
            }

            return distances.Sum();
        }
    }

    internal class Edge
    {
        public int Length { get; private set; }

        public int To { get; private set; }

        public Edge(int t, int l)
        {
            this.Length = l;
            this.To = t;
        }
    }
}