using System;
using System.Collections.Generic;
using System.Linq;

class Teacher : Person
{
    // FIELDS

    private IList<Discipline> disciplines;

    // PROPERTIES

    public IList<Discipline> Disciplines 
    {
        get
        {
            return new List<Discipline>(disciplines);
        }
        private set
        {
            disciplines = value;
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
    

    // CONSTRUCTORS

    public Teacher(string name, params string[] comments)
        :base(name, comments)
    {
        this.disciplines = new List<Discipline>();
    }

    // METHODS

    public void AddDiscipline(Discipline d)
    {
        disciplines.Add(d);
    }

    public void RemoveDiscipline(Discipline d)
    {
        disciplines.Remove(d);
    }

    public override string ToString()
    {
        return string.Format("{0}, disciplines taught: {1}\ncomments:{2}", Name, string.Join(",\n\n", Disciplines), string.Join("\n", Comments));
    }
}