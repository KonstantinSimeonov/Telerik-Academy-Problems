namespace GenericMemento.Cloneables
{
    using System;

    [Serializable]
    public class SpaceShip
    {
        public string Model { get; private set; }

        public string PilotName { get; set; }

        public SpaceShip(string model, string pilot)
        {
            this.Model = model;
            this.PilotName = pilot;
        }
    }
}