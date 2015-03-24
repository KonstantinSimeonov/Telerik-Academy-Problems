using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class Student : Person
{
    public byte ClassNumber { get; private set; }

    public Student(string name, byte classNumber, params string[] comments)
        :base(name, comments)
    {
        this.ClassNumber = classNumber;
    }

    public override string ToString()
    {
        return string.Format("{0} number: {1}", Name, ClassNumber);
    }
}

