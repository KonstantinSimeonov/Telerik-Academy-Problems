namespace WarMachines.Machines
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Interfaces;
    public abstract class Machine : IMachine
    {

        private IList<string> targets;
        private IPilot pilot;

        public IPilot Pilot
        {
            get { return pilot; }
            set 
            {
                if (value == null)
                {
                    throw new ArgumentNullException();
                }
                    pilot = value;
            }
        }
        

        public string Name { get; set; }

        public double HealthPoints { get;  set; }

        public double AttackPoints { get; protected set; }

        public double DefensePoints { get; protected set; }

        public IList<string> Targets
        {
            get
            {
                return targets;
            }

            private set
            {
                if (value == null)
                {
                    throw new ArgumentNullException();
                }

                targets = value;
            }
        }

        protected bool Mode { get; set; }

        public Machine(string name, double healthPoints, double attackPoints, double defensePoints, bool mode)
        {
            if (name == null || healthPoints == null || attackPoints == null || defensePoints == null || mode == null)
            {
                throw new ArgumentNullException();
            }

            this.Name = name;
            this.HealthPoints = healthPoints;
            this.AttackPoints = attackPoints;
            this.DefensePoints = defensePoints;
            this.Mode = mode;
            this.Targets = new List<string>();
        }

        public void Attack(string target)
        {
            Targets.Add(target);
        }

        public override string ToString()
        {
            bool isFighter = GetType() == typeof(Fighter);

            return string.Format(@" *Health: {0}
 *Attack: {1}
 *Defense: {2}
 *Targets: {3}", HealthPoints, AttackPoints, DefensePoints, Targets.Count == 0 ? "None" : string.Join(", ", Targets));
        }
    }

    public class Fighter : Machine, IFighter
    {

        private const double INITIAL_HP = 200;

        public bool StealthMode
        {
            get 
            {
                return Mode;
            }

            set
            {
                Mode = value;
            }
        }

        public Fighter(string name, double attackPoints, double defensePoints, bool mode)
            : base(name, INITIAL_HP, attackPoints, defensePoints, mode)
        { }

        public void ToggleStealthMode()
        {
            Mode = !Mode;
        }

        public override string ToString()
        {
            return string.Format(@"- {0}
 *Type: {1}
{2}
{3}", Name, "Fighter", base.ToString(), " *Stealth: "+ (Mode ? "ON" : "OFF"));
        }
    }

    public class Tank : Machine, ITank
    {
        private const double INITIAL_HP = 100;
        private const bool INITIAL_MODE = true;
        private const double ATTACK_PENALTY = 40;
        private const double DEFENSE_BONUS = 30;

        public bool DefenseMode
        {
            get { return Mode; }
            private set { Mode = value; }
        }

        public Tank(string name, double attackPoints, double defensePoints)
            : base(name, Tank.INITIAL_HP, attackPoints - ATTACK_PENALTY, defensePoints + DEFENSE_BONUS, INITIAL_MODE)
        {  }

        public void ToggleDefenseMode()
        {
            Mode = !Mode;

            if (Mode)
            {
                AttackPoints -= ATTACK_PENALTY;
                DefensePoints += DEFENSE_BONUS;
            }
            else
            {
                AttackPoints += ATTACK_PENALTY;
                DefensePoints -= DEFENSE_BONUS;
            }
        }

        public override string ToString()
        {
            return string.Format(@"- {0}
 *Type: {1}
{2}
{3}", Name, "Tank", base.ToString(), " *Defense: " + (Mode ? "ON" : "OFF"));
        }
    }

    public class Pilot : IPilot
    {
        private IList<IMachine> machines;
        private string name;

        public string Name {
            get
            {
                return name;
            }
            private set
            {
                if (value == null)
                {
                    throw new ArgumentNullException();
                }

                name = value;
            }
        }
        public IList<IMachine> Machines
        {
            get { return new List<IMachine>(machines); }
            private set { machines = value; }
        }

        public Pilot(string name)
        {
            this.Name = name;
            machines = new List<IMachine>();
        }

        public void AddMachine(IMachine machine)
        {
            machines.Add(machine);
            machine.Pilot = this;
        }

        public string Report()
        {
            return string.Format("{0} - {1} {2}{4}{3}", Name, machines.Count == 0 ? "no" : machines.Count.ToString(), machines.Count!=1 ? "machines" : "machine", string.Join("\n", machines), machines.Count == 0 ? "" : "\n");
        }
    }
}
