using System;

public class Display
{
    // FIELDS

    private double? screenSize;
    private int? numberOfColours;

    // PROPERTIES

    public double? ScreenSize 
    {
        get
        {
            return screenSize;
        }
        private set
        {
            try
            {
                screenSize = value;
            }
            catch (ArgumentException e)
            {
                Console.WriteLine("Invalid argument provided for the screen size");
            }
        }
    }

    public int? NumberOfColours
    {
        get
        {
            return numberOfColours;
        }
        private set
        {
            try
            {
                numberOfColours = value;
            }
            catch (ArgumentException e)
            {
                Console.WriteLine("Invalid argument provided for number of colours");
            }
        }
    }

    /// <summary>
    /// Initializes an instance of the Display class with size and number of colours.
    /// </summary>
    /// <param name="size"></param>
    /// <param name="colourNum"></param>
    public Display(double? size = null, int? colourNum = null)
    {
        this.ScreenSize = size;
        this.NumberOfColours = colourNum;
    }

    public override string ToString()
    {
        return string.Format("size: {0}, number of colours: {1}", ScreenSize, NumberOfColours);
    }
}