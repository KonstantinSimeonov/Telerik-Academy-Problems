using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class Test
{
    static void Main()
    {
        var bits = new BitArray64(1234);
        Console.WriteLine(bits.DecimalValue);

        foreach (var item in bits)
        {
            Console.Write(item);
        }

        var bits2 = new BitArray64(1024 * 1024 * 1024);
        Console.WriteLine(bits2);
        Console.WriteLine(bits2.DecimalValue);
    }
}