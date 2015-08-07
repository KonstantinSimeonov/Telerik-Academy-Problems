namespace InheritanceAndPolymorphism
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public abstract class Course
    {
        protected const string SEPARATOR = ", ";
        protected const string EMPTY_COURSE_AS_STRING = "{ }";
        protected const string LEFT_BRACE = "{ ";
        protected const string RIGHT_BRACE = " }";
        protected const string TEACHER = "; Teacher = ";
        protected const string STUDENTS = "; Students = ";

        private IList<string> stundents;

        public Course(string courseName, string teacherName, IList<string> students)
        {
            this.Name = courseName;
            this.TeacherName = teacherName;
            this.Students = students == null ? new List<string>() : students;
        }

        public string Name { get; internal set; }

        public string TeacherName { get; internal set; }

        public IList<string> Students
        {
            get
            {
                return new List<string>(this.stundents);
            }
            internal set
            {
                this.stundents = value;
            }
        }

        public virtual string GetStudentsAsString()
        {
            if (this.Students == null || this.Students.Count == 0)
            {
                return EMPTY_COURSE_AS_STRING;
            }
            else
            {
                var stundentsAsString = LEFT_BRACE + string.Join(SEPARATOR, this.Students) + RIGHT_BRACE;

                return stundentsAsString;
            }
        }

        public override string ToString()
        {
            var result = new StringBuilder();

            result.Append(this.Name);
            if (this.TeacherName != null)
            {
                result.Append(TEACHER);
                result.Append(this.TeacherName);
            }

            result.Append(STUDENTS);
            result.Append(this.GetStudentsAsString());

            return result.ToString();
        }
    }

}