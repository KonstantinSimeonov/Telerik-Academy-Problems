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
            return new List<Class>(classes);
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
            return new List<Teacher>(teachers);
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
            return new List<Student>(students);
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
        this.classes = new List<Class>();
        this.teachers = new List<Teacher>();
        this.students = new List<Student>();
    }

    /// <summary>
    /// Returns a reference to the teacher at the given index.
    /// </summary>
    /// <param name="index"></param>
    /// <returns></returns>
    public Teacher this[int index]
    {
        get
        {
            return teachers[index];
        }
    }

    public void AddClass(Class c)
    {
        classes.Add(c);
    }

    public void AddTeacher(Teacher t)
    {
        teachers.Add(t);
    }

    public void AddStudent(Student s)
    {
        students.Add(s);
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
            teachers.Remove((Teacher)p);
        }
        else
        {
            students.Remove((Student)p);
        }
    }

    public void PrintRoster()
    {
        Console.WriteLine(string.Join(",\n", Students));
        Console.WriteLine("\n\n\n{0}", string.Join(",\n\n", Teachers));
    }
        
}

