using INStock.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INStock.Fake
{
    public class FakeProduct : IProduct
    {
        public FakeProduct(string label, decimal price, int quantity)
        {
            this.Label = label;
            this.Price = price;
            this.Quantity = quantity;
        }

        public string Label { get; }

        public decimal Price { get; }

        public int Quantity { get; }

        public int CompareTo(IProduct other)
        {
            throw new NotImplementedException();
        }
    }
}
