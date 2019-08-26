namespace ArmyOfCreatures.Extended.Specialties
{
    using Logic.Battles;
    using Logic.Specialties;

    class AddAttackWhenSkip : Specialty
    {
        #region Constants
        private const int MIN_BONUS = 0;
        private const int MAX_BONUS = 11;
        #endregion

        private readonly int attackBonus;

        public AddAttackWhenSkip(int attackBonus)
        {
            Validator.ValidateRange(attackBonus, AddAttackWhenSkip.MIN_BONUS, AddAttackWhenSkip.MAX_BONUS);
            this.attackBonus = attackBonus;
        }

        public override void ApplyOnSkip(ICreaturesInBattle skipCreature)
        {
            skipCreature.PermanentAttack += this.attackBonus;
        }

        public override string ToString()
        {
            return string.Format("{0}({1})", base.ToString(), this.attackBonus);
        }
    }
}
