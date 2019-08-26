namespace ArmyOfCreatures.Extended
{
    using Logic;
    using Extended.Creatures;

    class ExtendedCreaturesFactory : CreaturesFactory
    {
        #region Constants
        private const string ANCIENT_BEHEMOTH = "AncientBehemoth";
        private const string CYCLOPS_KING = "CyclopsKing";
        private const string GOBLIN = "Goblin";
        private const string GRIFFIN = "Griffin";
        private const string WOLF_RAIDER = "WolfRaider";
        #endregion

        public override Logic.Creatures.Creature CreateCreature(string name)
        {
            switch (name)
            {
                case ExtendedCreaturesFactory.ANCIENT_BEHEMOTH:
                    return new AncientBehemoth();
                case ExtendedCreaturesFactory.CYCLOPS_KING:
                    return new CyclopsKing();
                case ExtendedCreaturesFactory.GOBLIN:
                    return new Goblin();
                case ExtendedCreaturesFactory.GRIFFIN:
                    return new Griffin();
                case ExtendedCreaturesFactory.WOLF_RAIDER:
                    return new WolfRaider();
                default: return base.CreateCreature(name);
            }
            
        }
    }
}
