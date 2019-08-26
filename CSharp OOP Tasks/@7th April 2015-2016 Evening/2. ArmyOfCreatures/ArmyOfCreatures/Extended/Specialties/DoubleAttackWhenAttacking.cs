namespace ArmyOfCreatures.Extended.Specialties
{
    using System;
    using Logic.Battles;
    using Logic.Specialties;

    class DoubleAttackWhenAttacking : Specialty
    {
        #region Constants
        private const int MINIMAL_ROUNDS = 0;
        #endregion

        private int roundsLeft;

        public DoubleAttackWhenAttacking(int rounds)
        {
            if (rounds <= DoubleAttackWhenAttacking.MINIMAL_ROUNDS)
            {
                throw new ArgumentOutOfRangeException("Rounds for the DoubleAttackWhenAttacking must be a positive value!");
            }

            this.roundsLeft = rounds;
        }

        public override void ApplyWhenAttacking(ICreaturesInBattle attackerWithSpecialty, ICreaturesInBattle defender)
        {
            if (this.roundsLeft > 0)
            {
                attackerWithSpecialty.CurrentAttack *= 2;
                this.roundsLeft--;
            }

        }

        public override string ToString()
        {
            return string.Format("{0}({1})", base.ToString(), this.roundsLeft);
        }
    }
}
