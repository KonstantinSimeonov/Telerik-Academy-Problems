using System;
using BankAccounts;
using BankCustomers;

class Test
{
    public const int numberOfCustomers = 8;

    public static string[] fnames = { 
                                        "Gosho",
                                        "Tosho",
                                        "Pesho",
                                        "Penka",
                                        "Richard",
                                        "Ivan",
                                        "Kircho",
                                        "Latinka",
                                        "Petko",
                                        "Boris",
                                        "Genadii",
                                        "Stamatka",
                                        "Galina",
                                        "Mariika",
                                        "Dimitrichka",
                                        "Neli",
                                        "Todorka",
                                        "Grigor",
                                        "Gigorka",
                                        "Pancho"
                                    };

    public static string[] lnames = { 
                                        "Ivanov",
                                        "Dimitrov",
                                        "Grigorov",
                                        "Penkova",
                                        "Dickson",
                                        "Ivanov",
                                        "Dragoev",
                                        "Nikodimova",
                                        "Simeonov",
                                        "Cvetkov",
                                        "Pachnikov",
                                        "Deleva",
                                        "Vladimirova",
                                        "Dimitrova",
                                        "Shishkova",
                                        "Lukova",
                                        "Stamatova",
                                        "Vlaskovski",
                                        "Piperova",
                                        "Vladigerov"
                                    };

    public static string[] companyNames = {                                        
                                              "Purshevica",
                                              "Dimitrov OOD",
                                              "Grigorov EOD",
                                              "Fantastiko",
                                              "SAP",
                                              "TITAN",
                                              "DITZ",
                                              "Shell",
                                              "LIDL", 
                                          };

    public static Random vladoRandoma = new Random();

    static void Main()
    {
        Bank bank = new Bank("OOP");

        // fill in some random records

        for (int i = 0; i < numberOfCustomers; i++)
        {
            Customer client;
            if(vladoRandoma.Next() % 2 == 0)
            {
                client = new Company(companyNames[vladoRandoma.Next(0, companyNames.Length)]);
            }
            else
            {
                client = new IndividualCustomer(fnames[i]+" "+ lnames[i]);
            }
            switch (vladoRandoma.Next() % 3)
            {
                case 1: bank.AddAccount(new Loan(client, vladoRandoma.Next(100, 10000), vladoRandoma.Next(0, 36))); break;
                case 2: bank.AddAccount(new Mortgage(client, vladoRandoma.Next(100, 10000), vladoRandoma.Next(0, 36))); break;
                case 0: bank.AddAccount(new Deposit(client, vladoRandoma.Next(100, 10000), vladoRandoma.Next(0, 36))); break;
                default:
                    break;
            }

        }


        bank.PrintAccounts();

        foreach (var item in bank.Customers)
        {
            bank[item.Name].Deposit(500);
        }

        foreach (var item in bank.Customers)
        {
            bank[item.Name].Draw(1000);
        }
    }
}