using System;

//Problem 4. Person class

//Create a class Person with two fields – name and age. 
//Age can be left unspecified (may contain null value. 
//Override ToString() to display the information of a person and if age is not specified – to say so.
//Write a program to test this functionality.

class Person
{
    public string Name { get; private set; }
    public byte? Age { get; private set; }

    public Person(string name, byte? age = null)
    {
        this.Name = name;
        this.Age = age;
    }

    public override string ToString()
    {
        return string.Format("Name: {0} Age: {1}", Name, Age == null ? "no info": Age.ToString());
    }
}