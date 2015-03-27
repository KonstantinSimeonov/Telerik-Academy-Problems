namespace Infestation
{
//    •	Implement a Weapon Supplement
//o	A Weapon is a Supplement, which increases the Power of a Unit by 10 and its Aggression by 3,
//    but only if the Unit already has a WeaponrySkill Supplement. If not, the Weapon Supplement does not have any effect.


    class Weapon : ISupplement
    {
        private const int BASE_POWER_EFFECT = 0;
        private const int BASE_HEALTH_EFFECT = 0;
        private const int BASE_AGGRESSION_EFFECT = 0;


        public Weapon()
        {
            this.PowerEffect = Weapon.BASE_POWER_EFFECT;
            this.HealthEffect = Weapon.BASE_HEALTH_EFFECT;
            this.AggressionEffect = Weapon.BASE_AGGRESSION_EFFECT;
        }

        public int PowerEffect { get; private set; }

        public int HealthEffect { get; private set; }

        public int AggressionEffect { get; private set; }

        public void ReactTo(ISupplement otherSupplement)
        {
            if (otherSupplement.GetType() == typeof(WeaponrySkill))
            {
                this.PowerEffect += 10;
                this.AggressionEffect += 3;
            }
        }
    }
}
