namespace Infestation
{
    using System.Collections.Generic;
    using System.Linq;

//    •	Implement a Queen
//o	The Queen is a type of Unit, which can infest
//	Infesting is equivalent to adding an InfestationSpores Supplement to the target
//o	The Queen has a base Health of 30 and all of its other base values are set to 1
//o	The Queen is classified as a Psionic Unit
//o	The Queen interacts in the same way as the Parasite


    class Queen : Unit
    {
        private const int BASE_POWER = 1;
        private const int BASE_HEALTH = 30;
        private const int BASE_AGGRESSION = 1;

        public Queen(string id)
            : base(id, UnitClassification.Psionic, Queen.BASE_HEALTH, Queen.BASE_POWER, Queen.BASE_AGGRESSION)
        { }

        public void Infest(Unit target)
        {
            if (InfestationRequirements.RequiredClassificationToInfest(target.UnitClassification) == this.UnitClassification)
                target.AddSupplement(new InfestationSpores());
        }

        protected override bool CanAttackUnit(UnitInfo unit)
        {
            return unit.Id != this.Id && InfestationRequirements.RequiredClassificationToInfest(unit.UnitClassification) == this.UnitClassification;
        }

        public override Interaction DecideInteraction(IEnumerable<UnitInfo> units)
        {
            IEnumerable<UnitInfo> attackableUnits = units.Where((unit) => this.CanAttackUnit(unit));

            UnitInfo optimalAttackableUnit = GetOptimalAttackableUnit(attackableUnits);

            if (optimalAttackableUnit.Id != null)
            {
                return new Interaction(new UnitInfo(this), optimalAttackableUnit, InteractionType.Infest);
            }

            return Interaction.PassiveInteraction;
        }

        protected override UnitInfo GetOptimalAttackableUnit(System.Collections.Generic.IEnumerable<UnitInfo> attackableUnits)
        {
            UnitInfo optimalAttackableUnit = new UnitInfo(null, UnitClassification.Unknown, int.MaxValue, 0, 0);

            foreach (var unit in attackableUnits)
            {
                if (unit.Health < optimalAttackableUnit.Health)
                {
                    optimalAttackableUnit = unit;
                }
            }

            return optimalAttackableUnit;
        }
    }
}
