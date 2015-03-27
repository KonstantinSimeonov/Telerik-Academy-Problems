using System;

namespace Infestation
{
    //    •	Catalists are Supplements, which improve the Health, Power and Aggression of a unit. Implement:
    //o	A PowerCatalyst – has a PowerEffect of 3
    //o	A HealthCatalyst – has a HealthEffect of 3
    //o	An AggressionCatalyst – has an AggressionEffect of 3



    public abstract class Catalyst : ISupplement
    {

        public Catalyst(int powerEffect, int healthEffect, int aggressionEffect)
        {
            this.PowerEffect = powerEffect;
            this.HealthEffect = healthEffect;
            this.AggressionEffect = aggressionEffect;
        }

        public int PowerEffect { get; private set; }

        public int HealthEffect { get; private set; }

        public int AggressionEffect { get; private set; }

        public virtual void ReactTo(ISupplement otherSupplement)
        {

        }
    }

    public class PowerCatalyst : Catalyst
    {
        private const int POWER_EFFECT = 3;
        private const int HEALTH_EFFECT=0;
        private const int AGGRESSION_EFFECT = 0;

        public PowerCatalyst()
            : base(PowerCatalyst.POWER_EFFECT, PowerCatalyst.HEALTH_EFFECT, PowerCatalyst.AGGRESSION_EFFECT)
        { }

    }

    public class HealthCatalyst : Catalyst
    {
        private const int POWER_EFFECT = 0;
        private const int HEALTH_EFFECT = 3;
        private const int AGGRESSION_EFFECT = 0;

        public HealthCatalyst()
            : base(HealthCatalyst.POWER_EFFECT, HealthCatalyst.HEALTH_EFFECT, HealthCatalyst.AGGRESSION_EFFECT)
        { }

    }

    public class AggressionCatalyst : Catalyst
    {
        private const int POWER_EFFECT = 0;
        private const int HEALTH_EFFECT = 0;
        private const int AGGRESSION_EFFECT = 3;

        public AggressionCatalyst()
            : base(AggressionCatalyst.POWER_EFFECT, AggressionCatalyst.HEALTH_EFFECT, AggressionCatalyst.AGGRESSION_EFFECT)
        { }

    }
}
