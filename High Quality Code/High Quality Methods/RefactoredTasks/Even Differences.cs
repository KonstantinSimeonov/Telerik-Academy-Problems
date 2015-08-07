namespace RefactoredTasks
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Numerics;

    public class EvenDifferences
    {
        private const char SEPARATOR = ' ';
        private const int STARTING_POSITION = 1;
        private const int EVEN_UPDATE = 2;
        private const int ODD_UPDATE = 1;

        public static void Run()
        {
            var numbersAsString = Console.ReadLine();
            var numbers = numbersAsString.Split(SEPARATOR).Select(long.Parse).ToArray();

            var currentPosition = STARTING_POSITION;
            long sum = 0;

            while (currentPosition < numbers.Length)
            {
                var currentSum = Math.Abs(numbers[currentPosition - 1] - numbers[currentPosition]);

                if (currentSum % 2 == 0)
                {
                    sum += currentSum;
                    currentPosition += EVEN_UPDATE;
                }
                else
                {
                    currentPosition += ODD_UPDATE;
                }
            }

            Console.WriteLine(sum);
        }
    }
}