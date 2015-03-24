using System.Diagnostics;

//Problem 7. Timer

//Using delegates write a class Timer that can execute certain method at each t seconds.

class Timer
{
    // DELEGATES

    public delegate void SomeAction(); // hold the action

    // PROPERTIES

    public SomeAction action { get; set; }
    public int IntervalSeconds { get; set; }

    // CONSTRUCTORS

    public Timer(int seconds, SomeAction action)
    {
        IntervalSeconds = seconds;
        this.action = action;
    }

    // METHODS

    public void Execute(uint timeInSeconds)
    {
        var watch = new Stopwatch();
        watch.Start();

        while (watch.ElapsedMilliseconds < timeInSeconds * 1000)
        {
            if (watch.ElapsedMilliseconds % 1000 == IntervalSeconds)
                action();
        }

        watch.Stop();
    }
}