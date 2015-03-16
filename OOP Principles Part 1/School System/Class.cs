using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class Class
{
    // FIELDS

    private IList<Student> students;
    private IList<Teacher> teachers;

    // PROPERTIES

    public string Identifier { get; private set; }
    public IList<Student> Students
    {
        get
        {
            return students;
        }
        private set
        {
            students = value;
        }
    }
    public IList<Teacher> Teachers
    {
        get
        {
            return teachers;
        }
        private set
        {
            teachers = value;
        }
    
    }

    // INDEXERS

    public Student this[byte index]
    {
        get
        {
            return students[index];
        }
        private set
        {
            students[index] = value;
        }
        
    }

    // CONSTRUCTORS

    public Class(string identifier)
    {
        this.Identifier = identifier;
        this.Students = new List<Student>();
        this.Teachers = new List<Teacher>();
    }

    // METHODS

    public void AddTeacher(Teacher t)
    {
        Teachers.Add(t);
    }

    public void AddStudent(Student s)
    {
        Students.Add(s);
    }

    public void RemovePerson(Person p)
    {
        if (p is Teacher)
        {
            Teachers.Remove((Teacher)p);
        }
        else
        {
            Students.Remove((Student)p);
        }
    }

    public override string ToString()
    {
        return string.Format("In the class {0} are the students:\n{1}\n\nTaught by the teachers:\n", Identifier, Students, Teachers);
    }
}

