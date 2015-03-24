namespace WarMachines.Engine
{
    using WarMachines.Interfaces;
    using WarMachines.Machines;
    using System.Collections.Generic;

    public class MachineFactory : IMachineFactory
    {
        public IPilot HirePilot(string name)
        {
            var newPilot = new Pilot(name);

            return newPilot;
        }

        public ITank ManufactureTank(string name, double attackPoints, double defensePoints)
        {
            var newTank = new Tank(name, attackPoints, defensePoints);

            return newTank;
        }

        public IFighter ManufactureFighter(string name, double attackPoints, double defensePoints, bool stealthMode)
        {
            return new Fighter(name, attackPoints, defensePoints, stealthMode);
        }
    }
}
