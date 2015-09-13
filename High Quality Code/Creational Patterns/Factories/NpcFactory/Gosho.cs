namespace Factories.NpcFactory
{
    using System;
    using Factories.Contracts;

    public class Gosho : INpc
    {
        public string Name { get; private set; }

        public Gosho()
        {
            this.Name = "Gosho";
        }
    }
}
