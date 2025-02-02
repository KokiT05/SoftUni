using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.Composite
{
    public interface IGiftOperations
    {
        void Add(GiftBase giftBase);

        void Remove(GiftBase giftBase);
    }
}
