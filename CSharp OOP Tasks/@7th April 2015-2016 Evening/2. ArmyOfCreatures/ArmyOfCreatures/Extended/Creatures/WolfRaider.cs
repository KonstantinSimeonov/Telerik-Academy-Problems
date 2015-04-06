namespace ArmyOfCreatures.Extended.Creatures
{
    using Extended.Specialties;
    using Logic.Creatures;

    class WolfRaider : Creature
    {
        #region Constants
        private const int ATTACK = 8;
        private const int DEFENSE = 5;
        private const int HEALTH_POINTS = 10;
        private const decimal DAMAGE = 3.5M;
        private const int DOUBLE_DAMAGE_ROUNDS = 7;
        #endregion

        public WolfRaider()
            : base(WolfRaider.ATTACK, WolfRaider.DEFENSE, WolfRaider.HEALTH_POINTS, WolfRaider.DAMAGE)
        {
            this.AddSpecialty(new DoubleDamage(WolfRaider.DOUBLE_DAMAGE_ROUNDS));
        }

    }
}
