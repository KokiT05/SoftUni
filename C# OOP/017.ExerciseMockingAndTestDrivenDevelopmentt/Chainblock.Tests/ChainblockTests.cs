using NUnit.Framework;
using Chainblock.Contracts;
using System;
using System.Collections.Generic;

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
    }
}
