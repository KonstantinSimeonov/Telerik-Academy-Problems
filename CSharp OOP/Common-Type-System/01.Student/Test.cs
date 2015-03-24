using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Test
{
    static void Main()
    {
        // student1 is equal to student2

        var student1 = new Student("Pesho Goshov Toshov", "Sibir", "0885044568", "gg@gmail.com", "amthdunnowhut", 2, Universities.NATFIZ, Faculties.Block1, Specialties.Theater);
        var student2 = new Student("Pesho Goshov Toshov", "Sibir", "0885044568", "gg@gmail.com", "smthdunnowhut", 2, Universities.NATFIZ, Faculties.Block1, Specialties.Theater);
        Student empty = null;
        var student3 = new Student("Stamat Goshov Toshov", "Sibir", "0885044568", "wp@gmail.com", "smthdunnowhut", 2, Universities.TU, Faculties.Block2, Specialties.Engineering);

        var students = new Student[] { student3, student2, student1 }.OrderBy(x => x).ToArray();

        foreach (var item in students)
        {
            Console.WriteLine(item);
        }

        //Console.WriteLine(student1.GetHashCode());
        //Console.WriteLine(student3.GetHashCode());


        //Console.WriteLine(student1.Equals(student2));
        //Console.WriteLine(student3.Equals(student1));

        //Console.WriteLine(student1 == student2);
        //Console.WriteLine(student1 == empty);
        //Console.WriteLine(student3 == student1);

        //Console.WriteLine(student3 != student1);
        //Console.WriteLine(student1 != student2);

        //var student4 = (Student)student3.Clone();
        //Console.WriteLine(student4 == student3);
        //Console.WriteLine(ReferenceEquals(student4, student3)); // should return false if the clone is working OK


    }
}