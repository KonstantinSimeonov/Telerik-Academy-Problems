using System;

class Human
{
    // FIELDS

    private string firstName, lastName;

    // PROPERTIES

    public string FirstName
    {
        get
        {
            return firstName;
        }

        private set
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentException("Name cannot be null or empty!");
            }

            firstName = value;
        }
    }

    public string LastName
    {
        get
        {
            return lastName;
        }

        private set
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentException("Name cannot be null or empty!");
            }

            lastName = value;
        }
    }

    // CONSTRUCTORS

    public Human(string fname, string lname)
    {
        FirstName = fname;
        LastName = lname;
    }

    // METHODS

    public override string ToString()
    {
        return string.Format("{0} {1}", FirstName, LastName);
    }
}

