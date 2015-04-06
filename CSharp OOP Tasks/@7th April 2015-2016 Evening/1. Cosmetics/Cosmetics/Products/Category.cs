namespace Cosmetics.Products
{
    using System;
    using System.Text;
    using System.Linq;
    using System.Collections.Generic;
    using Cosmetics.Common;
    using Cosmetics.Contracts;


    public class Category : ICategory
    {
        #region Constraints
        private const int MAX_NAME_LENGTH = 15;
        private const int MIN_NAME_LENGTH = 2;
        #endregion

        #region Fields
        private string name;
        private IList<IProduct> products;
        #endregion

        #region Constructors
        public Category(string name)
        {
            this.Name = name;
            this.Products = new List<IProduct>();
        }
        #endregion

        #region Properties
        public string Name
        {
            get { return name; }
            private set
            {
                Validator.CheckIfStringIsNullOrEmpty(value);

                Validator.CheckIfStringLengthIsValid(value,
                                                     Category.MAX_NAME_LENGTH,
                                                     Category.MIN_NAME_LENGTH,
                                                     string.Format("Category name must be between {0} and {1} symbols long!",
                                                                    Category.MIN_NAME_LENGTH,
                                                                    Category.MAX_NAME_LENGTH
                                                                  )
                                                     );

                this.name = value;
            }
        }

        public IList<IProduct> Products
        {
            get { return new List<IProduct>(this.products); }
            private set { this.products = value; }
        }
        #endregion

        #region Methods
        public void AddCosmetics(IProduct cosmetics)
        {
            this.products.Add(cosmetics);
        }

        public void RemoveCosmetics(IProduct cosmetics)
        {
            this.products.Remove(cosmetics);
        }

        public string Print()
        {
            return this.ToString();
        }

        public override string ToString()
        {
            this.Products = this.products.OrderBy(x => x.Brand).ThenByDescending(x => x.Price).ToList();

            string categoryTitle = string.Format("{0} category - {1} {2} in total{3}",
                                                  this.Name,
                                                  this.products.Count,
                                                  this.products.Count == 1 ? "product" : "products",
                                                  this.products.Count == 0 ? string.Empty : Environment.NewLine
                                                );

            var result = new StringBuilder(categoryTitle);

            for (int i = 0; i < this.products.Count; i++)
            {
                result.Append(this.products[i]);

                if (i != this.products.Count - 1)
                {
                    result.Append(Environment.NewLine);
                }
                    
            }

            return result.ToString();
        }
        #endregion
    }
}
