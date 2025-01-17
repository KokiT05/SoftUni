using INStock.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INStock
{
    public class Market
    {
        private IProductStock productStock;

        public Market(IProductStock productStock)
        {
            this.productStock = productStock;
        }

        public IProductStock ProductStock { get { return productStock; } }

        public int CurrentProductCount()
        {
            return this.ProductStock.Count;
        }

        public IProduct this[int index] { get => this.ProductStock[index]; set => this.ProductStock[index] = value; }

        public bool Contains(IProduct product)
        {
            return this.ProductStock.Contains(product);
        }

        public void Add(IProduct product)
        {
            this.ProductStock.Add(product);
        }

        public bool Remove(IProduct product)
        {
            return this.ProductStock.Remove(product);
        }

        public IProduct Find(int index)
        {
            return this.ProductStock.Find(index);
        }

        public IProduct FindByLabel(string label)
        {
            return this.ProductStock.FindByLabel(label);
        }

        public IProduct FindMostExpensiveProduct()
        {
            return this.ProductStock.FindMostExpensiveProduct();
        }

        public IEnumerable<IProduct> FindAllInRange(decimal lo, decimal hi)
        {
            return this.ProductStock.FindAllInRange(lo, hi);
        }

        public IEnumerable<IProduct> FindAllByPrice(decimal price)
        {
            return this.ProductStock.FindAllByPrice(price);
        }

        public IEnumerable<IProduct> FindAllByQuantity(int quantity)
        {
            return this.ProductStock.FindAllByQuantity(quantity);
        }
    }
}
