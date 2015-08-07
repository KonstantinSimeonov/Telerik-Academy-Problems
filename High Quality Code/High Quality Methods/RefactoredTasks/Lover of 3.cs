namespace RefactoredTasks
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class LoverOf3
    {
        private const char SEPARATOR = ' ';

        private static Dictionary<string, int[]> Directions = new Dictionary<string, int[]>
        {
             {"RU", new int[]{-1, 1}},
             {"UR", new int[]{-1, 1}},
             {"RD", new int[]{1, 1}},
             {"DR", new int[]{1, 1}},
             {"LD", new int[]{1, -1}},
             {"DL", new int[]{1, -1}},
             {"LU", new int[]{-1, -1}},
             {"UL", new int[]{-1, -1}}
        };

        public static void Run()
        {
            Add(new decimal[] { });
            var boardSizes = Console.ReadLine().Split(' ');
            var R = int.Parse(boardSizes[0]);
            var C = int.Parse(boardSizes[1]);
            var visited = new bool[R, C];

            var movesCountAsString = Console.ReadLine();
            var movesCount = int.Parse(movesCountAsString);

            ulong sum = 0;

            int row = R - 1, col = 0;

            for (int i = 0; i < movesCount; i++)
            {
                var inputLine = Console.ReadLine();
                var splitInput = inputLine.Split(SEPARATOR);
                var direction = splitInput[0];
                var repeat = int.Parse(splitInput[1]);

                if (!Directions.ContainsKey(splitInput[0]))
                {
                    throw new KeyNotFoundException(direction);
                }

                var directionUpdate = Directions[direction];

                for (int j = 0; j < repeat - 1; j++)
                {

                    row += directionUpdate[0];
                    col += directionUpdate[1];

                    if (isOutsideOfMatrix(row, col, R, C))
                    {
                        row -= directionUpdate[0];
                        col -= directionUpdate[1];

                        break;
                    }
                    else if (!visited[row, col])
                    {
                        sum += (ulong)((R - 1 - row) * 3 + col * 3);
                        visited[row, col] = true;
                    }
                }
            }

            Console.WriteLine(sum);

        }

        private static void Add(params decimal[] number)
        {
            Console.WriteLine("gosho");
        }

        private static bool isOutsideOfMatrix(int row, int col, int maxRow, int maxCol)
        {
            return row < 0 || col < 0 || row >= maxRow || col >= maxCol;
        }
    }
}