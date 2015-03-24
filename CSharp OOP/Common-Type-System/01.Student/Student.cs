using System;
using System.Collections.Generic;

// add for serialization
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Reflection;

//  Problem 1. Student class

//  Define a class Student, which contains data about a student – first, middle and last name, 
//  SSN, permanent address, mobile phone e-mail, course, specialty, university, faculty. 
//  Use an enumeration for the specialties, universities and faculties.
//  Override the standard methods, inherited by System.Object: Equals(), ToString(), GetHashCode() and operators == and !=.

public enum Universities { SU, TU, UNSS, NATFIZ };
public enum Specialties { Law, Arts, Economics, Theater, Engineering };
public enum Faculties { FMI, FHF, SF, Block1, Block2 };

[Serializable]
class Student : ICloneable, IComparable<Student>
{
    // FIELDS

    private string[] Names;

    // PROPERTIES

    public string FirstName
    {
        get
        {
            return Names[0];
        }
    }

    public string MiddleName
    {
        get
        {
            return Names[1];
        }
    }

    public string LastName
    {
        get
        {
            return Names[2];
        }
    }

    public string WholeName
    {
        get
        {
            return string.Format("{0} {1} {2}", FirstName, MiddleName, LastName);
        }
    }

    public string Adress { get; private set; }
    public string Phone { get; private set; }
    public string Email { get; private set; }
    public string SSN { get; private set; }
    public byte Course { get; private set; }
    public Universities University { get; private set; }
    public Faculties Faculty { get; private set; }
    public Specialties Specialty { get; private set; }

    // CONSTRUCTORS

    public Student(string name, string adress, string phone, string email, string ssn, byte course, Universities uni, Faculties fac, Specialties spec)
    {
        Names = name.Split(' ');
        this.Adress = adress;
        this.Phone = phone;
        this.Email = email;
        this.SSN = ssn;
        this.Course = course;
        this.University = uni;
        this.Faculty = fac;
        this.Specialty = spec;
    }

    // METHODS

    public override bool Equals(Object s)
    {
        var rhs = s as Student;

        if (s == null) // if s cannot be casted to student, they're clearly not equal
            return false;

        // field check

        return this.FirstName == rhs.FirstName &&
               this.MiddleName == rhs.MiddleName &&
               this.LastName == rhs.LastName &&
               this.Adress == rhs.Adress &&
               this.Course == rhs.Course &&
               this.Email == rhs.Email &&
               this.Faculty == rhs.Faculty &&
               this.Phone == rhs.Phone &&
               this.SSN == rhs.SSN &&
               this.University == rhs.University &&
               this.Specialty == rhs.Specialty;
    }

    public static bool operator ==(Student lhs, Student rhs)
    {
        return ReferenceEquals(lhs, rhs) || lhs.Equals(rhs); // return true if the fields or the references are equal
    }

    public static bool operator !=(Student lhs, Student rhs)
    {
        return !(lhs == rhs);
    }

    public override string ToString()
    {
        return string.Format("Student {0} {1} {2}", WholeName, SSN, University);
    }

    public override int GetHashCode()
    {
        // using prime numbers to multiply

        int hash = 29;
        int hashMultiplier = 11;

        // overflow is ok for hashing

        unchecked 
        {
            // use multyplying and the fields' own hashcode to generate a unique code for the student

            hash = hash * hashMultiplier + string.Format("{0} {1} {2}", FirstName, MiddleName, LastName).GetHashCode();
            hash = hash * hashMultiplier + Adress.GetHashCode();
            hash = hash * hashMultiplier + Course.GetHashCode();
            hash = hash * hashMultiplier + Email.GetHashCode();
            hash = hash * hashMultiplier + Faculty.GetHashCode();
            hash = hash * hashMultiplier + Phone.GetHashCode();
            hash = hash * hashMultiplier + SSN.GetHashCode();
            hash = hash * hashMultiplier + University.GetHashCode();
            hash = hash * hashMultiplier + Specialty.GetHashCode();
        }
        
        return hash;

    }

    public object Clone()
    {
        // serialization provides deep copies

        // open stream, declare a formatter
        var stream = new MemoryStream();
        var formatter = new BinaryFormatter();

        formatter.Serialize(stream, this); // serialize using the stream

        stream.Position = 0;
        Object cloned = formatter.Deserialize(stream); // deserialize into a new object
        stream.Close(); // close stream

        return cloned;
        
    }

    public int CompareTo(Student other)
    {
        int comparison = this.WholeName.CompareTo(other.WholeName);

        if (comparison == 0)
            return this.SSN.CompareTo(other.SSN);

        return comparison;
    }
}