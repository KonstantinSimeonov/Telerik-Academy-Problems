namespace BankAccounts
{
    using System;
    using BankCustomers;

    public interface IAccount
    {
        decimal CalculateInterest();
        void Deposit(decimal money);
        void Draw(decimal money);
    }

    public abstract class Account : IAccount
    {
        // PROPERTIES

        public Customer Client { get; protected set; }
        public int Months { get; protected set; }
        public decimal Balance { get; protected set; }


        // CONSTRUCTORS

        public Account(Customer client, decimal money, int months)
        {
            this.Client = client;
            this.Balance = money;
            this.Months = months;
        }

        // METHODS

        public virtual void Deposit(decimal money)
        {
            if (money > 0)
            {
                Balance += money;
                Console.WriteLine("{0}'s account. Deposit successful. Current balance:{1}", Client.Name, Balance);
            }
            else
            {
                throw new ArgumentException("{0}'s account. Cannot deposit a negative amount of money!", Client.Name);
            }
        }

        public virtual void Draw(decimal money)
        {
            Console.WriteLine("{0}'s account. Cannot draw from this type of account!", Client.Name);
        }

        public abstract decimal CalculateInterest();

        public override string ToString()
        {
            return string.Format("account owner:{0}\nBalance:{1}\nInterest:{2}", Client, Balance, CalculateInterest());
        }
    }

    public class Deposit : Account
    {
        // PROPERTIES

        public static decimal InterestRate { get; private set; }

        // CONSTRUCTORS

        public Deposit(Customer client, decimal money, int months = 0)
            : base(client, money, months)
        {
            InterestRate++;
        }

        // METHODS

        public override decimal CalculateInterest()
        {
            return (Balance >= 0 && Balance < 1000) ? 0 : Months * InterestRate / 100;
        }

        public override void Draw(decimal money)
        {
            if (Balance - money >= 0)
            {
                Balance -= money;
                Console.WriteLine("{0}'s account. Draw successful. Current balance:{1}",Client.Name, Balance);
            }
            else
            {
                Console.WriteLine("{0}'s account. Not enough money for such a transaction.", Client.Name);
            }
        }

        public override string ToString()
        {
            return string.Format("Account type: deposit {0}",base.ToString());
        }
    }

    public class Loan : Account
    {
        // PROPERTIES

        public static decimal InterestRate { get; private set; }

        // CONSTRUCTORS

        public Loan(Customer client, decimal money, int months = 0)
            : base(client, money, months)
        {
            InterestRate++;
        }

        // METHODS

        public override decimal CalculateInterest()
        {
            return ((Client is IndividualCustomer && Months < 3) || (Client is Company && Months < 2)) ? 0 : Months * InterestRate / 100;
        }

        public override string ToString()
        {
            return string.Format("Account type: loan {0}", base.ToString());
        }

    }

    public class Mortgage : Account
    {
        // PROPERTIES

        public static decimal InterestRate { get; private set; }

        // CONSTRUCTORS

        public Mortgage(Customer client, decimal money, int months = 0)
            : base(client, money, months)
        {
            InterestRate++;
        }

        // METHODS

        public override decimal CalculateInterest()
        {
            if (Client is Company && Months <= 12)
            {
                return (decimal)1.5 * Months;
            }
            else if (Client is IndividualCustomer && Months < 6)
            {
                return 0;
            }
            else
            {
                return Months * InterestRate / 100;
            }
        }

        public override string ToString()
        {
            return string.Format("Account type: mortgage {0}", base.ToString());
        }

    }
}