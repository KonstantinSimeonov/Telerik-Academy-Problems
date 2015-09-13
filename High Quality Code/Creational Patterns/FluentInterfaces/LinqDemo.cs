namespace FluentInterfaces
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class LinqDemo
    {
        public static void Run()
        {
            var rng = new Random();

            var names = new string[]{ "Pesho", "Mariya", "Boris", "Mishka", "Domcho", "Gergana"};

            // chaining LINQ methods is a fluent interface

            var nicknames = new string[] { "e pich", "e umen/umna", "ne moje da kodi", "e gad"};

            var peopleWithNicknames = names.Where(name => name.Length % 2 == 0).Select(name => name + " " + nicknames[rng.Next() % nicknames.Length]).ToList();
            
            Console.WriteLine(string.Join(", ", peopleWithNicknames));

            var someDamnLongLinqChain = names.Select(name => name.Length).Concat(new int[] { 5, 6, 7, 8, 9 }).Distinct().Sum();

            Console.WriteLine(someDamnLongLinqChain);
        }
    }
}
