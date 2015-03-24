namespace BankCustomers
{
    
    public abstract class Customer
    {
        // PROPERTIES

        public string Name { get; private set; }

        // CONSTRUCTORS

        public Customer(string name)
        {
            this.Name = name;
        }

        // METHODS

        public override string ToString()
        {
            return Name;
        }

    }

    public class IndividualCustomer : Customer
    {
        // CONSTRUCTORS

        public IndividualCustomer(string name)
            : base(name)
        { }

        // METHODS

        public override string ToString()
        {
            return base.ToString() + " - individual customer";
        }
    }

    public class Company : Customer
    {
        // CONSTRUCTORS

        public Company(string name)
            : base(name)
        { }

        // METHODS

        public override string ToString()
        {
            return base.ToString() + " - company";
        }
    }
}
