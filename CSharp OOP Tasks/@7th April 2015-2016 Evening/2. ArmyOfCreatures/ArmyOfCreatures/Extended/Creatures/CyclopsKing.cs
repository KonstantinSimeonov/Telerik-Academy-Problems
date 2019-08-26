namespace ArmyOfCreatures.Extended.Creatures
{
    using Extended.Specialties;
    using Logic.Creatures;

    class CyclopsKing : Creature
    {
        #region Constants
        private const int ATTACK = 17;
        private const int DEFENSE = 13;
        private const int HEALTH_POINTS = 70;
        private const decimal DAMAGE = 18M;
        private const int ADD_ATTACK_WHEN_SKIP = 3;
        private const int DOUBLE_ATTACK_ROUNDS = 4;
        private const int DOUBLE_DAMAGE_ROUNDS = 1;
        #endregion

        public CyclopsKing()
            : base(CyclopsKing.ATTACK, CyclopsKing.DEFENSE, CyclopsKing.HEALTH_POINTS, CyclopsKing.DAMAGE)
        {
            this.AddSpecialty(new AddAttackWhenSkip(CyclopsKing.ADD_ATTACK_WHEN_SKIP));
            this.AddSpecialty(new DoubleAttackWhenAttacking(CyclopsKing.DOUBLE_ATTACK_ROUNDS));
            this.AddSpecialty(new DoubleDamage(CyclopsKing.DOUBLE_DAMAGE_ROUNDS));
        }

    }
}
