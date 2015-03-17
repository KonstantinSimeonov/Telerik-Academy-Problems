using System.Threading;

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

    public void Execute(uint times)
    {
        for (int i = 0; i < times; i++) // execute exactly the passes amount of times
        {
            action(); // call the action
            Thread.Sleep(IntervalSeconds * 1000); // pause
        }
    }
}