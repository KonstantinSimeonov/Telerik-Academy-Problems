using System;

class Test
{
    static void Main()
    {
        // just some sample tests

        GSM tel = new GSM("Nokia", "gosho tupoto", owner: "Pesho");
        tel.AddCall("0885032502", new DateTime(2003, 2, 1), new TimeSpan(0, 10, 15));
        tel.AddCall("0883456782", new DateTime(2003, 2, 1), new TimeSpan(0, 20, 15));
        tel.AddCall("+359885032548", new DateTime(2003, 2, 1), new TimeSpan(0, 10, 15));
        tel.AddCall("+359885032576", new DateTime(2003, 2, 1), new TimeSpan(0, 15, 15));
        Console.WriteLine(tel.GetCost(0.37));
        tel.RemoveCall();
        tel.PrintHistory();
        Console.WriteLine(tel.GetCost(0.37));
        tel.ClearHistory();
        tel.PrintHistory();
        Console.WriteLine(tel + "\n\n\n");

        // IPhone test

        Console.WriteLine(GSM.IPhone4S);

    }
}

