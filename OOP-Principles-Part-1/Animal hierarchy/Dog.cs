using System;

class Dog : Animal, ISound
{
    // CONSTRUCTORS

    public Dog(string name, Sex sex, uint age)
        : base(name, sex, age)
    { }

    // METHODS

    public override void Greet()
    {
        Console.WriteLine("woof!");
    }

    public override string ToString()
    {
         return string.Format("The dog {0}",base.ToString());
    }
}
