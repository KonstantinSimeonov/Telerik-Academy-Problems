using System;
using System.Collections.Generic;
using System.Linq;
using BankAccounts;
using BankCustomers;

public class Bank
{
    // FIELDS

    private IList<Account> Accounts;


    // PROPERTIES

    public string Name { get; private set; }
    public IList<Customer> Customers { get; private set; }

    // INDEXERS

    public Account this[string nameOfClient]
    {
        get
        {
                return Accounts.First(acc => acc.Client.Name == nameOfClient);
        }
    }

    // CONSTRUCTORS

    public Bank(string name)
    {
        this.Name = name;
        this.Accounts = new List<Account>();
        this.Customers = new List<Customer>();
    }

    // METHODS

    public void AddAccount(Account acc)
    {
        Accounts.Add(acc);
        Customers.Add(acc.Client);
    }

    public void RemoveAcc(Account acc)
    {
        Accounts.Remove(acc);
        Customers.Remove(acc.Client);
    }

    // suppose that all customers have unique names

    public void DrawFromAcc(string name, decimal money)
    {
        Accounts.First(acc => acc.Client.Name == name).Draw(money);
    }

    public void DepositIn(string name, decimal money)
    {
        Accounts.First(acc => acc.Client.Name == name).Deposit(money);
    }

    public void PrintAccounts()
    {
        foreach (var item in Accounts)
        {
            Console.WriteLine(item);
            Console.WriteLine("\n");
        }
    }
}