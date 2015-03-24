using System;

//Problem 20.* Infinite convergent series

//By using delegates develop an universal static method to calculate
//the sum of infinite convergent series with given precision depending 
//on a function of its term. By using proper functions for the term calculate with a 2-digit precision the sum of the infinite series:

//1 + 1/2 + 1/4 + 1/8 + 1/16 + …
//1 + 1/2! + 1/3! + 1/4! + 1/5! + …
//1 + 1/2 - 1/4 + 1/8 - 1/16 + …

static class SeriesCalc
{
    // DELEGATES

    public delegate decimal DenominatorFormula(ulong n); // will hold the formula for the n-th member of the series
    public delegate decimal CalculateError(decimal partialSum); // will hold the formula for the error of the n-th partial sum of the series

    // METHODS

    // take a formula for the next member of the series, a formula for the error and a value for the precision
    public static decimal Calculate(DenominatorFormula formula, CalculateError error, decimal prescision = (decimal)0.001)
    {
        ulong n = 0; // start from the zero member
        decimal sum = 0;

        while (error(sum) > prescision) // while the error is greater than we want it to be
        {
            sum += formula(n++); // add the next member according to the formula we passes to it

            // uncomment to see the calculation process
            // Console.WriteLine(sum);
        }
        
        return sum;
    }
}