namespace Infestation
{
//    •	Implement an InfestationSpores Supplement
//o	The InfestationSpores Supplement has an AggressionEffect of 20 and a PowerEffect of -1
//o	The InfestationSpores Supplement does not accumulate like the other Supplements – 
//    even if two or more Infestations are added, the total AggressionEffect stays 20 (Edit: the same goes for PowerEffect)
//o	The InfestationSpores Supplement cannot be added with the supplement command


    class WeaponrySkill : ISupplement
    {
        private const int BASE_POWER_EFFECT = 0;
        private const int BASE_HEALTH_EFFECT = 0;
        private const int BASE_AGGRESSION_EFFECT = 0;

        public WeaponrySkill()
        {
            this.PowerEffect = WeaponrySkill.BASE_POWER_EFFECT;
            this.HealthEffect = WeaponrySkill.BASE_HEALTH_EFFECT;
            this.AggressionEffect = WeaponrySkill.BASE_AGGRESSION_EFFECT;
        }

        public int PowerEffect { get; private set; }

        public int HealthEffect { get; private set; }

        public int AggressionEffect { get; private set; }

        public void ReactTo(ISupplement otherSupplement)
        {
            // emptee
        }
    }
}
