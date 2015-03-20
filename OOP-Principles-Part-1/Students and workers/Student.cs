using System;

class Student : Human
{
    // FIELDS

    private byte grade;

    // PROPERTIES

    public byte Grade
    {
        get
        {
            return grade;
        }

        set
        {
            if (value < 2 || value > 6)
            {
                throw new ArgumentException(string.Format("Grade must be between 2 and 6: {0}", value));
            }

            grade = value;
        }
    }

    // CONSTRUCTORS

    public Student(string fname, string lname, byte grade)
        : base(fname, lname)
    {
        this.Grade = grade;
    }

    // METHODS

    public override string ToString()
    {
        return "Student " + base.ToString() + string.Format(" | Grade: {0}", Grade);
    }
}

