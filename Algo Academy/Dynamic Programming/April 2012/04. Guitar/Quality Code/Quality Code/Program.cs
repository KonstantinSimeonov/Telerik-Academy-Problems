using System;

namespace Task1
{
    public class Outer
    {
        const int MAX_COUNT = 6;
        public class Nested
        {
            public void PrintBoolAsString(bool boolVar)
            {
                string boolAsString = boolVar.ToString();
                Console.WriteLine(boolAsString);
            }
        }
        public static void Input()
        {
            var nestedClassInstance = new Outer.Nested();
            nestedClassInstance.PrintBoolAsString(true);
        }
    }
}

namespace Task2
{
    class Main
    {
        enum Sex { male, female };

        class Person
        {
            public Sex Sex { get; set; }
            public string Name { get; set; }
            public int Age { get; set; }
        }

        public void CreatePerson(int age)
        {
            var newPerson = new Person();
            newPerson.Age = age;
            if (age % 2 == 0)
            {
                newPerson.Name = "Батката";
                newPerson.Sex = Sex.male;
            }
            else
            {
                newPerson.Name = "Мацето";
                newPerson.Sex = Sex.female;
            }
        }
    }
}

namespace Task3
{

}