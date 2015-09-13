namespace FluentInterfaces.Cats
{
    using System;

    public class Kitten
    {
        public string Name { get; private set; }

        public string FurColor { get; private set; }

        public string State { get; private set; }

        public int AgeInMonths { get; private set; }

        public Kitten()
        {
        }

        public Kitten(string name, string color, string state, int ageInMonths)
        {
            this.Name = name;
            this.FurColor = color;
            this.State = state;
            this.AgeInMonths = ageInMonths;
        }

        public Kitten WithName(string name)
        {
            this.Name = name;
            return this;
        }

        public Kitten WithColor(string color)
        {
            this.FurColor = color;
            return this;
        }

        public Kitten WithState(string state)
        {
            this.State = state;
            return this;
        }

        public Kitten WithAge(int age)
        {
            this.AgeInMonths = age;
            return this;
        }

        public override string ToString()
        {
            return "The " + this.FurColor + " kitten " + this.Name + " is " + this.AgeInMonths + " months old and is " + this.State;
        }
    }
}
