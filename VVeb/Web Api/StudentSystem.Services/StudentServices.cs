namespace StudentSystem.Services
{
    using Data.Repositories;
    using Models;
    using System.Linq;

    public class StudentServices
    {
        private IGenericRepository<Student> students;

        public StudentServices(IGenericRepository<Student> studentsRepository)
        {
            this.students = studentsRepository;
        }

        public IQueryable<Student> GetStudentsOrderedByName()
        {
            var result = this.students
                                .All()
                                .OrderBy(s => s.FirstName)
                                .ThenBy(s => s.LastName);

            return result;
        }

        public IQueryable<Student> GetStudentsWithName(string name)
        {
            var result = this.students
                                   .All()
                                   .Where(s => s.FirstName == name);

            return result;
        }

        public void EnrollStudent(Student student)
        {
            if(!this.students.All().Contains(student))
            {
                this.students.Add(student);
            }
        }
    }
}