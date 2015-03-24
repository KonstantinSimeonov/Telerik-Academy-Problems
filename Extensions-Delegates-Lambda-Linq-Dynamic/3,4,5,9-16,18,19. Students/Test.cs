using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

class Test
{
    // marks constraints for the random generator
    public const int minMarks = 2;
    public const int maxMarks = 7;

    // my beloved
    public static Random rnd = new Random();

    // store the students on which we'll perform all operations
    public static Student[] students;

    // hardcoded names
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

    public static string[] mails = {
                                        "@mail.bg",
                                        "@abv.bg",
                                        "@gmail.com"
                                   };

    // some generator functions

    public static string GenerateFN()
    {
        string FN = string.Empty;

        if ((rnd.Next() & 1) == 0)
        {
            FN += "06";
        }

        while (FN.Length < 6)
        {
            FN = FN.Insert(0, rnd.Next(0, 10).ToString());
        }

        return FN;
    }


    public static string GenerateTel()
    {
        string tel = "0";
        int digitsLeft = 8;

        for (int i = digitsLeft; i >= 0; i--)
        {
            tel += rnd.Next(0, 10);
        }

        return tel;
    }

    public static void Problem3()
    {
        //Problem 3. First before last

        //Write a method that from a given array of students finds all students whose first name is before its last name alphabetically.
        //Use LINQ query operators.
        Console.WriteLine("First before last\n\n{0}", string.Join("\n", (object[])Student.FirstBeforeLast(students)));
    }

    public static void Problem4()
    {
        //Problem 4. Age range

        //Write a LINQ query that finds the first name and last name of all students with age between 18 and 24.
        Console.WriteLine("Problem 4. Age Range \n\n{0}", string.Join("\n", (object[])Student.AgeRange(students, 18, 24)));
    }
    public static void Problem5()
    {
        //Problem 5. Order students

        //Using the extension methods OrderBy() and ThenBy() with lambda expressions sort the students by first name and last name in descending order.
        //Rewrite the same with LINQ.
        Console.WriteLine("Problem 5. Ordering by first then by last\n\n");
        Console.WriteLine("Extensions:\n\n{0}\n\n", string.Join("\n", (object[])students.OrderBy(x => x.FirstName).ThenBy(x => x.LastName).ToArray()));

        var ordered = from student in students
                      orderby student.FirstName ascending, student.LastName ascending
                      select student;

        Console.WriteLine("LINQ:\n\n{0}", string.Join("\n", (object[])ordered.ToArray()));
    }
    public static void Problem9()
    {
        //Problem 9. Student groups

        //Create a class Student with properties FirstName, LastName, FN, Tel, Email, Marks (a List), GroupNumber.
        //Create a List<Student> with sample students. Select only the students that are from group number 2.
        //Use LINQ query. Order the students by FirstName.
        var sampleStudents = from student in students
                             where student.GroupNumber == 2
                             orderby student.FirstName
                             select student;
        var studentsOfGroup2 = sampleStudents.ToList();
        Console.WriteLine(string.Join(",\n", studentsOfGroup2));
    }
    public static void Problem10()
    {
        //Problem 10. Student groups extensions

        //Implement the previous using the same query expressed with extension methods.
        var sampleWithExtensions = students.Where(x => x.GroupNumber == 2).OrderBy(x => x.FirstName).ToList();
        Console.WriteLine(string.Join(",\n", sampleWithExtensions));
    }
    public static void Problem11()
    {
        //Problem 11. Extract students by email

        //Extract all students that have email in abv.bg.
        //Use string methods and LINQ.

        var studentWithAbv = from student in students
                             where student.Email.Substring(student.Email.IndexOf("@"), student.Email.Length - student.Email.IndexOf("@")) == mails[1]
                             select student;

        Console.WriteLine("\n\n\nProblem 11. Students with mails in abv.bg\n{0}", string.Join("\n", studentWithAbv));
    }
    public static void Problem12()
    {
        //Problem 12. Extract students by phone

        //Extract all students with phones in Sofia.
        //Use LINQ.

        var studentWithPhoneInSofia = from student in students
                                      where student.Tel.Substring(0, 2) == "02"
                                      select student;

        Console.WriteLine("Students with Sofia number:\n\n{0}\n\n\n\n", string.Join(", ", studentWithPhoneInSofia));
    }
    public static void Problem13()
    {
        //Problem 13. Extract students by marks

        //Select all students that have at least one mark Excellent (6) into a new anonymous class that has properties – FullName and Marks.
        //Use LINQ.

        Console.WriteLine("Problem 13. Annonymous class students:\n");

        var annonymousStudents = from student in students
                                 where student.Marks.Contains(6)
                                 select new
                                 {
                                     FullName = string.Format("{0} {1}", student.FirstName, student.LastName),
                                     Marks = student.Marks,

                                 };

        foreach (var item in annonymousStudents)
        {
            Console.WriteLine("{0} - Marks:{1}", item.FullName, string.Join(", ", item.Marks));
        }
    }
    public static void Problem14()
    {
        //Problem 14. Extract students with two marks

        //Write down a similar program that extracts the students with exactly two marks "2".
        //Use extension methods.

        var dvoikari = students.Where(s => s.Marks.Count(m => m == (byte)2) == 2);

        Console.WriteLine(string.Join("\n", dvoikari));
    }
    public static void Problem15()
    {
        //Problem 15. Extract marks

        //Extract all Marks of the students that enrolled in 2006. (The students from 2006 have 06 as their 5-th and 6-th digit in the FN).

        var enrolled = from student in students
                       where student.FN.Substring(student.FN.Length - 2) == "06"
                       select student.Marks;

        Console.WriteLine("Problem 15. Marks of students that enrolled in 2006:\n\n");

        foreach (var item in enrolled)
        {
            Console.Write("{0}, ", string.Join(", ", item));
        }
    }
    public static void Problem16()
    {
        //Problem 16.* Groups

        //Create a class Group with properties GroupNumber and DepartmentName.
        //Introduce a property GroupNumber in the Student class.
        //Extract all students from "Mathematics" department.
        //Use the Join operator.


        // I'll consider groups with number 2 and 5 to be in the Mathematics department

        var mathGroups = Group.GetMathsGroups();

        var mathStudents = from student in students
                           join gr in mathGroups on student.GroupNumber equals gr.GroupNumber
                           select new
                           {
                               MathStudent = student,
                               Department = DepartmentNames.Mathematics,
                           };

        Console.WriteLine("\n\n\n\nStudents in Maths Department:\n\n");

        foreach (var item in mathStudents)
        {
            Console.WriteLine(item);
        }
    }
    public static void Problem18()
    {
        //Problem 18. Grouped by GroupNumber

        //Create a program that extracts all students grouped by GroupNumber and then prints them to the console.
        //Use LINQ.

        var groupedStudents = from student in students
                              group student by student.GroupNumber into grouped
                              from gr in grouped
                              select gr;

        Console.WriteLine("\n\n\n\nProblem 18. Grouped by groupNumber:\n\n");

        foreach (var item in groupedStudents)
        {
            Console.WriteLine(item);
        }
    }
    public static void Problem19()
    {
        //Problem 19. Grouped by GroupName extensions

        //Rewrite the previous using extension methods.

        var groupedStudentsExtensions = students.GroupBy(s => s.GroupNumber);

        Console.WriteLine("\n\n\n\n Grouping by GroupNumber using extensions:\n");

        foreach (var group in groupedStudentsExtensions)
        {
            foreach (var student in group)
            {
                Console.WriteLine(student);
            }
        }
    }

    static void Main()
    {
        // allocate random students

        students = new Student[fnames.Length / 2];

        for (int i = 0; i < students.Length; i++)
        {
            // create a student
            students[i] = new Student(fnames[i], lnames[i], rnd.Next(19, 50), GenerateFN(), GenerateTel(), (byte)rnd.Next(1, 7));

            // set his mail according to his name
            students[i].SetEmail(students[i].FirstName[0] + "." + students[i].LastName + mails[rnd.Next(0, mails.Length)]);

            // the number of marks for the current student
            int marks = rnd.Next(minMarks, maxMarks);

            // add some random marks
            for (int j = 0; j < marks; j++)
            {
                students[i].AddMark((byte)rnd.Next(minMarks, maxMarks));
            }
        }

        Console.WriteLine("THE STUDENT RECORDS ARE RANDOMLY GENERATED EVERY TIME, SO EMPTY OUTPUT IS SOMETIMES POSSIBLE");

        // the problems are too damn many to stay all in main, that's why i did a menu

        while (true)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\nChoose a problem to display solution\n3,4,5,9-16,18,19\ntype 20 to display all students, 0 to clear the console and -1 to exit");
            int choice = int.Parse(Console.ReadLine());
            Console.ForegroundColor = ConsoleColor.Gray;
            switch (choice)
            {
                case -1: return;
                case 0: Console.Clear(); break;
                case 3: Problem3(); break;
                case 4: Problem4(); break;
                case 5: Problem5(); break;
                case 9: Problem9(); break;
                case 10: Problem10(); break;
                case 11: Problem11(); break;
                case 12: Problem12(); break;
                case 13: Problem13(); break;
                case 14: Problem14(); break;
                case 15: Problem15(); break;
                case 16: Problem16(); break;
                case 18: Problem18(); break;
                case 19: Problem19(); break;
                case 20: Console.WriteLine(string.Join("\n", (object[])students)); break;
                default:
                    break;
            }
        }



    }
}