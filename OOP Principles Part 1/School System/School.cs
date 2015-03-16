using System;
using System.Collections.Generic;

enum SchoolType { OU = 1, SOU = 2}

class School
{
    private string name;
    private SchoolType type;
    private IList<Class> classes;
    private IList<Teacher> teachers;
    private IList<Student> students;

    public string Name
    {
        get
        {
            return name;
        }
        private set
        {
            if (!string.IsNullOrEmpty(value))
            {
                name = value;
            }
            else
            {
                throw new ArgumentNullException("String cannot be empty or null!");
            }
        }
    }

    public IList<Class> Classes
    {
        get
        {
            return classes;
        }
        private set
        {
            classes = value;
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

    public SchoolType Type
    {
        get
        {
            return type;
        }
        private set
        {
            type = value;
        }
    }

    public School(string name, SchoolType type)
    {
        this.Name = name;
        this.Type = type;
        this.Classes = new List<Class>();
        this.Teachers = new List<Teacher>();
        this.Students = new List<Student>();
    }

    public void AddClass(Class c)
    {
        Classes.Add(c);
    }

    public void AddTeacher(Teacher t)
    {
        Teachers.Add(t);
    }

    public void AddStudent(Student s)
    {
        Students.Add(s);
    }

    public void RemoveClass(string classID)
    {
        for (int i = 0; i < Classes.Count; i++)
        {
            if (classID == Classes[i].Identifier)
            {
                Classes.RemoveAt(i);
                return;
            }
        }
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

    public void PrintRoster()
    {
        Console.WriteLine(string.Join(",\n", Students));
        Console.WriteLine("\n\n\n{0}", string.Join(",\n\n", Teachers));
    }
        
}

