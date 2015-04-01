namespace FurnitureManufacturer.Models
{
    using System;
    using FurnitureManufacturer.Interfaces;

    class AdjustableChair : Chair, IAdjustableChair
    {
        public AdjustableChair(string model, string material, decimal price, decimal height, int legs)
            : base(model, material, price, height, legs)
        {  }

        public void SetHeight(decimal height)
        {
            this.Height = height;
        }
    }
}
