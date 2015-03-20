using System;

public enum Sex { Female = 0, Male = 1};

abstract class Animal : ISound
{
    // FIELDS

    private string name;
    private Sex sex;
    private uint age;

    // PROPERTIES

    public string Name
    {
        get
        {
            return name;
        }

        private set
        {
            if (string.IsNullOrEmpty(value.Trim()))
            {
                throw new ArgumentException("Name cannot be null or empty");
            }

            name = value;
        }
    }

    public Sex Sex
    {
        get
        {
            return sex;
        }

        private set
        {
            sex = value;
        }
    }

    public uint Age
    {
        get
        {
            return age;
        }

        private set
        {
            age = value;
        }
    }

    // CONSTRUCTORS

    public Animal(string name, Sex sex, uint age)
    {
        this.Name = name;
        this.Sex = sex;
        this.Age = age;
    }

    // METHODS

    public abstract void Greet();

    public override string ToString()
    {
        return string.Format("{0}, {1}, {2} years old", name, sex, age);
    }

}

