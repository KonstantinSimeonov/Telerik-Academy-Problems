using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication5
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] first = { 14, -3, 5, 8, 0, 16, 0, 1 , -3, 8};
            int[] second = { 14, 2, 5, -3, 8, 15 };

            var result = new int[first.Length + 1, second.Length + 1];

            for (int i = 1; i < result.GetLength(0); i++)
            {
                bool yes = true;
                for (int j = 1; j < result.GetLength(1); j++)
                {

                    result[i, j] = Math.Max(result[i - 1, j], result[i, j - 1]);

                    if (second[j - 1] == first[i - 1] && yes)
                    {
                        result[i, j]++;
                        yes = false;
                    }
                        
                }
            }

            Console.WriteLine(result[first.Length, second.Length]);

            for (int i = 0; i < result.GetLength(0); i++)
            {
                for (int j =0; j < result.GetLength(1); j++)
                {

                    Console.Write("{0,4}", result[i,j]);

                }
                Console.WriteLine();
            }
        }
    }
}
