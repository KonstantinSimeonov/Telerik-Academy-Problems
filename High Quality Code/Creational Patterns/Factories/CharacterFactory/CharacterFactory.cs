namespace Factories
{
    using System;

    using Factories.Contracts;

    public class AdventurerFactory : ICharacterFactory
    {
        public AdventurerFactory()
        {
        }

        public ICharacter CreateCharacter(string characterType)
        {
            ICharacter character;

            switch (characterType)
            {
                case "Mage":
                    character = new Mage();
                    break;
                case "Warrior":
                    character = new Warrior();
                    break;
                case "Thief":
                    character = new Thief();
                    break;
                default:
                    throw new ArgumentException("There is no " + characterType + " type of character.");
            }

            return character;
        }
    }
}