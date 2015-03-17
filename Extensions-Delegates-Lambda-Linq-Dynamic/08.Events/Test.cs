using System;

class Test
{
    public static void Main()
    {
        var publisher = new Publisher();

        new Subscriber(publisher).HandleCustomEvent(publisher, new CustomEvent("I am a very meaningless event"));
    }
}