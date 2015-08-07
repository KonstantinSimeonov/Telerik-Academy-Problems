using System;
using System.Collections.Generic;
using System.Text;

namespace InheritanceAndPolymorphism
{
    public class OffsiteCourse : Course
    {
        protected const string OFFSITE = "OffsiteCourse { Name = ";
        protected const string TOWN = "; Town = ";

        public OffsiteCourse(string courseName, string teacherName = null, IList<string> students = null)
            : base(courseName, teacherName, students)
        {
            this.Town = null;
        }

        public string Town { get; internal set; }

        public override string ToString()
        {
            var result = new StringBuilder();
            result.Append(OFFSITE);
            result.Append(base.ToString());
            if (this.Town != null)
            {
                result.Append(TOWN);
                result.Append(this.Town);
            }

            result.Append(RIGHT_BRACE);
            return result.ToString();
        }
    }
}
