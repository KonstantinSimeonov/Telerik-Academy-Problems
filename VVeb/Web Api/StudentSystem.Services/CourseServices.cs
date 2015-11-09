namespace StudentSystem.Services
{
    using Data.Repositories;
    using Models;
    using System.Linq;

    public class CourseServices
    {
        private IGenericRepository<Course> courses;

        public CourseServices(IGenericRepository<Course> coursesRepository)
        {
            this.courses = coursesRepository;
        }

        public IQueryable<Course> GetJavascriptCourses()
        {
            var result = this.courses
                                .All()
                                .Where(c => c.Name.Contains("js"));

            return result;
        }

        public void AddStudentToCourse(Student student, string courseName)
        {
            var courseToAddStudentTo = this.GetCourseByName(courseName);

            if (courseToAddStudentTo != null)
            {
                courseToAddStudentTo.Students.Add(student);
                student.Courses.Add(courseToAddStudentTo);
            }
        }

        public void AddHomeworkToCourse(Homework homework, string courseName)
        {
            var course = this.GetCourseByName(courseName);

            if(course != null)
            {
                course.Homeworks.Add(homework);
                homework.Course = course;
            }
        }

        public Course GetCourseByName(string courseName)
        {
            var result = this.courses
                                 .All()
                                 .FirstOrDefault(c => c.Name == courseName);
            return result;
        }
    }
}
