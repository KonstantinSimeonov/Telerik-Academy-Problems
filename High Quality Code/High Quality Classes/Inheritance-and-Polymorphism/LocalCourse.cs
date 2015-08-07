using System;
using System.Collections.Generic;
using System.Text;

namespace InheritanceAndPolymorphism
{
    public class LocalCourse : Course
    {
        protected const string LOCAL_COURSE = "LocalCourse { Name = ";
        protected const string LAB = "; Lab = ";

        public LocalCourse(string courseName, string teacherName = null, IList<string> students = null)
            : base(courseName, teacherName, students)
        {
            this.Lab = null;
        }

        public string Lab { get; internal set; }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.Append(LOCAL_COURSE);
            result.Append(base.ToString());
            if (this.Lab != null)
            {
                result.Append(LAB);
                result.Append(this.Lab);
            }

            result.Append(RIGHT_BRACE);
            return result.ToString();
        }
    }
}
