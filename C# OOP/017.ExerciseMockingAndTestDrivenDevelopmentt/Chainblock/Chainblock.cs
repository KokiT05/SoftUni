using Chainblock.Contracts;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chainblock
{
    public class Chainblock : IChainblock
    {
        private Dictionary<int, ITransaction> transactions;

        public Chainblock()
        {
            this.transactions = new Dictionary<int, ITransaction>();
        }

        public int Count => this.transactions.Count;

        public void Add(ITransaction tx)
        {
            if (!this.Contains(tx.Id))
            {
                this.transactions.Add(tx.Id, tx);
            }
        }

        public void ChangeTransactionStatus(int id, TransactionStatus newStatus)
        {
            if (!this.transactions.ContainsKey(id))
            {
                throw new ArgumentException();
            }

            ITransaction currentTransaction = this.transactions[id];
            currentTransaction.Status = newStatus;
        }

        public bool Contains(ITransaction tx)
        {
            ITransaction currentTransaction = this.transactions.Values
                                                .FirstOrDefault(t => t.Status == tx.Status &&
                                                                        t.From == tx.From &&
                                                                        t.To == tx.To &&
                                                                        t.Amount == tx.Amount);

            if (currentTransaction == null)
            {
                return false;
            }

            return true;
        }

        public bool Contains(int id)
        {
            return this.transactions.ContainsKey(id);
        }

        public IEnumerable<ITransaction> GetAllInAmountRange(double lo, double hi)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ITransaction> GetAllOrderedByAmountDescendingThenById()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<string> GetAllReceiversWithTransactionStatus(TransactionStatus status)
        {
            IEnumerable<ITransaction> currentTransactions =
                this.transactions.Values.Select(t => t).Where(t => t.Status == status).OrderBy(t => t.Amount);

            if (!currentTransactions.Any())
            {
                throw new InvalidOperationException();
            }

            return currentTransactions.Select(t => t.To);
        }

        public IEnumerable<string> GetAllSendersWithTransactionStatus(TransactionStatus status)
        {
            IEnumerable<ITransaction> currentTransactions = 
                this.transactions.Values.Select(t => t).Where(t => t.Status == status).OrderBy(t => t.Amount);

            if (!currentTransactions.Any())
            {
                throw new InvalidOperationException();
            }

            return currentTransactions.Select(t => t.From);

        }

        public ITransaction GetById(int id)
        {
            if (!this.transactions.ContainsKey(id))
            {
                throw new InvalidOperationException();
            }

            return this.transactions[id];
        }

        public IEnumerable<ITransaction> GetByReceiverAndAmountRange(string receiver, double lo, double hi)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ITransaction> GetByReceiverOrderedByAmountThenById(string receiver)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ITransaction> GetBySenderAndMinimumAmountDescending(string sender, double amount)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ITransaction> GetBySenderOrderedByAmountDescending(string sender)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ITransaction> GetByTransactionStatus(TransactionStatus status)
        {
            IEnumerable<ITransaction> currentTransactions =
            this.transactions.Values.Select(t => t)
                                    .Where(t => t.Status == status)
                                    .OrderByDescending(t => t.Amount);

            if (!currentTransactions.Any())
            {
                throw new InvalidOperationException();
            }

            return currentTransactions;
        }

        public IEnumerable<ITransaction> GetByTransactionStatusAndMaximumAmount(TransactionStatus status, double amount)
        {
            throw new NotImplementedException();
        }

        public IEnumerator<ITransaction> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public void RemoveTransactionById(int id)
        {
            if (!this.transactions.ContainsKey(id))
            {
                throw new InvalidOperationException();
            }

            this.transactions.Remove(id);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
