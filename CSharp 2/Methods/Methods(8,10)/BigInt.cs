using System;

//Problem 8. Number as array

//Write a method that adds two positive integer numbers represented
//as arrays of digits (each array element arr[i] contains a digit; the last digit is kept in arr[0]).
//Each of the numbers that will be added could have up to 10 000 digits.

class BigInt
{
    byte[] number;
    int size;

    private bool isZero()
    {
        return size == 1 && number[0] == 0;
    }

    public BigInt(ulong l)
    {
        number = new byte[10000];
        size = 1;

        for (int i = 0; l != 0; i++)
        {
            number[i] = (byte)(l % 10);
            l /= 10;
            size++;
        }
    }

    public BigInt(BigInt bi)
    {
        this.size = bi.size;
        this.number = (byte[])bi.number.Clone();
    }

    public int this[int i]
    {
        get
        {
            return number[i];
        }
    }


    public BigInt()
    {
        number = new byte[10000];
        size = 1;
    }

    public void Print()
    {
        for (int i = size - 2; i >= 0; i--)
        {
            Console.Write(number[i]);
        }
        Console.WriteLine();
    }

    public static BigInt operator +(BigInt lhs, BigInt rhs)
    {
        int newSize = lhs.size > rhs.size ? lhs.size : rhs.size;
        BigInt sum = new BigInt();
        sum.size = newSize;
        for (int i = 0; i < newSize; i++)
        {
            sum.number[i] += (byte)(lhs[i] + rhs[i]);
            if (sum.number[i] > 9)
            {
                sum.number[i + 1]++;
                sum.number[i] %= 10;
                if (i == newSize - 2)
                {
                    sum.size++;
                    newSize++;
                }
            }
        }

        return sum;
    }

    //public static bool operator ==(BigInt lhs, BigInt rhs)
    //{
    //    if (lhs.size == rhs.size)
    //    {
    //        for (int i = 0; i < lhs.size; i++)
    //        {
    //            if (rhs[i] != lhs[i])
    //                return false;
    //        }
    //        return true;
    //    }
    //    else
    //        return false;
    //}

    //public static bool operator !=(BigInt lhs, BigInt rhs)
    //{
    //    return !(lhs == rhs);
    //}

    static void Main()
    {
        BigInt bi = new BigInt(99999997);
        BigInt rhs = new BigInt(8);
        (bi + rhs).Print();
        
    }
}

