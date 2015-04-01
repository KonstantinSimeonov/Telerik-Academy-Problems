namespace FurnitureManufacturer.Models
{
    using System;
    using FurnitureManufacturer.Interfaces;

    public abstract class Furniture : IFurniture
    {
        private string model;
        private MaterialType material;
        private decimal price;
        private decimal height;

        public Furniture(string model, string material, decimal price, decimal height)
        {
            this.Material = material;
            this.Model = model;
            this.Price = price;
            this.Height = height;
        }


        public string Material
        {
            get
            {
                return this.material.ToString();
            }
            private set
            {
                switch (value)
                {
                    case "wooden": material = MaterialType.Wooden; break;
                    case "plastic": material = MaterialType.Plastic; break;
                    case "leather": material = MaterialType.Leather; break;
                    default: throw new ArgumentException("This type of furniture is not supported!");
                }

            }
        }

        public string Model
        {
            get
            {
                return model;
            }
            private set
            {
                if (value == null || value.Length < 3)
                {
                    throw new ArgumentException("Model name cannot be null or less than 3 symbols long!");
                }

                model = value;
            }
        }

        public decimal Price
        {
            get
            {
                return price;
            }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("Price cannot be equal to or less than zero!");
                }

                price = value;
            }
        }

        public virtual decimal Height
        {
            get
            {
                return height;
            }
            protected set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("Height cannot be equal to or less than zero!");
                }
                height = value;
            }
        }
    }

}
