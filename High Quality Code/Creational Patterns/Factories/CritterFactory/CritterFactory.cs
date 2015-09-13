namespace Factories.CritterFactory
{
    using System;

    using Factories.Contracts;

    public class CritterFactory : ICritterFactory
    {
        public ICritter Create(string type)
        {
            ICritter critter;

            switch (type)
            {
                case "Sheep":
                    critter = new Sheep();
                    break;
                case "Squirrel":
                    critter = new Squirrel();
                    break;
                default:
                    throw new ArgumentException("No such type of critter exists.");
            }

            return critter;
        }
    }
}