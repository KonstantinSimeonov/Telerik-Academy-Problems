using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class Class : ICommentable
{
    // FIELDS

    private IList<Student> students;
    private IList<Teacher> teachers;
    private IList<string> comments;

    // PROPERTIES

    public string Identifier { get; private set; }
    public IList<Student> Students
    {
        get
        {
            return new List<Student>(students);
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
            return new List<Teacher>(teachers);
        }
        private set
        {
            teachers = value;
        }
    
    }
    public IList<string> Comments
    {
        get
        {
            return new List<string>(comments);
        }
        private set
        {
            comments = value;
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

    public Class(string identifier, params string[] comments)
    {
        this.Identifier = identifier;
        this.students = new List<Student>();
        this.teachers = new List<Teacher>();
        this.comments = new List<string>(comments);
    }

    // METHODS

    public void AddComment(string comment)
    {
        this.comments.Add(comment);
    }

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

