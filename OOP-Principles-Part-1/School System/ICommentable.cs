using System.Collections.Generic;

public interface ICommentable
{
    IList<string> Comments { get; }

    void AddComment(string comment);
}