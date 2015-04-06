namespace FurnitureManufacturer.Models
{
    using System;
    using FurnitureManufacturer.Interfaces;

    class Chair : Furniture, IChair
    {
        private int numberOfLegs;

        public Chair(string model, string material, decimal price, decimal height, int legs)
            : base(model, material, price, height)
        {
            this.NumberOfLegs = legs;
        }

        public int NumberOfLegs
        {
            get
            {
                return numberOfLegs;
            }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("A chair cannot have less than zero legs!");
                }

                numberOfLegs = value;
            }
        }

        public override string ToString()
        {
            return string.Format("Type: {0}, Model: {1}, Material: {2}, Price: {3}, Height: {4}, Legs: {5}",
                                this.GetType().Name, this.Model, this.Material, this.Price, this.Height, this.NumberOfLegs);
        }
    }
}
