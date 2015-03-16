using System;
using System.Reflection;
using Path3D;


class Test
{
    static void Main()
    {

        // POINTS, PATH, PATHSTORAGE DEMO

        Console.WriteLine("POINTS:");
        Point3D r = new Point3D(3, 3, 3);
        Console.WriteLine(DistanceCalculator3D.CalculateDistanceBetween(r, Point3D.PointO));
        Console.WriteLine(Point3D.PointO + "\n" + r);

        Console.WriteLine("\nPATH AND STORAGE");
        // path
        Path p = new Path(new Point3D(1, 2, 3), new Point3D(0, 2, 2), new Point3D(4, -4, 4));
        Console.WriteLine(p);

        // store
        Console.WriteLine("{0}", PathStorage.TryStore(p) ? string.Format("Path stored successfully in {0}", PathStorage.LastPath) : "Path couldn't be stored.");


        // LIST DEMO
        Console.WriteLine("\n\nGENERICLIST DEMO");

        GenericList<Point3D> path = new GenericList<Point3D>();

        // add some lots of stuff inside
        Console.WriteLine("Adding some elements:");

        for (int i = 0; i < 1000000; i++)
        {
            path.Add(new Point3D(i, i % 5, Math.Sqrt(i * i * i)));
        }

        // Remove some elements at random
        Console.WriteLine("Removing some stuff.");

        Random rng = new Random();

        for (int i = 700000; i >= 0; i--)
        {
            path.RemoveAt(rng.Next(0, 300000 + i), false); // don't keep the order, its gonna take forever!
        }

        // version test
        Console.WriteLine("Version of GenericList class is {0}", typeof(GenericList<Point3D>).GetCustomAttribute<Version>());

        //test min/max

        Console.WriteLine("\nCreating new list with some numbers:");

        GenericList<int> numbers = new GenericList<int>();
        for (int i = 0; i < 20; i++)
        {
            numbers.Add(i % 2 == 0 ? i+1 : (-i));
        }

        for (int i = 0; i < numbers.Count; i++)
        {
            Console.Write(numbers[i] + ",");
        }

        numbers.RemoveAt(5, false);
        for (int i = 0; i < numbers.Count; i++)
        {
            Console.Write(numbers[i] + ",");
        }

        Console.WriteLine("Min:{0} , Max:{1}", numbers.Min(), numbers.Max());



        // MATRICES DEMO

        Console.WriteLine("\nMATRICES DEMO");

        var arr = new int[,] {
                             {-1,2,-3,-4,-5,6},
                             {1,-2,3,4,-5,6},
                             {1,2,3,4,5,6},
                             {1,-2,3,4,-5,6},
                             {1,2,-3,4,5,6},
                             };

        var zero = new int[,] {
                             {0,0,0},
                             {0,0,0},
                             {0,0,0},
                             {0,0,0},
                             {0,0,0},
                             };

        var arr2 = new double[,] {
                               {1.3,1.2,-1.7,1,1.9,1},
                               {1.3,1.2,-1.7,1,1.9,1},
                               {1.3,1.2,-1.7,1,1.9,1},
                               {1.3,1.2,-1.7,1,1.9,1},
                               {1.3,1.2,-1.7,1,1,1.1},
                               {1.3,1.2,-1.7,1,1,1.1},
                              };

        // creating matrices
        Matrix<int> n = new Matrix<int>(zero);
        Matrix<int> m = new Matrix<int>(arr);

        // true and false
        var ismtrue = m ? true : false;
        var isntrue = n ? true : false;

        // print true and false
        Console.WriteLine(ismtrue);
        Console.WriteLine(isntrue);

        // test operations
        Console.WriteLine("Addition \n{0}", m+m);
        Console.WriteLine("Substraction \n{0}", m-m);
        Console.WriteLine("Multiplication \n{0}",new Matrix<double>(arr2) * new Matrix<double>(arr2));

    }
}

