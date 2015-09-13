namespace Factories.NpcFactory
{
    using System;
    using Factories.Contracts;

    public class NpcFactory : INpcFactory
    {
        public INpc Create(string name)
        {
            INpc npc;

            switch (name)
            {
                case "Gosho":
                    npc = new Gosho();
                    break;
                case "Mariika":
                    npc = new Mariika();
                    break;
                default:
                    throw new ArgumentException("Cannot create any npc beside Gosho or Mariika");
            }

            return npc;
        }
    }
}
