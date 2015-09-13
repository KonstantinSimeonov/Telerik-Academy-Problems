namespace Factories.Demo
{
    using System;
    using System.Collections.Generic;

    using Factories.AbstractFactory;
    using Factories.Contracts;

    public class Program
    {
        public static void Main()
        {
            // use one object as a creation point for all object types
            var abstractFactory = new AbstractFactory();

            IList<ICharacter> characters = new List<ICharacter>() { 
                                                                    abstractFactory.CreateCharacter("Mage"),
                                                                    abstractFactory.CreateCharacter("Warrior"),
                                                                    abstractFactory.CreateCharacter("Thief")
                                                                    };
            foreach (var character in characters)
            {
                character.UseSpecialAbility();
            }

            var sheep = abstractFactory.CreateCritter("Sheep");
            var squirrel = abstractFactory.CreateCritter("Squirrel");

            Console.WriteLine(sheep.Type);
            Console.WriteLine(squirrel.Type);

            var gosho = abstractFactory.CreateNpc("Gosho");
            var mariika = abstractFactory.CreateNpc("Mariika");

            Console.WriteLine(gosho.Name);
            Console.WriteLine(mariika.Name);
        }
    }
}
