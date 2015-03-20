class Tomcat : Cat, ISound
{
    // CONSTRUCTORS

    public Tomcat(string name, uint age)
        : base(name, Sex.Male, age)
    { }

    // METHODS

    public override string ToString()
    {
        return string.Format("The tomcat {0}", base.ToString());
    }
}