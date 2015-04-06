namespace ArmyOfCreatures.Extended.Creatures
{
    using Logic.Creatures;
    using Logic.Specialties;

    class Griffin : Creature
    {
        #region Constants
        private const int ATTACK = 8;
        private const int DEFENSE = 8;
        private const int HEALTH_POINTS = 25;
        private const decimal DAMAGE = 4.5M;
        private const int DOUBLE_DEFENSE_ROUNDS = 5;
        private const int ADD_DEFENSE_WHEN_SKIP = 3;
        #endregion

        public Griffin()
            : base(Griffin.ATTACK, Griffin.DEFENSE, Griffin.HEALTH_POINTS, Griffin.DAMAGE)
        {
            this.AddSpecialty(new DoubleDefenseWhenDefending(Griffin.DOUBLE_DEFENSE_ROUNDS));
            this.AddSpecialty(new AddDefenseWhenSkip(Griffin.ADD_DEFENSE_WHEN_SKIP));
            this.AddSpecialty(new Hate(typeof(WolfRaider)));
        }

    }
}
