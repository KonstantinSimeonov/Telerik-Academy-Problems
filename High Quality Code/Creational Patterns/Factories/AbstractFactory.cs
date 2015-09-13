namespace Factories.AbstractFactory
{
    using Factories.Contracts;
    using Factories.CritterFactory;
    using Factories.NpcFactory;
    using Factories;

    public class AbstractFactory
    {
        private INpcFactory npcs;
        private ICritterFactory critters;
        private ICharacterFactory characters;

        public AbstractFactory(INpcFactory npcFactory, ICritterFactory critterFactory, ICharacterFactory characterFactory)
        {
            this.npcs = npcFactory;
            this.critters = critterFactory;
            this.characters = characterFactory;
        }

        // default dependancies
        public AbstractFactory()
        {
            this.npcs = new NpcFactory();
            this.critters = new CritterFactory();
            this.characters = new AdventurerFactory();
        }

        public INpc CreateNpc(string name)
        {
            return npcs.Create(name);
        }

        public ICritter CreateCritter(string type)
        {
            return critters.Create(type);
        }

        public ICharacter CreateCharacter(string type)
        {
            return characters.CreateCharacter(type);
        }
    }
}
