using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class CalculationProblem
{
    private const int NUMERAL_SYSTEM = 23;

    private static long Power(long baseNumber, int power)
    {
        long product = 1;

        for (int i = 0; i < power; i++)
        {
            product *= baseNumber;
        }

        return product;
    }

    private static long StringToDecimal(string str)
    {
        long sum = 0;

        for (int i = 0; i < str.Length; i++)
        {
            sum += ((str[str.Length - 1 - i]) - 97) * Power(NUMERAL_SYSTEM, i);
        }

        return sum;
    }

    private static string DecimalToBaseN(uint decimalNumber, uint toBase)
    {
        if (decimalNumber == 0)
        {
            return "0";
        }

        var binary = new StringBuilder();

        for (uint i = decimalNumber; i > 0; i /= toBase)
        {
            binary.Insert(0, (char)(i % toBase + 97));
        }

        return binary.ToString();
    }

    public static void Run()
    {
        var input = Console.ReadLine().Split(' ');

        long sum = 0;

        for (int i = 0; i < input.Length; i++)
        {
            sum += StringToDecimal(input[i]);
        }

        var result = string.Format("{0} = {1}", DecimalToBaseN((uint)sum, NUMERAL_SYSTEM), sum);

        Console.WriteLine(result);
    }
}

