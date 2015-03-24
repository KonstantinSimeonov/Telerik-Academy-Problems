namespace LoverOf3
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    class Program
    {
        static int[] rowDir = { -1, 1, 1, -1 };
        static int[] colDir = { 1, 1, -1, -1 };
        static string[] input;
        static int move, repeat;

        static int GetMove(string str)
        {
            switch (str)
            {
                case "RU": return 0;
                case "UR": return 0;
                case "RD": return 1;
                case "DR": return 1;
                case "LD": return 2;
                case "DL": return 2;
                case "LU": return 3;
                case "UL": return 3;
                default: throw new ArgumentException();

            }
        }

        static void Main()
        {

            var mSize = Console.ReadLine().Split(' ');

            var R = int.Parse(mSize[0]);
            var C = int.Parse(mSize[1]);

            var field = new bool[R, C];

            int movesCount = int.Parse(Console.ReadLine());

            ulong soom = 0;

            int row = R - 1, col = 0;

            for (int i = 0; i < movesCount; i++)
            {
                input = Console.ReadLine().Split(' ');
                move = GetMove(input[0]);
                repeat = int.Parse(input[1]);

                for (int j = 0; j < repeat - 1; j++)
                {

                    row += rowDir[move];
                    col += colDir[move];

                    if (row < 0 || col < 0 || row >= R || col >= C)
                    {
                        row -= rowDir[move];
                        col -= colDir[move];
                        break;
                    }
                    else if (!field[row, col])
                    {
                        soom += (ulong)((R - 1 - row) * 3 + col * 3);
                        field[row, col] = true;
                    }

                }

            }
        }
    }
}