namespace Infestation
{
//    •	Implement a Marine
// The Marine is a type of Human
// It has the same base Power, Health, Aggression
// It has a supplement by default – WeaponrySkill
// The WeaponrySkill does not directly affect any of the properties of the Marine
// The WeaponrySkill cannot be added with the supplement command (Edit: This means you cannot create it through the console, it doesn’t mean you can’t use the AddSupplement method)
// When a Marine attacks, it always picks a target, such that:
// The target’s Power is less than or equal to the Marine’s Aggression
// If there is more than one such target, the marine picks the one with the highest Health


    class Marine : Human
    {
        public Marine(string id)
            : base(id)
        {
            AddSupplement(new WeaponrySkill());
        }

        protected override UnitInfo GetOptimalAttackableUnit(System.Collections.Generic.IEnumerable<UnitInfo> attackableUnits)
        {
            UnitInfo optimalAttackableUnit = new UnitInfo(null, UnitClassification.Unknown, int.MinValue, 0, 0);

            foreach (var unit in attackableUnits)
            {
                if (unit.Health > optimalAttackableUnit.Health)
                {
                    optimalAttackableUnit = unit;
                }
            }

            return optimalAttackableUnit;
        }
    }
}
