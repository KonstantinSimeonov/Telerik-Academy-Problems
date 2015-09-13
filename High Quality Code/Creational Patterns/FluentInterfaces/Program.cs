namespace FluentInterfaces
{
    using System;

    using FluentInterfaces.FlowControl;
    using FluentInterfaces.Cats;

    public class Program
    {
        public static void Main()
        {
            // fluent kittens

            Console.WriteLine("Kittens: ");

            var kitten1 = new Kitten("mishka", "black", "purring", 2);
            var kitten2 = new Kitten()
                              .WithName("mishka")
                              .WithAge(2)
                              .WithColor("black")
                              .WithState("purring");

            Console.WriteLine("kitten 1: " + kitten1);
            Console.WriteLine("kitten 2: " + kitten2);

            // fluent switch

            Console.WriteLine("\nSwitch demo: ");

            // switch arg
            var person = "Gosho";
            // enable/disable fallthrough
            var fallThrough = false;

            new Switch<string>(person, fallThrough)
                .Case("Pesho", () => Console.WriteLine("Pesho e pich"))
                .Case(name => name == "Ivan", () => Console.WriteLine("Ivan e dvoikar"))
                .Case(person.Length == 5, () => Console.WriteLine("Ne go znam koi e, ama imeto mu ima 5 bukvi"))
                .Default(() => Console.WriteLine("default case"));
        }
    }
}
