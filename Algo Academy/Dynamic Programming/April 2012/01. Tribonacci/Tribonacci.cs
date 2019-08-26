using System;
using System.Linq;
using System.Collections.Generic;
    public class Solution
    {
        static void Main()
        {
            var param = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int n = param[3];
            var answer = new List<int>(n + 1);
            answer.Add(param[0]);
            answer.Add(param[1]);
            answer.Add(param[2]);

            for (int i = 3; i < n; i++)
            {
                answer.Add(answer[i - 1] + answer[i - 2] + answer[i - 3]);
            }

            Console.WriteLine(answer[n - 1]);
        }
    }