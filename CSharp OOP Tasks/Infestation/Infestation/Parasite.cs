namespace Infestation
{
    using System.Collections.Generic;
    using System.Linq;
//    •	Implement a Parasite
//o	The Parasite is a type of Unit, which can Infest
//	Infesting is equivalent to adding an InfestationSpores Supplement to the target
//o	The Parasite is classified as a Biological Unit. 
//o	The Parasite has all base values set to 1
//o	When a Parasite is offered to Interact, it always tries to find a Unit to infest
//	The target Unit can be any unit different than itself
//	If there are multiple such units, the Parasite picks the one with the least Health


    class Parasite : Unit
    {
        private const int BASE_POWER = 1;
        private const int BASE_HEALTH = 1;
        private const int BASE_AGGRESSION = 1;

        public Parasite(string id)
            : base(id, UnitClassification.Biological, Parasite.BASE_HEALTH, Parasite.BASE_POWER, Parasite.BASE_AGGRESSION)
        { }

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

        protected override bool CanAttackUnit(UnitInfo unit)
        {
            return InfestationRequirements.RequiredClassificationToInfest(unit.UnitClassification) == this.UnitClassification && unit.Id != this.Id;
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
    }
}
