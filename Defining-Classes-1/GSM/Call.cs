using System;

public class Call
{
    // PROPERTIES

    public DateTime started { get; private set; }
    public TimeSpan duration { get; private set; }
    public string dialledNumber { get; private set; }

    // CONSTRUCTORS

    /// <summary>
    /// Initializes an instance of the Call class with a number, a starting date and a duration.
    /// </summary>
    /// <param name="dialled"></param>
    /// <param name="started"></param>
    /// <param name="duration"></param>
    public Call(string dialled, DateTime started, TimeSpan duration)
    {
        this.started = started;
        this.duration = duration;
        dialledNumber = dialled;
    }

    /// <summary>
    /// Start a new call.
    /// </summary>
    /// <param name="dialled"></param>
    public Call(string dialled)
    {
        started = DateTime.Now;
        dialledNumber = dialled;
    }

    /// <summary>
    /// Finished the current call and updates its duration.
    /// </summary>
    public void StopCall()
    {
        duration = started - DateTime.Now;
    }

    /// <summary>
    /// Overload of the ToString() method inherited from System.Object.
    /// </summary>
    /// <returns></returns>
    public override string ToString()
    {
        return string.Format("Dialled number: {0} Dialled on: {1} Duration: {2}", dialledNumber, started, duration);
    }
}

