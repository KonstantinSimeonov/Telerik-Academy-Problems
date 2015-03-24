using System;

class Program
{
    static void Main()
    {
        string[,] dancefloor = {
                                {"RED", "BLUE", "RED"},
                                {"BLUE", "GREEN", "BLUE"},
                                {"RED", "BLUE", "RED"}
                              };

        int dir = 1, row = 1, col = 1;
        int[] rowDir = { -1, 0, 1, 0 };
        int[] colDir = { 0, 1, 0, -1 };

        int n = int.Parse(Console.ReadLine());

        for (int i = 0; i < n; i++)
        {
            row = col = 1;
            string commands = Console.ReadLine();

            foreach (char letter in commands)
            {
                if (letter != 'W')
                {
                    if (letter == 'R')
                    {
                        dir++;

                        dir = dir > 3 ? 0 : dir;
                    }
                    else
                    {
                        dir--;
                        dir = dir < 0 ? 3 : dir;
                    }
                }
                else
                {
                    row += rowDir[dir];
                    col += colDir[dir];

                    if (row > 2)
                    {
                        row = 0;
                    }
                    else if (row < 0)
                    {
                        row = 2;
                    }

                    if (col > 2)
                    {
                        col = 0;
                    }
                    else if (col < 0)
                    {
                        col = 2;
                    }
                }

            }

            Console.WriteLine(dancefloor[row, col]);
        }
    }
}