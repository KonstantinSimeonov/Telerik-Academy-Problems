namespace Infestation
{
    //    •	Implement a Tank
    //o	A Tank is a type of Unit
    //o	The Tank has a base Power of 25, a base Health of 20, and a base Aggression of 25
    //o	The Tank is classified as a Mechanical Unit.


    class Tank : Unit
    {
        private const int BASE_POWER = 25;
        private const int BASE_HEALTH = 20;
        private const int BASE_AGGRESSION = 25;

        public Tank(string id)
            : base(id, UnitClassification.Mechanical, BASE_HEALTH, BASE_POWER, BASE_AGGRESSION)
        { }

        protected override UnitInfo GetOptimalAttackableUnit(System.Collections.Generic.IEnumerable<UnitInfo> attackableUnits)
        {
            UnitInfo optimalAttackableUnit = new UnitInfo(null, UnitClassification.Unknown, 0, int.MaxValue, 0);

            foreach (var unit in attackableUnits)
            {
                if (unit.Power < optimalAttackableUnit.Power && unit.Id != this.Id)
                {
                    optimalAttackableUnit = unit;
                }
            }

            return optimalAttackableUnit;
        }
    }
}
