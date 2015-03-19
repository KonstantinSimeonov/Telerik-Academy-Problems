using System;

class InvalidRangeException<T> : Exception
{
    public string message { get; private set; }

    public InvalidRangeException(T start, T end, string message = "Invalid range!")
    {
        this.message = message + string.Format("The range was [{0} ... {1}]", start, end);
    }
}