using System;

class Test
{
    // series 1/2^n

    public static decimal NextMemberPowerOfTwo(ulong n)
    {
        ulong product = 1;

        for (ulong i = 1; i <= n; i++)
        {
            checked
            {
                product *= 2;
            }
        }

        return ((decimal)1) / product;
    }

    public static decimal Error(decimal partialSum)
    {
        return (decimal)2 - partialSum;
    }

    // series 1/n!

    public static decimal FactorialSeriesNextMember(ulong n)
    {
        ulong product = 1;

        for (ulong i = 1; i <= n + 1; i++)
        {
            checked
            {
                product *= i;
            }
        }

        return ((decimal)1) / product;
    }

    public static decimal FactorialError(decimal partialSum)
    {
        return (decimal)1.71828182845904523536028747135266249 - partialSum;
    }

    // series 1 + ((-1)^(n+1))/2^n

    public static decimal AlternativeSeriesNextMember(ulong n)
    {
        if (n == 0)
            return 1;

        else
        {
            ulong product = 1;

            for (ulong i = 0; i <= n; i++)
            {
                product *= 2;
            }

            return (decimal)(n % 2 == 1 ? 1 : -1) / product;
        }
    }

    public static decimal AlternativeSeriesError(decimal partialSum)
    {
        return Math.Abs((decimal)1.1666666666666666666666666666666666666666666666 - partialSum);
    }

    public static void Main()
    {
        Console.WriteLine("Sum of 1/2^n: {0:0.000}", SeriesCalc.Calculate(NextMemberPowerOfTwo, Error));
        Console.WriteLine("Sum of 1/n!: {0:0.000}", SeriesCalc.Calculate(FactorialSeriesNextMember, FactorialError));
        Console.WriteLine("Sum of 1 + 1/(-2)^(n+1): {0:0.000}", SeriesCalc.Calculate(AlternativeSeriesNextMember, AlternativeSeriesError));
    }
}