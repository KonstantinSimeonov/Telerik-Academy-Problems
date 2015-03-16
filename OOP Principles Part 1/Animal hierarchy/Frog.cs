using System;

class Frog : Animal, ISound
{
    // CONSTRUCTORS

    public Frog(string name, Sex sex, uint age)
        : base(name, sex, age)
    { }

    // METHODS

    public override void Greet()
    {
        Console.WriteLine("wwrabbit!");
    }

    public override string ToString()
    {
        return string.Format("The frog {0}", base.ToString());
    }
}