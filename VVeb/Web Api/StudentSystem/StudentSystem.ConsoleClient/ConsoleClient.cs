namespace StudentSystem.ConsoleClient
{
    using System;
    using System.Linq;
    using StudentSystem.Data;
    using StudentSystem.Models;
    using System.Data.Entity;
    using System.Data.Entity.Validation;
    using System.Data;
    using System.Collections.Generic;
    using Services;
    using Data.Repositories;

    public class ConsoleClient
    {
        public static void Main()
        {
            Database.SetInitializer(new DropCreateDatabaseAlways<StudentSystemDbContext>());

            var data = new StudentsSystemData();

            var courses = data.Courses.All();

            var students = data.Students.All();

            var courseNames = new string[] { "js apps", "js ui and dom", "csharp oop", "databases" };

            foreach (var name in courseNames)
            {
                data.Courses.Add(new Course()
                {
                    Description = "kopon",
                    Name = name
                });
            }

            data.SaveChanges();

            foreach (var course in courses)
            {
                Console.WriteLine(course.Name);
            }

            var courseServices = new CourseServices(data.Courses);

            Console.WriteLine(string.Join(", ", courseServices.GetJavascriptCourses().Select(c => c.Name)));

            var student = new Student()
            {
                FirstName = "pencho",
                LastName = "genchov",
                Level = 99,
                AdditionalInformation = new StudentInfo() { Address = "ul. gorno nanadolnishte", Email = "pencho.svalqcha@gmail.com" }
            };

            data.Students.Add(student);
            courseServices.AddStudentToCourse(student, "js apps");
            
            data.SaveChanges();
            
            var pencho = data.Students.All().FirstOrDefault(s => s.FirstName == "pencho");

            Console.WriteLine("pencho is in the " + pencho.Courses.FirstOrDefault().Name + " course");
        }
    }
}
