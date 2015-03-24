using System.Text;
using System.Linq;
using System.Collections.Generic;

class Student
{
    // PROPERTIES

    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    public string FN { get; private set; }
    public string Tel { get; private set; }
    public string Email { get; private set; }
    public List<byte> Marks { get; private set; }
    public byte GroupNumber { get; private set; }
    public int Age { get; private set; }

    // CONSTRUCTORS

    public Student(string firstName, string lastName, int age, string FN, string Tel, byte group, string email = "")
    {
        this.FirstName = firstName;
        this.LastName = lastName;
        this.Age = age;
        this.FN = FN;
        this.Tel = Tel;
        this.Email = email;
        this.Marks = new List<byte>();
        this.GroupNumber = group;
    }

    // METHODS

    public static Student[] FirstBeforeLast(Student[] students)
    {
        return students.Where(x => x.FirstName.CompareTo(x.LastName) < 0).ToArray();
    }

    public static Student[] AgeRange(Student[] students, int low, int high)
    {
        return students.Where(x => x.Age > low && x.Age < high).ToArray();
    }

    public void SetEmail(string newMail)
    {
        Email = newMail;
    }

    public void AddMark(byte mark)
    {
        Marks.Add(mark);
    }

    public override string ToString()
    {
        return string.Format("{0} {1} Age:{2} Faculty number:{3} Tel:{4} Mail:{5} Marks:{6} Group:{7}", FirstName, LastName, Age, FN, Tel, Email, string.Join(",", Marks), GroupNumber);
    }

}