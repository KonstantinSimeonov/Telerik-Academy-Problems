using System;
using System.Collections.Generic;
using System.Linq;

class Test
{
    // felt like generating some random records

    // CONSTANTS

    public const uint numberOfStudentsAndWorkers = 10;
    public const int minSalary = 350;
    public const int maxSalary = 1500;
    public const byte minHours = 4;
    public const byte maxHours = 16;
    public const byte minGrade = 2;
    public const byte maxGrade = 6;

    // some names

    public static string[] fnames = { 
                                        "Gosho",
                                        "Tosho",
                                        "Pesho",
                                        "Penka",
                                        "Richard",
                                        "Ivan",
                                        "Kircho",
                                        "Latinka",
                                        "Petko",
                                        "Boris",
                                        "Genadii",
                                        "Stamatka",
                                        "Galina",
                                        "Mariika",
                                        "Dimitrichka",
                                        "Neli",
                                        "Todorka",
                                        "Grigor",
                                        "Gigorka",
                                        "Pancho"
                                    };

    public static string[] lnames = { 
                                        "Ivanov",
                                        "Dimitrov",
                                        "Grigorov",
                                        "Penkova",
                                        "Dickson",
                                        "Ivanov",
                                        "Dragoev",
                                        "Nikodimova",
                                        "Simeonov",
                                        "Cvetkov",
                                        "Pachnikov",
                                        "Deleva",
                                        "Vladimirova",
                                        "Dimitrova",
                                        "Shishkova",
                                        "Lukova",
                                        "Stamatova",
                                        "Vlaskovski",
                                        "Piperova",
                                        "Vladigerov"
                                    };

    public static Random rnd = new Random();

    static void Main()
    {
        

        var students = new List<Student>();
        var workers = new List<Worker>();

        // initialize with some random records
        for (int i = 0; i < numberOfStudentsAndWorkers; i++)
        {
            students.Add(new Student(fnames[i],
                                     lnames[i],
                                     (byte)rnd.Next(minGrade, maxGrade+1)));


            workers.Add(new Worker(fnames[i + numberOfStudentsAndWorkers],
                                   lnames[i + numberOfStudentsAndWorkers],
                                   (uint)rnd.Next(minSalary, maxSalary + 1),
                                   (byte)rnd.Next(minHours, maxHours + 1)));
        }

        // order and print

        students = students.OrderBy(x => x.Grade).ToList();
        workers = workers.OrderByDescending(x => x.MoneyPerHour()).ToList();

        Console.WriteLine("{0}\n\n\n\n{1}\n\n\n\n\n", string.Join(",\n", students), string.Join(",\n", workers));

        // merge, order, print

        var peeps = new List<Human>(students).Concat(workers).OrderBy(x => x.FirstName).ThenBy(x => x.LastName).ToList();

        Console.WriteLine(string.Join(",\n", peeps));
    }
}

