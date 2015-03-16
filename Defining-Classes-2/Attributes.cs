using System;


[AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Enum)]
class Version : Attribute
{
    private string version;

    public Version(string str)
        : base()
    {
        version = str;
    }

    public override string ToString()
    {
        return version;
    }
}

