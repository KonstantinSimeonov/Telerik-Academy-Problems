using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



class MatrixTest
{
    static void Main(string[] args)
    {
        // use a matrix calculator to check!

        Matrix football = new Matrix(new int[,] { { 6, 3, 0 }, { 2, 5, 1 }, { 9, 8, 6 } });
        Matrix gosho = new Matrix(new int[,] { { 7, 4 }, { 6, 7 }, { 5, 0 } });
        Matrix pesho = football * gosho;
        Console.WriteLine(pesho.ToString());

        Matrix tosho = new Matrix(new int[,] { { 4, 8 }, { 0, 2 }, { 1, 6 } });
        Matrix sasho = new Matrix(new int[,] { { 5, 2 }, { 9, 4 } });
        Console.WriteLine((tosho * sasho).ToString());

        Console.WriteLine(((tosho * sasho)-tosho).ToString());
        
    }
}

