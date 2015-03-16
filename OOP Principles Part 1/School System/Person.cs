abstract class Person
{
    public string Name { get; private set; }

    public Person(string name)
    {
        this.Name = name;
    }
}