using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

public class GameOfLife
{
    static GameOfLife()
    {
        watch.Start();
        gameBoard = new int[2048, 128, 128];
        watch.Stop();
        Console.WriteLine(watch.Elapsed);
        watch.Reset();
    }

    public static int[,] directions = {
                                      {-1, -1},
                                      {-1, 1},
                                      {1, -1},
                                      {1 , 1},
                                      {0, 1},
                                      {0, -1},
                                      {-1, 0},
                                      {1, 0}
                                      };
    public static int[, ,] gameBoard;
    public static int GetNeighborCount(int row, int col, int level, int l1, int l2)
    {
        int neighbors = 0;

        for (int i = 0; i < GameOfLife.directions.GetLength(0); i++)
        {
            if( (row + GameOfLife.directions[i, 0] >= 0) && (row + GameOfLife.directions[i, 0] < l1) && (col + GameOfLife.directions[i, 1] >= 0) && (col + GameOfLife.directions[i, 1] < l2))
            {
                if(gameBoard[level, row + GameOfLife.directions[i, 0], col + GameOfLife.directions[i, 1]] == 1)
                {
                    neighbors++;
                }
            }
        }

        return neighbors;
    }
    static Stopwatch watch = new Stopwatch();

    public static void Main()
    {
        
        
        int n = int.Parse(Console.ReadLine());
        var rc = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
        //gameBoard = new int[n + 1, rc[0], rc[1]];
        for (int i = 0; i < rc[0]; i++)
        {
            var currentRow = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            for (int j = 0; j < rc[1]; j++)
            {
                gameBoard[0, i, j] = currentRow[j];
            }
        }
        watch.Start();
        
        for (int i = 0; i < n; i++)
        {
            for (int k = 0; k < rc[0]; k++)
            {
                for (int j = 0; j < rc[1]; j++)
                {
                    var neighbors = GetNeighborCount(k, j, i, rc[0], rc[1]);
                    if (gameBoard[i, k, j] == 0)
                    {
                        if(neighbors == 3)
                        {
                            gameBoard[i + 1, k, j] = 1;
                        }
                    } 
                    else
                    {
                        if(neighbors == 2 || neighbors == 3)
                        {
                            gameBoard[i + 1, k, j] = 1;
                        }
                    }

                }
            }
        }
        int result = 0;
        for (int i = 0; i < rc[0]; i++)
        {
            for (int j = 0; j < rc[1]; j++)
            {
                result += gameBoard[n, i, j];
            }
        }
        Console.WriteLine(result);
        watch.Stop();
        Console.WriteLine(watch.Elapsed);
    }
}