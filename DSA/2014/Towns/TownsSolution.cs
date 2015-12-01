namespace Towns
{
    using System;
    using System.Linq;

    public class TownsSolution
    {
        private static void Main()
        {
            var n = int.Parse(Console.ReadLine());

            var input = Enumerable.Range(0, n)
                                  .Select(i => int.Parse(Console.ReadLine().Split(' ')[0]))
                                  .ToArray();

            var ascending = new int[n];
            
            // find longest ascending sequence ending with each town
            for (int i = 0; i < n; i++)
            {
                for (int j = i; j >= 0; j--)
                {
                    if (input[i] > input[j])
                    {
                        if (ascending[j] + 1 > ascending[i])
                        {
                            ascending[i] = ascending[j] + 1;
                        }
                    }
                }

                if(ascending[i] == 0)
                {
                    ascending[i] = 1;
                }
            }

            var descending = new int[n];
            
            // find longest descending sequence starting with each town
            for (int i = n - 1; i >= 0; i--)
            {
                for (int j = i; j < n; j++)
                {
                    if (input[i] > input[j])
                    {
                        if (ascending[j] + 1 > ascending[i])
                        {
                            ascending[i] = ascending[j] + 1;
                        }
                    }
                }

                if (ascending[i] == 0)
                {
                    ascending[i] = 1;
                }
            }

            var answer = 0;
            
            // combine the paths
            for (int i = 0; i < n; i++)
            {
                if (ascending[i] + descending[i] > answer)
                {
                    answer = ascending[i] + descending[i];
                }
            }

            Console.WriteLine(answer - 1);
        }
    }
}