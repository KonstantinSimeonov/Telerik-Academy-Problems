namespace WheelOfFortune
{
    using System;
    using System.Collections.Generic;

    public static class RiskWinsRiskLoses
    {
        static bool[] forbidden;
        static int[] powers = new int[] { 10000, 1000, 100, 10, 1 };
        const int MaxUniqueConfigurationsCount = 10000;

        public static void Main()
        {
            var start = Console.ReadLine().QuickParse();
            var end = Console.ReadLine().QuickParse();
            var n = Console.ReadLine().QuickParse();

            forbidden = new bool[MaxUniqueConfigurationsCount];

            for (int i = 0; i < n; i++)
            {
                forbidden[Console.ReadLine().QuickParse()] = true;
            }

            var next = new Queue<int>();
            next.Enqueue(start);
            var level = 0;

            while (next.Count > 0)
            {
                var nextLevel = new Queue<int>();

                // use level bfs to make level counting easy
                while (next.Count > 0)
                {
                    var curr = next.Dequeue();

                    if (curr == end)
                    {
                        Console.WriteLine(level);
                        return;
                    }

                    for (int i = 0; i < 5; i++)
                    {
                        var d = (curr / powers[i]) % 10;

                        // spin the wheel left
                        var nextNode = curr + (d == 9 ? -9 * powers[i] : powers[i]);

                        if(!forbidden[nextNode])
                        {
                            forbidden[nextNode] = true;

                            nextLevel.Enqueue(nextNode);
                        }

                        // spin the wheel right
                        nextNode = curr + (d == 0 ? 9 * powers[i] : -powers[i]);

                        if (!forbidden[nextNode])
                        {
                            forbidden[nextNode] = true;

                            nextLevel.Enqueue(nextNode);
                        }
                    }
                }

                next = nextLevel;
                level++;
            }

            Console.WriteLine(-1);
        }

        // offers >40% boost in comparison to int.Parse
        public static int QuickParse(this string number)
        {
            int result = 0;
            int first = number[0] == '-' ? 1 : 0;

            for (int i = number.Length - 1, multiplier = 1; i >= first; i--, multiplier *= 10)
            {
                result += (number[i] - 48) * multiplier;
            }

            return number[0] == '-' ? -result : result;
        }
    }
}