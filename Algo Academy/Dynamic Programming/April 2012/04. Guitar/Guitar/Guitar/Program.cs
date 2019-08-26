using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guitar
{
    class Program
    {
        static bool isInside(int col, int len)
        {
            return col >= 0 && col < len;
        }

        static void Main(string[] args)
        {
            int songs = int.Parse(Console.ReadLine());
            var tunes = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int start = int.Parse(Console.ReadLine());
            int roof = int.Parse(Console.ReadLine());

            var answer = new bool[songs + 1, roof + 1];

            answer[0, start] = true;
            int length = answer.GetLength(1);

            for (int i = 0; i < songs; i++)
            {
                for (int j = 0; j < roof + 1; j++)
                {
                    if(answer[i,j] == true)
                    {
                        if(isInside(j + tunes[i], length))
                        {
                            answer[i + 1, j + tunes[i]] = true;
                        }

                        if(isInside(j - tunes[i], length))
                        {
                            answer[i + 1, j - tunes[i]] = true;
                        }
                    }
                }
            }

            for (int i = songs, j = length - 1; j >= 0; j--)
            {
                if(answer[i, j])
                {
                    Console.WriteLine(j);
                    return;
                }
            }

            Console.WriteLine(-1);
        }
    }
}
