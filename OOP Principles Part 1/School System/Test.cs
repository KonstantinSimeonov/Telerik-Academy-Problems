using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;



class Test
{
    public const int maxClassNumber = 30;
    public const int teachersCount = 4;
    public const int minLectures = 2, minExercises = 2;
    public const int maxLectures = 9, maxExercises = 5;

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

    public static string[] disciplines = 
    {
        "Maths",
        "Physics",
        "Literature",
        "French",
        "Biology",
        "Music",
        "Dancing",
        "Chemistry",
        "Painting",
        "Psychology",
        "Computer science"
    };

    public static string[] comments = 
    {
        "Studied at Cambridge",
        "Loves pizza",
        "Graduated from a german university",
        "Has a german shepherd",
        "Has two children"
    };

    public static Random rnd = new Random();

    static void Main()
    {
        // generate a school with semi-random records

        School school = new School("Telerig", SchoolType.SOU);

        for (int i = 0; i < fnames.Length - teachersCount; i++)
        {
            school.AddStudent(new Student(fnames[i], (byte)i));
        }

        for (int i = 0; i < teachersCount; i++)
        {
            school.AddTeacher(new Teacher(fnames[fnames.Length - teachersCount + i], comments[rnd.Next(0, comments.Length)]));
            school.Teachers[i].AddDiscipline(new Discipline(disciplines[rnd.Next(0, disciplines.Length)],
                                                             rnd.Next(minLectures, maxLectures),
                                                             rnd.Next(minLectures, maxLectures)));
        }

        // add a discipline to a teacher

        school.Teachers[2].AddDiscipline(new Discipline(disciplines[0], 5, 1));

        // remove a teacher
        //school.RemovePerson(school.Teachers[1]);


        school.PrintRoster();
    }
}

