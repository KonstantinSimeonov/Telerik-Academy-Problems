using System;

namespace Methods
{
    class Student
    {
        private const string NAME_ERROR_MSG = "Input is not of type string.";
        private const sbyte BIRTH_STRING_LENGTH = 10;
        private const string TYPE_ERROR_MSG = "Type of {0} must be {1}";

        private string firstName;
        private string lastName;
        private string otherInfo;

        public Student(string firstName, string lastName, string otherInfo = null)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.OtherInfo = otherInfo;
        }

        public string FirstName
        {
            get
            {
                return this.firstName;
            }

            set
            {
                if (StringIsValid(value))
                {
                    this.firstName = value;
                }
            }
        }

        public string LastName
        {
            get
            {
                return this.lastName;
            }

            set
            {
                if (StringIsValid(value))
                {
                    this.lastName = value;
                }
            }
        }

        public string OtherInfo
        {
            get
            {
                return this.otherInfo;
            }

            set
            {
                if (value == null || StringIsValid(value))
                {
                    this.otherInfo = value;
                }
            }
        }

        private static bool StringIsValid(string value)
        {
            if (value.GetType() != typeof(string))
            {
                throw new ArgumentException(NAME_ERROR_MSG);
            }

            return true;
        }

        public bool IsOlderThan(Student studentToCompare)
        {
            if (studentToCompare.GetType() != typeof(Student))
            {
                throw new ArgumentException(String.Format(TYPE_ERROR_MSG, studentToCompare.GetType(), typeof(Student)));
            }

            DateTime ageOfCurrentStudent = GetBirth(this);
            DateTime ageOfOtherStudent = GetBirth(studentToCompare);
            bool isOlder = ageOfCurrentStudent > ageOfOtherStudent;

            return isOlder;
        }

        private DateTime GetBirth(Student student)
        {
            var infoLength = student.OtherInfo.Length;
            return DateTime.Parse(student.OtherInfo.Substring(infoLength - BIRTH_STRING_LENGTH));
        }
    }
}
