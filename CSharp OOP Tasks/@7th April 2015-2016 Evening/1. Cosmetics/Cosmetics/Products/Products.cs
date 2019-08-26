namespace Cosmetics.Products
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using Cosmetics.Contracts;
    using Cosmetics.Common;

    public abstract class Product : IProduct
    {
        #region Constraints
        private const int MAX_NAME_LENGTH = 10;
        private const int MIN_NAME_LENGTH = 3;
        private const int MAX_BRAND_LENGTH = 10;
        private const int MIN_BRAND_LENGTH = 2;
        #endregion

        #region Fields
        private string name;
        private string brand;
        private decimal price;
        #endregion

        #region Constructors
        public Product(string name, string brand, decimal price, GenderType gender)
        {
            this.Name = name;
            this.Brand = brand;
            this.Price = price;
            this.Gender = gender;
        }
        #endregion

        #region Properties

        public string Name
        {
            get { return this.name; }
            private set
            {
                Validator.CheckIfStringIsNullOrEmpty(value);

                Validator.CheckIfStringLengthIsValid(value,
                                                     Product.MAX_NAME_LENGTH,
                                                     Product.MIN_NAME_LENGTH,
                                                            string.Format("Product name must be between {0} and {1} symbols long!",
                                                                          Product.MIN_NAME_LENGTH,
                                                                          Product.MAX_NAME_LENGTH)
                                                     );

                this.name = value;
            }
        }

        public string Brand
        {
            get { return this.brand; }
            private set
            {
                Validator.CheckIfStringIsNullOrEmpty(value);
                Validator.CheckIfStringLengthIsValid(value,
                                                     Product.MAX_BRAND_LENGTH,
                                                     Product.MIN_BRAND_LENGTH,
                                                     string.Format("Product brand must be between {0} and {1} symbols long!",
                                                                    Product.MIN_BRAND_LENGTH,
                                                                    Product.MAX_BRAND_LENGTH
                                                                  )
                                                          );
                this.brand = value;
            }
        }

        public virtual decimal Price
        {
            get { return price; }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("Price cannot be less than or equal to 0!");
                }

                this.price = value;
            }
        }

        public GenderType Gender { get; private set; }

        #endregion Properties

        #region Methods
        public virtual string Print()
        {
            return this.ToString();
        }

        public override string ToString()
        {
            

            return string.Format("- {0} - {1}:{4}  * Price: ${2}{4}  * For gender: {3}",
                                   this.Brand,
                                   this.Name,
                                   this.Price,
                                   this.Gender,
                                   Environment.NewLine
                                 );
        }
        #endregion
    }

    public class Toothpaste : Product, IProduct, IToothpaste
    {
        private const string SEPARATOR = ", ";

        #region Constraints
        private const int MIN_INGREDIENT_LENGTH = 4;
        private const int MAX_INGREDIENT_LENGTH = 12;
        #endregion

        #region Fields
        private string ingredients;
        #endregion

        #region Constructors
        public Toothpaste(string name, string brand, decimal price, GenderType gender, IList<string> ingredients)
            : base(name, brand, price, gender)
        {
            this.Ingredients = string.Join(Toothpaste.SEPARATOR, ingredients);
        }
        #endregion

        #region Properties
        public string Ingredients
        {
            get { return this.ingredients; }
            private set
            {
                Validator.CheckIfStringIsNullOrEmpty(value);

                foreach (var ingredient in value.Split(Toothpaste.SEPARATOR.ToCharArray(), StringSplitOptions.RemoveEmptyEntries))
                {
                    Validator.CheckIfStringLengthIsValid(ingredient, Toothpaste.MAX_INGREDIENT_LENGTH, Toothpaste.MIN_INGREDIENT_LENGTH, string.Format("Each ingredient must be between {0} and {1} symbols long!", Toothpaste.MIN_INGREDIENT_LENGTH, Toothpaste.MAX_INGREDIENT_LENGTH));
                }

                this.ingredients = value;
            }
        }
        #endregion

        #region Methods
        public override string Print()
        {
            return this.ToString();
        }

        public override string ToString()
        {
            return string.Format("{0}{2}  * Ingredients: {1}",
                                  base.ToString(),
                                  this.ingredients,
                                  Environment.NewLine
                                 );
        }
        #endregion
    }

    public class Shampoo : Product, IProduct, IShampoo
    {
        #region Properties
        public uint Milliliters { get; private set; }

        public UsageType Usage { get; private set; }

        public override decimal Price
        {
            get
            {
                return base.Price * this.Milliliters;
            }
        }
        #endregion

        #region Constructors
        public Shampoo(string name, string brand, decimal price, GenderType gender, uint milliliters, UsageType usage)
            : base(name, brand, price, gender)
        {
            this.Milliliters = milliliters;
            this.Usage = usage;
        }
        #endregion

        #region Methods
        public override string Print()
        {
            return this.ToString();
        }

        public override string ToString()
        {
            return string.Format("{0}{3}  * Quantity: {1} ml{3}  * Usage: {2}",
                                  base.ToString(),
                                  this.Milliliters,
                                  this.Usage,
                                  Environment.NewLine
                                 );
        }
        #endregion
    }
}