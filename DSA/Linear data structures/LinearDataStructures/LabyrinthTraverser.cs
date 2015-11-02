namespace LinearDataStructures
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// We are given a labyrinth of size N x N.
    /// Some of its cells are empty(0) and some are full(x).
    /// We can move from an empty cell to another empty cell if they share common wall.
    /// Given a starting position (*) calculate and fill in the array the minimal distance from this position to any other cell in the array. Use "u" for all unreachable cells.
    /// </summary>
    public static class LabyrinthTraverser
    {
        public static IDictionary<char, int> charInfo = new Dictionary<char, int>()
        {
            {'0', 0 },
            {'x', -1 },
            {'*', 1 }
        };

        public static string[] labyrinth = new string[]
        {
             "000x0x",
             "0x0x0x",
             "0*x0x0",
             "0x0000",
             "000xx0",
             "000x0x"
        };

        public static int[][] directions = new int[][]
        {
            new int[] { 1, 0 },
            new int[] { 0, 1 },
            new int[] { -1, 0 },
            new int[] { 0, -1 }
        };

        public static void TraverseLabyrinth()
        {
            var parsedLabyrinth = new int[labyrinth.Length, labyrinth[0].Length];

            for (int i = 0; i < labyrinth.Length; i++)
            {
                for (int j = 0; j < labyrinth[0].Length; j++)
                {
                    parsedLabyrinth[i, j] = charInfo[labyrinth[i][j]];
                }
            }

            var q = new Queue<int[]>();
            // the first element holds the row, the next holds the column and the last holds the current number of steps
            var startingPointInfo = new int[] { 2, 1, 1 };
            q.Enqueue(startingPointInfo);

            // do a bfs
            while (q.Count > 0)
            {
                var current = q.Dequeue();

                parsedLabyrinth[current[0], current[1]] = current[2];

                foreach (var d in directions)
                {
                    bool nextPointIsInside = parsedLabyrinth.IsInside(d[0] + current[0], d[1] + current[1]);

                    // if the next point is empty
                    if (nextPointIsInside && parsedLabyrinth[current[0] + d[0], current[1] + d[1]] == 0)
                    {
                        var nextPointInfo = new int[] { d[0] + current[0], d[1] + current[1], current[2] + 1 };
                        q.Enqueue(nextPointInfo);
                    }
                }
            }

            // print
            PrintMatrix(parsedLabyrinth);
        }

        public static void PrintMatrix(this int[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write("{0, 4}", matrix[i, j] >= 1 ? matrix[i, j].ToString() : (matrix[i, j] == -1 ? "x" : "u"));
                }

                Console.WriteLine();
            }
        }
    }
}
