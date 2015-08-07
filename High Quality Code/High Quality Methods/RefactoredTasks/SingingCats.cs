namespace RefactoredTasks
{
    using System;
    using System.Linq;
    public class SingingCats
    {
        private const int LOW_BOUNDARY = 1;
        private const int HIGH_BOUNDARY = 10;
        private static Random rand = new Random();

        public static void Run()
        {
            Console.WriteLine(rand.Next(LOW_BOUNDARY, HIGH_BOUNDARY));
        }
    }
}
