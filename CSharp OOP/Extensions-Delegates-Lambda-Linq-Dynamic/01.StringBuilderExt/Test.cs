using System;
using System.Text;

class Test
{
    public static void Main()
    {
        var builder = new StringBuilder("im an extended stringbuilder!");

        var subBuilder = builder.Substring(15, builder.Length - 15);

        Console.WriteLine(subBuilder);
    }
}