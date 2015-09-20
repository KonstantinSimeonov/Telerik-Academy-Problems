namespace GenericMemento.Cloneables
{
    using System.Collections.Generic;

    public class StormTrooper : IDeepClonable<StormTrooper>
    {
        private IList<string> equipment;

        public string Name { get; set; }

        public StormTrooper()
        {
            this.equipment = new List<string>();
        }

        public StormTrooper(string name)
            : this()
        {
            this.Name = name;
        }

        public IList<string> Equipment
        {
            get
            {
                return this.equipment;
            }
        }

        public StormTrooper DeepClone()
        {
            var cloned = new StormTrooper(this.Name);
            cloned.equipment = new List<string>(this.equipment);
            return cloned;
        }

        public void AddEquipment(string equipmentName)
        {
            this.equipment.Add(equipmentName);
        }
    }
}