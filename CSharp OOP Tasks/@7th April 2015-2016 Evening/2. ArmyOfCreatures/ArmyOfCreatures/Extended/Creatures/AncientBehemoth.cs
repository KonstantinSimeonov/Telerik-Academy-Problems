namespace ArmyOfCreatures.Extended.Creatures
{
    using Logic.Creatures;
    using Logic.Specialties;
    class AncientBehemoth : Creature
    {
        #region Constants
        private const int ATTACK = 19;
        private const int DEFENSE = 19;
        private const int HEALTH_POINTS = 300;
        private const decimal DAMAGE = 40M;
        private const int DOUBLE_DEFENSE_FOR_ROUNDS = 5;
        private const decimal REDUCE_DEFENSE_PERCENTAGE = 80M;
        #endregion

        public AncientBehemoth()
            :base(AncientBehemoth.ATTACK, AncientBehemoth.DEFENSE, AncientBehemoth.HEALTH_POINTS, AncientBehemoth.DAMAGE)
        {
            this.AddSpecialty(new ReduceEnemyDefenseByPercentage(AncientBehemoth.REDUCE_DEFENSE_PERCENTAGE));
            this.AddSpecialty(new DoubleDefenseWhenDefending(AncientBehemoth.DOUBLE_DEFENSE_FOR_ROUNDS));
        }

    }
}
