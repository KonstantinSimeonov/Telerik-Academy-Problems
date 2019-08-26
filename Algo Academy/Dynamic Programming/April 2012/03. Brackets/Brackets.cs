using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brackets
{
    class solution
    {
        static void Main(string[] args)
        {
            string expr = Console.ReadLine();

            var answer = new long[expr.Length + 1, expr.Length + 2];
            answer[0, 1] = 1;

            for (int i = 1; i < expr.Length + 1; i++)
            {
                for (int j = 1; j < expr.Length + 1; j++)
                {
                    if(expr[i - 1] == '?')
                    {
                        answer[i, j] = answer[i - 1, j - 1] + answer[i - 1, j + 1];
                    }
                    else if(expr[i - 1] == '(')
                    {
                        answer[i, j] = answer[i - 1, j - 1];
                    }
                    else
                    {
                        answer[i, j] = answer[i - 1, j + 1];
                    }

                }
            }

            Console.WriteLine(answer[expr.Length, 1]);
        }
    }
}