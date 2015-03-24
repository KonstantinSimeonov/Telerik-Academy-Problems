using System;

/// <summary>
/// Holds the different types of batteries.
/// </summary>
public enum BatteryType { LiIon = 1, NiMH = 2, NiCd = 3, Unknown = 4 }

public class Battery
{
    // FIELDS

    private string model;
    private double? hoursTalk, hoursIdle;

    // PROPERTIES

    public BatteryType Type { get; private set; }

    public string Model
    {
        get
        {
            return model;
        }
        private set
        {
            try
            {
                model = value;
            }
            catch (ArgumentException e)
            {
                Console.WriteLine("Invalid argument provided for battery model");
            }
        }
    }

    public double? HoursTalk
    {
        get
        {
            return hoursTalk;
        }
        private set
        {
            try
            {
                hoursTalk = value;
            }
            catch (ArgumentException e)
            {
                Console.WriteLine("Invalid argument for hours talk of battery.");
            }
        }
    }

    public double? HoursIdle
    {
        get
        {
            return hoursIdle;
        }
        private set
        {

            try
            {
                hoursIdle = value;
            }
            catch (ArgumentException e)
            {
                Console.WriteLine("Invalid argument for hours idle of battery.");
            }
        }
    }


    /// <summary>
    /// Initializes an instance of the Battery class with model, hours talk and idle and type.
    /// </summary>
    /// <param name="model"></param>
    /// <param name="ht"></param>
    /// <param name="hi"></param>
    /// <param name="type"></param>
    public Battery(string model = null, double? ht = null, double? hi = null, BatteryType type = BatteryType.Unknown)
    {
        this.Model = model;
        this.HoursTalk = ht;
        this.HoursIdle = hi;
        this.Type = type;
    }

    public override string ToString()
    {
        return string.Format("type {0}, model {1}, hours talk {2}, hours idle {3}", Type, Model, HoursTalk, HoursIdle);
    }
}