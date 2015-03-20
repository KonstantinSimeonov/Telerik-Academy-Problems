using System;

class Worker : Human
{
    // PROPERTIES

    public uint Salary { get; private set; }
    public byte WorkHoursPerDay { get; private set; }

    // CONSTRUCTORS

    public Worker(string fname, string lname, uint salary, byte hours)
        : base(fname, lname)
    {
        this.Salary = salary;
        this.WorkHoursPerDay = hours;
    }

    // METHODS

    public double MoneyPerHour()
    {
        return Salary / (WorkHoursPerDay*30.5);
    }

    public override string ToString()
    {
        return "Worker "+base.ToString()+string.Format(" | Salary: {0} | Money per hour:{1:0.00}", Salary, MoneyPerHour());
    }
}

