using System;
using System.Collections.Generic;

class Discipline
{
    public string Name { get; private set; }
    public int NumberOfLectures { get; private set; }
    public int NumberOfExercises { get; private set; }
    public IList<string> Comments { get; private set; }

    public Discipline(string name, int lectures, int exercises)
    {
        this.Name = name;
        this.NumberOfLectures = lectures;
        this.NumberOfExercises = exercises;
        this.Comments = new List<string>();
    }

    public void AddComment(string comment)
    {
        Comments.Add(comment);
    }

    public override string ToString()
    {
        return string.Format("{0}\nNumber of lectures:{1}\nNumber of exercises:{2}", Name, NumberOfLectures, NumberOfExercises);
    }
}