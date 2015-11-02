#Complexity homework

##Problem 1.

```csharp
long Compute(int[] arr)
{
    long count = 0;
    for (int i=0; i<arr.Length; i++)
    {
        int start = 0, end = arr.Length-1;
        while (start < end)
            if (arr[start] < arr[end])
                { start++; count++; }
            else 
                end--;
    }
    return count;
}
```
###Answer:
 + the complexity of the code is O(n^2)


##Problem 2.

```csharp
long CalcCount(int[,] matrix)
{
    long count = 0;
    for (int row=0; row<matrix.GetLength(0); row++)
        if (matrix[row, 0] % 2 == 0)
            for (int col=0; col<matrix.GetLength(1); col++)
                if (matrix[row,col] > 0)
                    count++;
    return count;
}
```
###Answer:
 + the upper limit for running is n^2
+ *Explanations*: we can't assume that every first element in a row is divisible by 2, so we assume worst case.
 
 
 ##Problem 3.

```csharp
long CalcSum(int[,] matrix, int row)
{
    long sum = 0;
    for (int col = 0; col < matrix.GetLength(0); col++) 
        sum += matrix[row, col];
    if (row + 1 < matrix.GetLength(1)) 
        sum += CalcSum(matrix, row + 1);
    return sum;
}

Console.WriteLine(CalcSum(matrix, 0));
```
###Answer:
 + така написано, при различни редове и колони: докато не метне exception
 + ако във for loop-a се извиква GetLength(1), а в if-a GetLength(0), сложността е (n - row) * m
+ *Explanation*: защото CalcSum ще бъде извикана n - row пъти и всяко извикване ще завърти m брой цикли