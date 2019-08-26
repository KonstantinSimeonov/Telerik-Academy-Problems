namespace Cosmetics.Products
{
    using System.Linq;
    using System.Collections.Generic;
    using Cosmetics.Contracts;

    class ShoppingCart : IShoppingCart
    {
        #region Fields
        private IList<IProduct> products;
        #endregion

        #region Constructors
        public ShoppingCart()
        {
            this.Products = new List<IProduct>();
        }
        #endregion

        #region Properties
        public IList<IProduct> Products
        {
            get { return new List<IProduct>(products); }
            private set { this.products = value; }
        }
        #endregion

        #region Methods
        public void AddProduct(IProduct product)
        {
            this.products.Add(product);
        }

        public void RemoveProduct(IProduct product)
        {
            this.products.Remove(product);
        }

        public bool ContainsProduct(IProduct product)
        {
            return this.products.Contains(product);
        }

        public decimal TotalPrice()
        {
            decimal totalPrice = 0;

            foreach (var item in this.products)
            {
                totalPrice += item.Price;
            }

            return totalPrice;
        }
        #endregion
    }
}
