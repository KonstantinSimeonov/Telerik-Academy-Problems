using System;

abstract class Cat : Animal, ISound
{
    // CONSTRUCTORS

    public Cat(string name, Sex sex, uint age)
        : base(name, sex, age)
    { }

    // METHODS

    public override void Greet()
    {
        Console.WriteLine("meow!");
    }
}