namespace Factories.CritterFactory
{
    using System;

    using Factories.Contracts;

    public class Sheep : ICritter
    {
        public string Type { get; private set; }

        public Sheep()
        {
            this.Type = "Sheep";
        }
    }
}