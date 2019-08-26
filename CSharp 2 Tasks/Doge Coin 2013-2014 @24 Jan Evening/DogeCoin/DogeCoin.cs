namespace DogeCoin
{
    using System;
    class DogeCoin
    {
        static void Main()
        {
            string[] input = Console.ReadLine().Split(' ');
            int n = int.Parse(input[0]);
            int m = int.Parse(input[1]);
            int[,] dogeMat = new int[n, m];
            int k = int.Parse(Console.ReadLine());

            for (int i = 0; i < k; i++)
            {
                string[] coords = Console.ReadLine().Split(' ');
                dogeMat[int.Parse(coords[0]), int.Parse(coords[1])]++;
            }

            var track = new int[n, m];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    int coinsUp = 0, coinsLeft = 0;

                    if (i > 0)
                    {
                        coinsUp = track[i - 1, j];
                    }

                    if (j > 0)
                    {
                        coinsLeft = track[i, j - 1];
                    }

                    track[i, j] = (coinsUp > coinsLeft ? coinsUp : coinsLeft) + dogeMat[i, j];
                }
            }

            Console.WriteLine(track[n - 1, m - 1]);

        }
    }
}