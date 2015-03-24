using System.Collections.Generic;

abstract class Person : ICommentable
{
    protected IList<string> comments;

    public string Name { get; private set; }

    public IList<string> Comments
    {
        get
        {
            return new List<string>(comments);
        }

        protected set
        {
            comments = value;
        }
    }

    public Person(string name, params string[] comments)
    {
        this.Name = name;
        this.comments = new List<string>(comments);
    }

    public void AddComment(string comment)
    {
        this.comments.Add(comment);
    }
}