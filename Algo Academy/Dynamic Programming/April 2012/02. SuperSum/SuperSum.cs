using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperSum
{
    class solution
    {
        static void Main(string[] args)
        {
            var kn = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int n = kn[1];
            int k = kn[0];

            var answer = new int[k + 1, n];

            for (int i = 0; i < k + 1; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if(i == 0)
                    {
                        answer[i, j] = j + 1;
                    }
                    else
                    {
                        for (int g = i - 1, p = 0 ; p <= j; p++)
                        {
                            answer[i, j] += answer[g, p];
                        }
                    }
                }
            }
			
			// print the matrix			
			
            //for (int i = 0; i < k + 1; i++)
            //{
            //    for (int j = 0; j < n; j++)
            //    {
            //        Console.Write("{0, -4}", answer[i,j]);
            //    }

            //    Console.WriteLine();
            //}

            Console.WriteLine(answer[k, n-1]);
        }
    }
}