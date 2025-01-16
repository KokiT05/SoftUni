using INStock.Contracts;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INStock.Fake
{
    public class FakeProductStockSystem : IProductStock
    {
        private List<IProduct> products;

        public FakeProductStockSystem()
        {
            this.products = new List<IProduct>();
        }

        public IProduct this[int index] { get => this.products[index]; set => this.products[index] = value; }

        public int Count => this.products.Count;

        public void Add(IProduct product)
        {
            this.products.Add(product);
        }

        public bool Contains(IProduct product)
        {
            return this.products.Contains(product);
        }

        public IProduct Find(int index)
        {
            IProduct product = this.products[index];
            if (product == null)
            {
                return null;
            }

            return product;
        }

        public IEnumerable<IProduct> FindAllByPrice(decimal price)
        {
            return this.products.Where(p => p.Price == price).ToList();
        }

        public IEnumerable<IProduct> FindAllByQuantity(int quantity)
        {
            return this.products.Where(p => p.Quantity == quantity).ToList();
        }

        public IEnumerable<IProduct> FindAllInRange(decimal lo, decimal hi)
        {
            return this.products.Where(p => p.Price >= lo && p.Price <= hi);
        }

        public IProduct FindByLabel(string label)
        {
            return this.products.FirstOrDefault(p => p.Label == label);
        }

        public IProduct FindMostExpensiveProduct()
        {
            return this.products.FirstOrDefault(p => p.Price == this.Max(p => p.Price));
        }

        public IEnumerator<IProduct> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public bool Remove(IProduct product)
        {
            return this.products.Remove(product);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
