using System;

namespace Infestation
{
    class InfestationSpores : ISupplement
    {
        private const int BASE_POWER_EFFECT=-1;
        private const int BASE_HEALTH_EFFECT=0;
        private const int BASE_AGGRESSION_EFFECT = 20;

        public InfestationSpores()
        {
            this.PowerEffect = InfestationSpores.BASE_POWER_EFFECT;
            this.HealthEffect = InfestationSpores.BASE_HEALTH_EFFECT;
            this.AggressionEffect = InfestationSpores.BASE_AGGRESSION_EFFECT;
        }

        public int PowerEffect { get; private set; }

        public int HealthEffect { get; private set; }

        public int AggressionEffect { get; private set; }

        public void ReactTo(ISupplement otherSupplement)
        {
            if (otherSupplement.GetType() == this.GetType())
            {
                this.PowerEffect = 0;
                this.HealthEffect = 0;
                this.AggressionEffect = 0;
            }
        }
    }
}
