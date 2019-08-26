namespace FurnitureManufacturer.Models
{
    using System;
    using FurnitureManufacturer.Interfaces;

    class Table : Furniture, ITable
    {
        private decimal length;
        private decimal width;

        public Table(string model, string material, decimal price, decimal height, decimal length, decimal width)
            : base(model, material, price, height)
        {
            this.Length = length;
            this.Width = width;
        }

        public decimal Length
        {
            get
            {
                return length;
            }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("Height cannot be equal to or less than zero!");
                }
                length = value;
            }
        }

        public decimal Width
        {
            get
            {
                return width;
            }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("Height cannot be equal to or less than zero!");
                }
                width = value;
            }
        }

        public decimal Area
        {
            get
            {
                return Width * Length;
            }
        }

        public override string ToString()
        {
            return string.Format("Type: {0}, Model: {1}, Material: {2}, Price: {3}, Height: {4}, Length: {5}, Width: {6}, Area: {7}",
                            this.GetType().Name, this.Model, this.Material, this.Price, this.Height, this.Length, this.Width, this.Area);
        }
    }
}
