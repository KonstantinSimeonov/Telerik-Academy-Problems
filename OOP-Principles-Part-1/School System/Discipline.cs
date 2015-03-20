using System;
using System.Collections.Generic;

class Discipline : ICommentable
{
    private IList<string> comments;

    public string Name { get; private set; }
    public int NumberOfLectures { get; private set; }
    public int NumberOfExercises { get; private set; }
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

    public Discipline(string name, int lectures, int exercises, params string[] comments)
    {
        this.Name = name;
        this.NumberOfLectures = lectures;
        this.NumberOfExercises = exercises;
        this.comments = new List<string>(comments);
    }

    public void AddComment(string comment)
    {
        this.comments.Add(comment);
    }

    public override string ToString()
    {
        return string.Format("{0}\nNumber of lectures:{1}\nNumber of exercises:{2}", Name, NumberOfLectures, NumberOfExercises);
    }
}