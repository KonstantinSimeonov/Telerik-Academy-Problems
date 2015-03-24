using System;
using System.Text;

class OutOfRangeException : Exception
{
    private string message;

    public OutOfRangeException()
    {
        message = "Number was out of set boundaries.";
    }

    public override string Message
    {
        get
        {
            return message;
        }
    }
}

