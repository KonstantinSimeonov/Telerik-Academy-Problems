namespace FurnitureManufacturer.Models
{
    using System;
    using FurnitureManufacturer.Interfaces;

    class ConvertibleChair : Chair, IConvertibleChair
    {
        private const decimal CONVERTED_HEIGHT = 0.10M;

        private bool isConverted;
        
        public ConvertibleChair(string model, string material, decimal price, decimal height, int legs)
            : base(model, material, price, height, legs)
        {
            this.IsConverted = false;
        }

        public bool IsConverted { get; private set; }

        public override decimal Height
        {
            get
            {
                if (this.IsConverted)
                {
                    return ConvertibleChair.CONVERTED_HEIGHT;
                }

                return base.Height;

            }

            protected set
            {
                base.Height = value;
            }
        }

        public void Convert()
        {
            this.IsConverted = !this.IsConverted;
        }

        public override string ToString()
        {
            return string.Format("Type: {0}, Model: {1}, Material: {2}, Price: {3}, Height: {4}, Legs: {5}, State: {6}", this.GetType().Name, this.Model, this.Material, this.Price, this.Height, this.NumberOfLegs, this.IsConverted ? "Converted" : "Normal");
        }
    }
}
