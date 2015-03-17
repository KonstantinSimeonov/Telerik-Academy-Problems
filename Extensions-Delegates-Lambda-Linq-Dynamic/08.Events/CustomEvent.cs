using System;

class CustomEvent : EventArgs
{
    // PROPERTIES

    public string Message { get; set; }

    // CONSTRUCTORS

    public CustomEvent(string text)
    {
        Message = text;
    }

    // METHODS

    public override string ToString()
    {
        return Message;
    }
}

