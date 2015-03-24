using System;
using System.Collections.Generic;
using System.Linq;



public class GSM
{
    // FIELDS

    private string model;
    private string manufacturer;
    private string owner;
    private decimal? price;

    // PROPERTIES

    // the checks for those two are made in their respective classes
    public Battery gsmBattery { get; private set; }
    public Display gsmDisplay { get; private set; }
    public IList<Call> callHistory { get; private set; }

    public string Model
    {
        get
        {
            return model;
        }

        private set
        {
            if (string.IsNullOrEmpty(value))
            {
                if (value == string.Empty)
                {
                    throw new ArgumentException("Model name cannot be empty!");
                }
                else
                {
                    throw new ArgumentNullException("Model name cannot be null!");
                }
            }
            else
            {
                model = value;
            }
        }
    }

    public string Manufacturer
    {
        get
        {
            return manufacturer;
        }

        private set
        {
            if (string.IsNullOrEmpty(value))
            {
                if (value == string.Empty)
                {
                    throw new ArgumentException("Manufacturer name cannot be empty!");
                }
                else
                {
                    throw new ArgumentNullException("Manufacturer name cannot be null!");
                }
            }
            else
            {
                manufacturer = value;
            }
        }
    }

    public decimal? Price 
    {
        get
        {
            return price;
        }

        private set
        {
            try
            {
                price = value;
            }
            catch (ArgumentException e)
            {
                Console.WriteLine("Invalid argument provided for price!");
            }
        }
    }

    public string Owner 
    {
        get
        {
            return owner;
        }

        private set
        {
            if (value == string.Empty)
            {
                throw new ArgumentException("Owner name cannot be empty!");
            }
            else
            {
                owner = value;
            }
        }
    }

    public static GSM IPhone4S
    {
        get
        {
            return new GSM("IPhone4S", "Apple");
        }
    }

    // CONSTRUCTORS

    /// <summary>
    /// Constructor for the class to initialize the mandatory fields.
    /// </summary>
    /// <param name="model"></param>
    /// <param name="manufacturer"></param>
    public GSM(string model, string manufacturer)
    {
        this.Model = model;
        this.Manufacturer = manufacturer;
        this.callHistory = new List<Call>();
    }

    /// <summary>
    /// Initializes a new instance of the GSM class with the given parameters. Model and manufacturer are mandatory.
    /// </summary>
    /// <param name="model"></param>
    /// <param name="manufacturer"></param>
    /// <param name="owner"></param>
    /// <param name="price"></param>
    /// <param name="battery"></param>
    /// <param name="display"></param>
    public GSM(string model, string manufacturer, string owner = null, decimal? price = null, Battery battery = null, Display display = null)
        : this(model, manufacturer) // call the first constructor, did it just to try the syntaxix
    {
        this.gsmBattery = battery;
        this.gsmDisplay = display;
        this.Price = price;
        this.Owner = owner;
    }

    // METHODS

    /// <summary>
    /// Adds a call to the call history.
    /// </summary>
    /// <param name="numberCalled"></param>
    /// <param name="started"></param>
    /// <param name="duration"></param>
    public void AddCall(string numberCalled, DateTime started, TimeSpan duration)
    {
        callHistory.Add(new Call(numberCalled, started, duration));
        Console.WriteLine("{0} added to history.", callHistory[callHistory.Count - 1]);
    }

    /// <summary>
    /// Returns a new database that supports operation on a list and contains all calls to a given number.
    /// </summary>
    /// <param name="number"></param>
    /// <returns></returns>
    private IList<Call> GetCallsTo(string number)
    {
        return callHistory.Where(x => x.dialledNumber == number).ToList(); // get all calls to the number
    }

    /// <summary>
    /// Removes a call selected from the user for the history.
    /// </summary>
    public void RemoveCall()
    {
        PrintHistory();

        Console.WriteLine("\nEnter the number of the call you want to remove");

        int toRemove = int.Parse(Console.ReadLine()) - 1;

        if (toRemove < callHistory.Count && toRemove >= 0)
        {
            callHistory.RemoveAt(toRemove);
            Console.WriteLine("The call was removed from the call history.");
        }
        else
        {
            Console.WriteLine("You entered an invalid position");
        }

    }


    /// <summary>
    /// Erases the history.
    /// </summary>
    public void ClearHistory()
    {
        Console.WriteLine("Do you really want to erase the call history? Yes/No");
        if (Console.ReadLine() == "Yes")
        {
            callHistory.Clear();
            Console.WriteLine("History erased.");
        }
        else
        {
            return;
        }
    }


    /// <summary>
    /// Prints the call history of the current instance of the gsm.
    /// </summary>
    public void PrintHistory()
    {
        if (callHistory.Count == 0)
        {
            Console.WriteLine("Call history is empty");
            return;
        }

        int indexer = 1;

        foreach (var item in callHistory)
        {
            Console.WriteLine(indexer++ + "." + item);
        }
    }

    /// <summary>
    /// Calculates the cost of the calls in the history with the given price.
    /// </summary>
    /// <param name="pricePerMinute"></param>
    /// <returns></returns>
    public double GetCost(double pricePerMinute)
    {
        double cost = 0;

        foreach (var item in callHistory)
        {
            cost += pricePerMinute * item.duration.Minutes;
        }

        return cost;

    }


    /// <summary>
    /// Overload of the ToString() method inherited from the Object class.
    /// </summary>
    /// <returns></returns>
    public override string ToString()
    {
        return string.Format("Model: {0}\nManufacturer: {1}\nBattery: {2}\nDisplay: {3}\nPrice: {4}\nOwner: {5}",
            Model, Manufacturer, gsmBattery == null ? "No info" : gsmBattery.ToString(), gsmDisplay == null ? "No info" : gsmDisplay.ToString(), Price == null ? "No info" : Price.ToString(), Owner == null ? "No info" : Owner);
    }
}

