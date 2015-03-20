class Kitten : Cat, ISound
{
    // CONSTRUCTORS

    public Kitten(string name, uint age)
        : base(name, Sex.Female, age)
    { }

    // METHODS

    public override string ToString()
    {
        return string.Format("The kitten {0}", base.ToString());
    }
}