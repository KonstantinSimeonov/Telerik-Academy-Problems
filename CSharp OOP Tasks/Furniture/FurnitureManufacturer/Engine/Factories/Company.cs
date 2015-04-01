namespace FurnitureManufacturer.Engine.Factories
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using System.Text;
    using FurnitureManufacturer.Interfaces;
    using FurnitureManufacturer.Models;

    class Company : ICompany
    {
        private string name;
        private string regNumber;

        public Company(string name, string regNum)
        {
            this.Name = name;
            this.RegistrationNumber = regNum;
            this.Furnitures = new List<IFurniture>();
        }

        public string Name
        {
            get
            {
                return name;
            }

            private set
            {
                if (value == null || value.Length < 5)
                {
                    throw new ArgumentException("Name cannot be null or have less than 5 characters!");
                }
                name = value;
            }
        }

        public string RegistrationNumber
        {
            get
            {
                return regNumber;
            }

            private set
            {
                if (value.Where(symbol => !char.IsDigit(symbol)).Any() || value.Length != 10)
                {
                    throw new ArgumentException("Registration number can't have other symbols than digits and must be exactly 10 symbols!");
                }
                regNumber = value;
            }
        }

        public ICollection<IFurniture> Furnitures { get; private set; }

        public void Add(IFurniture furniture)
        {
            Furnitures.Add(furniture);
        }

        public void Remove(IFurniture furniture)
        {
            if (Furnitures.Contains(furniture))
            {
                Furnitures.Remove(furniture);
            }
        }

        public IFurniture Find(string model)
        {
            try
            {
                return Furnitures.First(x => x.Model.ToLower().Equals(model.ToLower()));
            }
            catch
            {
                return null;
            }

        }

        public string Catalog()
        {
            var str = this.ToString();
            return str;
        }

        public override string ToString()
        {
            var ordered = this.Furnitures.OrderBy(x => x.Price).ThenBy(x => x.Model).ToList();
            var builder = new StringBuilder();
            foreach (var item in ordered)
            {
                builder.AppendLine(item.ToString());
            }

            return string.Format("{0} - {1} - {2} {3}\n{4}",
                                                this.Name,
                                                this.RegistrationNumber,
                                                this.Furnitures.Count != 0 ? this.Furnitures.Count.ToString() : "no",
                                                this.Furnitures.Count != 1 ? "furnitures" : "furniture",
                                                builder
                                ).Trim(new char[]{'\n', '\r', '\t'});
        }
    }
}