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
            // Code from the lecture
            if (this.Contains(tx.Id))
            {
                throw new InvalidOperationException($"Transaction with id: {tx.Id} already exists.");
            }

            this.transactions.Add(tx.Id, tx);

            // My code
            //if (!this.Contains(tx.Id))
            //{
            //    this.transactions.Add(tx.Id, tx);
            //}
        }

        public void ChangeTransactionStatus(int id, TransactionStatus newStatus)
        {
            // Code from the lecture
            if (!this.Contains(id))
            {
                throw new ArgumentException($"{id} id does not exist.");
            }

            ITransaction transaction = this.transactions[id];
            transaction.Status = newStatus;

            // My code
            //if (!this.transactions.ContainsKey(id))
            //{
            //    throw new ArgumentException();
            //}

            //ITransaction currentTransaction = this.transactions[id];
            //currentTransaction.Status = newStatus;
        }

        public bool Contains(ITransaction tx)
        {
            // Code from the lecture
            if (!this.Contains(tx.Id))
            {
                return false;
            }

            ITransaction existingTransaction = this.transactions[tx.Id];

            return tx.From == existingTransaction.From &&
                    tx.To == existingTransaction.To &&
                    tx.Status == existingTransaction.Status &&
                    tx.Amount == existingTransaction.Amount;



            // My code
            //ITransaction currentTransaction = this.transactions.Values
            //                                    .FirstOrDefault(t => t.Status == tx.Status &&
            //                                                            t.From == tx.From &&
            //                                                            t.To == tx.To &&
            //                                                            t.Amount == tx.Amount);

            //if (currentTransaction == null)
            //{
            //    return false;
            //}

            //return true;
        }

        public bool Contains(int id)
        {
            return this.transactions.ContainsKey(id);
        }

        public IEnumerable<ITransaction> GetAllInAmountRange(double lo, double hi)
        {
            return this.transactions.Values.Where(t => t.Amount >= lo && t.Amount <= hi);
        }

        public IEnumerable<ITransaction> GetAllOrderedByAmountDescendingThenById()
        {
            return this.transactions.Values.OrderByDescending(t => t.Amount).ThenBy(t => t.Id);
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
            // Code from lecture
            if (!this.Contains(id))
            {
                throw new InvalidOperationException($"Transaction with {id} does not exist");
            }

            return this.transactions[id];

            // My code
            //if (!this.transactions.ContainsKey(id))
            //{
            //    throw new InvalidOperationException();
            //}

            //return this.transactions[id];
        }

        public IEnumerable<ITransaction> GetByReceiverAndAmountRange(string receiver, double lo, double hi)
        {
            IEnumerable<ITransaction> currentTransactions = this.transactions.Values
                                                            .Where(t => t.To == receiver &&
                                                                    t.Amount >= lo &&
                                                                    t.Amount < hi)
                                                            .OrderByDescending(t => t.Amount)
                                                            .ThenBy(t => t.Id);

            if (!currentTransactions.Any())
            {
                throw new InvalidOperationException();
            }

            return currentTransactions;
        }

        public IEnumerable<ITransaction> GetByReceiverOrderedByAmountThenById(string receiver)
        {
            IEnumerable<ITransaction> currentTransactions = this.transactions.Values
                                                            .Where(t => t.To == receiver)
                                                            .OrderByDescending(t => t.Amount)
                                                            .ThenBy(t => t.Id);

            if (!currentTransactions.Any())
            {
                throw new InvalidOperationException();
            }

            return currentTransactions;
        }

        public IEnumerable<ITransaction> GetBySenderAndMinimumAmountDescending(string sender, double amount)
        {
            IEnumerable<ITransaction> currentTransaction = this.transactions.Values
                                                            .Where(t => t.From == sender &&
                                                            t.Amount > amount)
                                                            .OrderByDescending(t => t.Amount);
            if (!currentTransaction.Any())
            {
                throw new InvalidOperationException();
            }

            return currentTransaction;  
        }

        public IEnumerable<ITransaction> GetBySenderOrderedByAmountDescending(string sender)
        {
            IEnumerable<ITransaction> currentTransaction = this.transactions.Values
                                                .Where(t => t.From == sender)
                                                .OrderByDescending(t => t.Amount);
            if (!currentTransaction.Any())
            {
                throw new InvalidOperationException();
            }

            return currentTransaction;
        }

        public IEnumerable<ITransaction> GetByTransactionStatus(TransactionStatus status)
        {
            // Code from the lecture
            List<ITransaction> result = this.transactions.Values
                                            .Where(t => t.Status == status)
                                            .OrderByDescending(t => t.Amount)
                                            .ToList();

            if (result.Count == 0)
            {
                throw new InvalidOperationException();
            }

            return result;

            // My Code
            //IEnumerable<ITransaction> currentTransactions =
            //this.transactions.Values.Select(t => t)
            //                        .Where(t => t.Status == status)
            //                        .OrderByDescending(t => t.Amount);

            //if (!currentTransactions.Any())
            //{
            //    throw new InvalidOperationException();
            //}

            //return currentTransactions;
        }

        public IEnumerable<ITransaction> GetByTransactionStatusAndMaximumAmount(TransactionStatus status, double amount)
        {
            return this.transactions.Values.Where(t => t.Status == status &&
                                                    t.Amount <= amount).OrderByDescending(t => t.Amount);
        }

        public IEnumerator<ITransaction> GetEnumerator()
        {
            foreach (var transaction in this.transactions)
            {
                yield return transaction.Value;
            }
        }

        public void RemoveTransactionById(int id)
        {
            // Code from lecture
            if (!this.Contains(id))
            {
                throw new InvalidOperationException($"Transaction with {id} does not exist.");
            }

            this.transactions.Remove(id);

            // My code
            //if (!this.transactions.ContainsKey(id))
            //{
            //    throw new InvalidOperationException();
            //}

            //this.transactions.Remove(id);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
