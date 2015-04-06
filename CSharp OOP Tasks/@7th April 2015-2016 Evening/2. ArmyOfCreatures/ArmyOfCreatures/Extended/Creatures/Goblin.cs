namespace ArmyOfCreatures.Extended.Creatures
{
    using Logic.Creatures;

    class Goblin : Creature
    {
        #region Constants
        private const int ATTACK = 4;
        private const int DEFENSE=2;
        private const int HEALTH_POINTS=5;
        private const decimal DAMAGE = 1.5M;
        #endregion

        public Goblin()
            : base(Goblin.ATTACK, Goblin.DEFENSE, Goblin.HEALTH_POINTS, Goblin.DAMAGE)
        { }
    }
}
