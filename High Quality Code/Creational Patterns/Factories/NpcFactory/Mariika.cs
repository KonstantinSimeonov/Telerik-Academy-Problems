namespace Factories.NpcFactory
{
    using System;
    using Factories.Contracts;

    public class Mariika : INpc
    {
        public string Name { get; private set; }

        public Mariika()
        {
            this.Name = "Mariika";
        }
    }
}