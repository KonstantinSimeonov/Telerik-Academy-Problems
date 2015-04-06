namespace ArmyOfCreatures.Extended.Specialties
{
    using System;
    using Logic.Specialties;
    using Logic.Battles;

    class DoubleDamage : Specialty
    {
        #region Constants
        private const int MIN_ROUNDS = 0;
        private const int MAX_ROUNDS = 11;
        #endregion

        private int roundsLeft;

        public DoubleDamage(int rounds)
        {
            Validator.ValidateRange(rounds, DoubleDamage.MIN_ROUNDS, DoubleDamage.MAX_ROUNDS);
            this.roundsLeft = rounds;
        }

        public override decimal ChangeDamageWhenAttacking(ICreaturesInBattle attackerWithSpecialty, ICreaturesInBattle defender, decimal currentDamage)
        {
            if (attackerWithSpecialty == null)
            {
                throw new ArgumentNullException("attackerWithSpecialty");
            }

            if (defender == null)
            {
                throw new ArgumentNullException("defender");
            }

            if (this.roundsLeft > 0)
            {
                this.roundsLeft--;
                return base.ChangeDamageWhenAttacking(attackerWithSpecialty, defender, currentDamage) * 2;
            }

            return base.ChangeDamageWhenAttacking(attackerWithSpecialty, defender, currentDamage);
        }

        public override string ToString()
        {
            return string.Format("{0}({1})", base.ToString(), this.roundsLeft);
        }
    }
}
