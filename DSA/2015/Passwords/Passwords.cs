namespace Passwords
{
    using System;
    using System.Linq;

    public class Solution
    {
        private static char[] info;
        private static int[] numbers;
        private static int k;

        public static void Main()
        {
            var n = int.Parse(Console.ReadLine());

            info = Console.ReadLine().ToCharArray();

            k = int.Parse(Console.ReadLine());

            numbers = Enumerable.Range(1, 10).ToArray();
            numbers[9] = 0;

            PushPermutations(n, new int[n], 0);
        }

        private static void PushPermutations(int n, int[] p, int start)
        {
            // TODO: refactor this mess
            if (n == start)
            {
                if (--k == 0)
                {
                    Console.WriteLine(string.Join("", p));
                    Environment.Exit(0);
                }

                return;
            }

            if (start > 0)
            {
                if (info[start - 1] == '=')
                {
                    p[start] = p[start - 1];
                    PushPermutations(n, p, start + 1);

                }
                else if (info[start - 1] == '>')
                {
                    var s = p[start - 1];

                    if (s == 0)
                    {
                        return;
                    }

                    p[start] = 0;
                    PushPermutations(n, p, start + 1);

                    for (int j = s == 0 ? n : s; j < 9; j++)
                    {
                        p[start] = numbers[j];
                        PushPermutations(n, p, start + 1);
                    }
                }
                else if (info[start - 1] == '<')
                {
                    var s = p[start - 1];
                    s = s == 0 ? 10 : s;

                    for (int j = 0; j < s - 1; j++)
                    {
                        p[start] = numbers[j];
                        PushPermutations(n, p, start + 1);
                    }
                }

            }
            else
            {
                p[start] = 0;
                PushPermutations(n, p, start + 1);

                for (int i = start; i < 9; i++)
                {
                    p[start] = numbers[i];
                    PushPermutations(n, p, start + 1);
                }
            }

        }
    }
}