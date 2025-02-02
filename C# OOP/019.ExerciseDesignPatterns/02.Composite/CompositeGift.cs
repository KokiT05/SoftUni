using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.Composite
{
    public class CompositeGift : GiftBase, IGiftOperations
    {
        private readonly ICollection<GiftBase> gifts;

        public CompositeGift(string name, int price) : base(name, price)
        {
            gifts = new List<GiftBase>();
        }

        public void Add(GiftBase giftBase)
        {
            gifts.Add(giftBase);
        }

        public void Remove(GiftBase giftBase)
        {
            gifts.Remove(giftBase);
        }

        public override int CalculateTotalPrice()
        {
            int total = 0;

            Console.WriteLine($"{name} contains the following products with prices: ");

            foreach (GiftBase gift in gifts)
            {
                total += gift.CalculateTotalPrice();
            }

            return total;
        }
    }
}
