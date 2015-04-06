using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infestation
{
    public class HoldingPen
    {
        private List<Unit> containedUnits = new List<Unit>();

        public void ParseCommand(string command)
        {
            string[] commandWordSeparators = new string[] { " " };

            string[] commandWords = command.Split(commandWordSeparators, StringSplitOptions.RemoveEmptyEntries);

            DispatchCommand(commandWords);

        }

        protected virtual void DispatchCommand(string[] commandWords)
        {
            switch (commandWords[0])
            {
                case "insert":
                    this.ExecuteInsertUnitCommand(commandWords);
                    break;
                case "proceed":
                    this.ExecuteProceedSingleIterationCommand();
                    break;
                case "supplement":
                    this.ExecuteAddSupplementCommand(commandWords);
                    break;
                case "status":
                    this.ExecutePrintStatusCommand();
                    break;
                default:
                    break;
            }
        }

        private void ExecutePrintStatusCommand()
        {
            foreach (var unit in this.containedUnits)
            {
                Console.WriteLine(unit);
            }
        }

        protected virtual void ExecuteAddSupplementCommand(string[] commandWords)
        {

//            •	Supplement command – adds a supplement to an existing unit
//o	Syntax: supplement SupplementType targetUnitId
//o	Creates a supplement of the desired type (e.g. AggressionInhibitor) and adds it to the unit with the provided id
//o	Syntax: supplement AggressionInhibitor sharo – adds an AggressionInhibitor to the Dog sharo (created in the previous examples)


            var unit = containedUnits.Single(x => x.Id == commandWords[2]);

            switch (commandWords[1])
            {
                case "Weapon":
                    unit.AddSupplement(new Weapon());
                    break;
                case "PowerCatalyst":
                    unit.AddSupplement(new PowerCatalyst());
                    break;
                case "HealthCatalyst":
                    unit.AddSupplement(new HealthCatalyst());
                    break;
                case "AggressionCatalyst":
                    unit.AddSupplement(new AggressionCatalyst());
                    break;
                default:
                    throw new ArgumentException("Unknown supplement command");
            }
        }

        protected virtual void ExecuteProceedSingleIterationCommand()
        {
            var containedUnitsInfo = this.containedUnits.Select((unit) => unit.Info);

            IEnumerable<Interaction> requestedInteractions =
                from unit in this.containedUnits
                select unit.DecideInteraction(containedUnitsInfo);

            requestedInteractions = requestedInteractions.Where((interaction) => interaction != Interaction.PassiveInteraction);

            foreach (var interaction in requestedInteractions)
            {
                this.ProcessSingleInteraction(interaction);
            }

            this.containedUnits.RemoveAll((unit) => unit.IsDestroyed);
        }

        protected virtual void ProcessSingleInteraction(Interaction interaction)
        {
            switch (interaction.InteractionType)
            {
                case InteractionType.Attack:
                    Unit targetUnit = this.GetUnit(interaction.TargetUnit);
                    targetUnit.DecreaseBaseHealth(interaction.SourceUnit.Power);
                    break;

                case InteractionType.Infest:
                    targetUnit = this.GetUnit(interaction.TargetUnit);
                    targetUnit.AddSupplement(new InfestationSpores());
                    break;

                default:
                    break;
            }
        }

        protected Unit GetUnit(string unitId)
        {
            return this.containedUnits.FirstOrDefault((unit) => unit.Id == unitId);
        }

        protected Unit GetUnit(UnitInfo unitInfo)
        {
            return this.GetUnit(unitInfo.Id);
            //return this.containedUnits.FirstOrDefault((unit) => unit.Id == unitInfo.Id);
        }

        protected virtual void ExecuteInsertUnitCommand(string[] commandWords)
        {
            switch (commandWords[1])
            {
                case "Dog":
                    var dog = new Dog(commandWords[2]);
                    this.InsertUnit(dog);
                    break;
                case "Human":
                    var human = new Human(commandWords[2]);
                    this.InsertUnit(human);
                    break;

                    // Insert my classes in the pen

                case "Parasite":
                    var parasite = new Parasite(commandWords[2]);
                    this.InsertUnit(parasite);
                    break;
                case "Marine":
                    var marine = new Marine(commandWords[2]);
                    this.InsertUnit(marine);
                    break;
                case "Tank":
                    var tank = new Tank(commandWords[2]);
                    this.InsertUnit(tank);
                    break;
                case "Queen":
                    var queen = new Queen(commandWords[2]);
                    this.InsertUnit(queen);
                    break;
                default:
                    break;
            }
        }

        protected void InsertUnit(Unit unit)
        {
            this.containedUnits.Add(unit);
        }
    }
}
