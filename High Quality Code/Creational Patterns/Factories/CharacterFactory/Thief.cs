namespace Factories
{
    using System;
    using Factories.Contracts;

    public class Thief : ICharacter
    {

        public Thief()
        {
        }

        public void UseSpecialAbility()
        {
            Console.WriteLine("I lie, i cheat, i steal ^_-");
        }

    }
}