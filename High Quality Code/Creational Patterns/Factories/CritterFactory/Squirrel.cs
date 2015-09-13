namespace Factories.CritterFactory
{
    using System;

    using Factories.Contracts;

    public class Squirrel : ICritter
    {
        public string Type { get; private set; }

        public Squirrel()
        {
            this.Type = "Squirrel";
        }
    }
}