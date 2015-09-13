namespace Factories
{
    using System;

    using Factories.Contracts;

    public class Warrior : ICharacter
    {
        private string battleshout = "SPARTAAA";

        public Warrior()
        {
        }

        public void UseSpecialAbility()
        {
            Console.WriteLine(this.battleshout);
        }
    }
}