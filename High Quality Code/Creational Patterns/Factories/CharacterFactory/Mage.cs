namespace Factories
{
    using System;

    using Factories.Contracts;

    public class Mage : ICharacter
    {
        public Mage()
        {
        }

        public void UseSpecialAbility()
        {
            Console.WriteLine("Focus-pocus");
        }
    }
}
