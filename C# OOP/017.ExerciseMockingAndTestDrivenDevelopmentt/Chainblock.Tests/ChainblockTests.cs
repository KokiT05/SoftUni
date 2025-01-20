using NUnit.Framework;
using Chainblock.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace Chainblock.Tests
{
    [TestFixture]
    public class ChainblockTests
    {
        ITransaction transaction;
        ITransaction secondTransaction;

        IChainblock chainblock;

        [SetUp]
        public void SeUp()
        {
            this.transaction = new Transaction();
            this.transaction.Id = 1111111;
            this.transaction.Status = TransactionStatus.Successfull;
            this.transaction.From = "FakePeopleOne";
            this.transaction.To = "FakePeoplpeTwo";
            this.transaction.Amount = 1111.111;

            this.secondTransaction = new Transaction()
            {
                Id = 1234,
                Status = TransactionStatus.Successfull,
                From = "TestTransaction",
                To = "TransactionTest",
                Amount = 123.123
            };


            this.chainblock = new Chainblock();

            this.chainblock.Add(this.transaction);
        }

        [Test]
        public void AddMethodShouldAddTransaction()
        {

            Assert.That(this.chainblock.Count, Is.EqualTo(1));
            Assert.That(this.chainblock.Contains(this.transaction.Id));
        }

        [Test]
        public void AddMethodCannotAddExistingTransaction()
        {
            this.chainblock.Add(this.transaction);

            Assert.That(this.chainblock.Count, Is.EqualTo(1));
        }

        [Test]
        public void ContainsMethodShouldReturnTrueWhenFindTransaction()
        {
            ITransaction testTransaction = new Transaction()
            {
                Id = 1234,
                Status = this.transaction.Status,
                From = this.transaction.From,
                To = this.transaction.To,
                Amount = this.transaction.Amount,
            };

            Assert.That(this.chainblock.Contains(this.transaction), Is.EqualTo(true));
        }

        [Test]
        public void ContainsMethodShouldReturnFalseWhenItDoesNotFindTransaction()
        {

            Assert.That(this.chainblock.Contains(this.secondTransaction), Is.EqualTo(false));
        }

        [Test]
        public void ContainsMethodShouldReturnTrueWhenFindTransactionId()
        {
            Assert.That(this.chainblock.Contains(this.transaction.Id), Is.EqualTo(true));
        }

        [Test]
        public void ContainsMethodShouldReturnFalseWhenItDoesNotFindTransactionId()
        {
            Assert.That(this.chainblock.Contains(this.secondTransaction), Is.EqualTo(false));
        }

        [Test]
        public void CountPropertyShouldReturnCorrecntNumberOfTransaction()
        {
            Assert.That(this.chainblock.Count, Is.EqualTo(1));

            this.chainblock.Add(this.secondTransaction);

            Assert.That(this.chainblock.Count, Is.EqualTo(2));
        }

        [Test]
        public void ChangeTransactionStatusMethodShouldChangeTransactionStatus()
        {
            this.chainblock.ChangeTransactionStatus(this.transaction.Id, TransactionStatus.Failed);

            Assert.That(this.transaction.Status, Is.EqualTo(TransactionStatus.Failed));
        }

        [Test]
        public void ChangeTransactionStatusMethodShouldReturnExceptionWhenTransactionDoesNotExist()
        {
            Assert.Throws<ArgumentException>(
            () => this.chainblock.ChangeTransactionStatus(this.secondTransaction.Id, TransactionStatus.Aborted));
        }

        [Test]
        public void RemoveTransactionByIdMethodShouldRemoveTranaction()
        {
            this.chainblock.RemoveTransactionById(this.transaction.Id);

            Assert.That(this.chainblock.Contains(this.transaction.Id), Is.EqualTo(false));
            Assert.That(this.chainblock.Count, Is.EqualTo(0));
        }

        [Test]
        public void RemoveTransactionByIdMethodShouldReturnExceptionWhenTransactionDoesNotExist()
        {
            Assert.Throws<InvalidOperationException>(
            () => this.chainblock.RemoveTransactionById(this.secondTransaction.Id));
        }

        [Test]
        public void GetByIdMethodShouldReturnTransanction()
        {
            ITransaction expectedTransaction = this.chainblock.GetById(this.transaction.Id);

            Assert.True(expectedTransaction.Equals(this.transaction));
        }

        [Test]
        public void GetByIdMethodShouldReturnExceptionWhenTransactionDoesNotExist()
        {
            Assert.Throws<InvalidOperationException>(
                () => this.chainblock.GetById(this.secondTransaction.Id));
        }

        [Test]
        public void GetByTransactionStatusShouldReturnAllTransactionWithSameStatus()
        {
            TransactionStatus transactionStatusSuccessfull = TransactionStatus.Successfull;

            ITransaction testTransaction = new Transaction()
            {
                Id = 1234567,
                From = "TestTransaction",
                To = "TransactionTest",
                Status = transactionStatusSuccessfull,
                Amount = 11.11
            };

            this.chainblock.Add(testTransaction);

            IEnumerable<ITransaction> actualTransactions = this.chainblock.GetByTransactionStatus
                (transactionStatusSuccessfull);



            IEnumerable<ITransaction> expectedTransaction = new List<ITransaction> 
                                                            { this.transaction, testTransaction };

            Assert.That(expectedTransaction, Is.EquivalentTo(actualTransactions));

            double currentAmount = double.PositiveInfinity;
            foreach (ITransaction transaction in actualTransactions)
            {
                Assert.That(transaction.Status, Is.EqualTo(transactionStatusSuccessfull));
                Assert.That(transaction.Amount, Is.LessThanOrEqualTo(currentAmount));

                currentAmount = transaction.Amount;
            }
        }

        [Test]
        public void GetByTransactionStatusShouldThrowExceptionWhenStatusIsNotFound()
        {
            Assert.Throws<InvalidOperationException>(
            () => this.chainblock.GetByTransactionStatus(TransactionStatus.Unauthorized));
        }

        [Test]
        public void GetAllSendersWithTransactionStatusShouldReturnAllSenders()
        {
            TransactionStatus transactionStatusSuccessfull = TransactionStatus.Successfull;

            ITransaction testTransaction = new Transaction()
            {
                Id = 1234567,
                From = "TestTransaction",
                To = "TransactionTest",
                Status = transactionStatusSuccessfull,
                Amount = 11.11
            };

            this.chainblock.Add(testTransaction);

            IEnumerable<string> actualResult =
                this.chainblock.GetAllSendersWithTransactionStatus(transactionStatusSuccessfull);

            IEnumerable<string> expectedResult = new List<string>() { this.transaction.From, testTransaction.From };

            Assert.That(actualResult, Is.EquivalentTo(expectedResult));
        }

        [Test]
        public void  GetAllSendersWithTransactionStatusShouldReturnException()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                this.chainblock.GetAllSendersWithTransactionStatus(TransactionStatus.Unauthorized);
            });
        }

        [Test]
        public void GetAllReceiversWithTransactionStatusShouldReturnAllReceivers()
        {
            TransactionStatus transactionStatusFailed = TransactionStatus.Failed;

            ITransaction firstTestTransaction = new Transaction()
            {
                Id = 1234567,
                From = "TestTransaction",
                To = "TransactionTest",
                Status = transactionStatusFailed,
                Amount = 11.11
            };

            ITransaction secondTestTransaction = new Transaction()
            {
                Id = 98765,
                From = "secondTestTransaction",
                To = "secondTransactionTest",
                Status = transactionStatusFailed,
                Amount = 22.22
            };

            this.chainblock.Add(firstTestTransaction);
            this.chainblock.Add(secondTestTransaction);

            IEnumerable<string> actualResult = 
            this.chainblock.GetAllReceiversWithTransactionStatus(transactionStatusFailed);

            IEnumerable<string> expectedResult = new List<string>()
            { firstTestTransaction.To, secondTestTransaction.To};

            Assert.That(actualResult, Is.EquivalentTo(expectedResult));
        }

        [Test]
        public void GetAllReceiversWithTransactionStatusShouldReturnExceptionWhenTransactionStatusDoesNotExist()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                this.chainblock.GetAllReceiversWithTransactionStatus(TransactionStatus.Aborted);
            });
        }

        [Test]
        public void GetAllOrderedByAmountDescendingThenByIdShouldReturnAllTransactionOrder()
        {
            ITransaction firstTestTransaction = new Transaction()
            {
                Id = 1234567,
                From = "TestTransaction",
                To = "TransactionTest",
                Status = TransactionStatus.Unauthorized,
                Amount = 22.22
            };

            ITransaction secondTestTransaction = new Transaction()
            {
                Id = 98765,
                From = "secondTestTransaction",
                To = "secondTransactionTest",
                Status = TransactionStatus.Aborted,
                Amount = 22.22
            };

            IEnumerable<ITransaction> actualResult = this.chainblock.GetAllOrderedByAmountDescendingThenById();
            int currentId = actualResult.FirstOrDefault().Id;
            double currentAmount = double.PositiveInfinity;
            foreach (ITransaction transaction in actualResult)
            {

                Assert.That(transaction.Amount, Is.LessThanOrEqualTo(currentAmount));
                Assert.That(transaction.Id, Is.GreaterThanOrEqualTo(currentId));
                currentAmount = transaction.Amount;
            }
        }

        [Test]
        public void GetBySenderOrderedByAmountDescendingShouldReturnAllTransactionBySender()
        {

            ITransaction firstTestTransaction = new Transaction()
            {
                Id = 1234567,
                From = this.transaction.From,
                To = "TransactionTest",
                Status = TransactionStatus.Unauthorized,
                Amount = 22.22
            };

            ITransaction secondTestTransaction = new Transaction()
            {
                Id = 98765,
                From = this.transaction.From,
                To = "secondTransactionTest",
                Status = TransactionStatus.Aborted,
                Amount = 27.22
            };

            this.chainblock.Add(firstTestTransaction);
            this.chainblock.Add(secondTestTransaction);

            IEnumerable<ITransaction> actualResult =
                this.chainblock.GetBySenderOrderedByAmountDescending(this.transaction.From);

            double amount = double.PositiveInfinity;
            foreach (ITransaction currentTransaction in actualResult)
            {
                Assert.That(currentTransaction.From, Is.EqualTo(this.transaction.From));
                Assert.That(currentTransaction.Amount, Is.LessThanOrEqualTo(amount));

                amount = currentTransaction.Amount;
            }
        }

        [Test]
        public void GetBySenderOrderedByAmountDescendingShouldReturnExceptionWhenSenderDoesNotExist()
        {
            ITransaction firstTestTransaction = new Transaction()
            {
                Id = 1234567,
                From = this.transaction.From,
                To = "TransactionTest",
                Status = TransactionStatus.Unauthorized,
                Amount = 22.22
            };

            ITransaction secondTestTransaction = new Transaction()
            {
                Id = 98765,
                From = this.transaction.From,
                To = "secondTransactionTest",
                Status = TransactionStatus.Aborted,
                Amount = 25.22
            };

            this.chainblock.Add(firstTestTransaction);
            this.chainblock.Add(secondTestTransaction);

            Assert.Throws<InvalidOperationException>(() =>
            {
                this.chainblock.GetBySenderOrderedByAmountDescending("DontExist");
            });
        }

        [Test]
        public void GetByReceiverOrderedByAmountThenByIdShouldReturnAllTransactionByReceiver()
        {
                        ITransaction firstTestTransaction = new Transaction()
            {
                Id = 1234567,
                From = "TestTransaction",
                To = this.transaction.To,
                Status = TransactionStatus.Unauthorized,
                Amount = 22.22
            };

            ITransaction secondTestTransaction = new Transaction()
            {
                Id = 98765,
                From = "TestTransaction",
                To = this.transaction.To,
                Status = TransactionStatus.Aborted,
                Amount = 13.31
            };

            this.chainblock.Add(firstTestTransaction);
            this.chainblock.Add(secondTestTransaction);

            IEnumerable<ITransaction> actualResult =
                this.chainblock.GetBySenderOrderedByAmountDescending(this.transaction.To);

            int currentId = actualResult.First().Id;
            double amount = double.PositiveInfinity;
            foreach (ITransaction currentTransaction in actualResult)
            {
                Assert.That(currentTransaction.To, Is.EqualTo(this.transaction.To));
                Assert.That(currentTransaction.Amount, Is.LessThanOrEqualTo(amount));
                Assert.That(currentTransaction.Id, Is.GreaterThanOrEqualTo(currentId));

                amount = currentTransaction.Amount;
            }
        }


    }
}
