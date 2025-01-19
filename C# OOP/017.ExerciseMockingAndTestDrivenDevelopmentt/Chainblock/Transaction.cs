using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chainblock.Contracts;

namespace Chainblock
{
    public class Transaction : ITransaction
    {
        public int Id { get; set; }

        public TransactionStatus Status { get; set; }

        public string From { get; set; }

        public string To { get; set; }

        public double Amount { get; set; }
    }
}
