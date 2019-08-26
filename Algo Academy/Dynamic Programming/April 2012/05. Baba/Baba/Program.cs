using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baba
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            var line = Console.ReadLine().Split(' ');
            var values = new List<int>();
            var weights = new List<int>();

            while (line[0] != "END")
            {
                values.Add(int.Parse(line[1]));
                weights.Add(int.Parse(line[2]));
                line = Console.ReadLine().Split(' ');
            }

            var answer = new int[weights.Count + 1, n];

            for (int i = 1; i < weights.Count + 1; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (j >= weights[i - 1])
                    {
                        answer[i, j] = Math.Max(answer[i - 1, j], answer[i - 1, j - weights[i - 1]] + values[i - 1]);
                    }
                    else
                    {
                        answer[i, j] = answer[i - 1, j];
                    }
                }
            }
            //for (int i = 0; i < weights.Count + 1; i++)
            //{
            //    for (int j = 0; j < n; j++)
            //    {
            //        Console.Write("{0, 4}", answer[i, j]);
            //    }
            //    Console.WriteLine();
            //}
            Console.WriteLine(answer[weights.Count, n - 1]);

        }
    }
}
