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

        // Code from the lecture
        [Test]
        public void Add_ThrowsException_WhenTransactionWithIdAlreadyExists()
        {
            int id = 1;

            this.chainblock.Add(new Transaction
            {
                Id = id,
                Status = TransactionStatus.Successfull,
                Amount = 100,
                From = "firstPerson",
                To = "secondPerson"
            });

            Assert.Throws<InvalidOperationException>(() => this.chainblock.Add(new Transaction
            {
                Id = id,
                From = "firstPerson",
                To = "ThirdPerson",
                Amount = 150,
            })) ;
        }

        [Test]
        public void Add_ShouldAddsTransactionToChainblock_WhenTransactionIdIsValid()
        {
            ITransaction transaction = this.CreateSimpleTransaction();

            this.chainblock.Add(transaction);

            Assert.That(this.chainblock.Count, Is.EqualTo(1));
            Assert.That(this.chainblock.Contains(transaction.Id), Is.True);
        }

        [Test]
        public void ContainsId_ReturnsTrue_WhenTransactionWithIdExists()
        {
            ITransaction transaction = this.CreateSimpleTransaction();

            this.chainblock.Add(transaction);

            Assert.That(this.chainblock.Contains(transaction.Id), Is.True);
        }

        [Test]
        public void ContainsId_ReturnsFalse_WhenTransactionWithIdDoesNotExists()
        {
            Assert.That(this.chainblock.Contains(1), Is.False);
        }

        [Test]
        public void ContainsTransaction_ReturnsFalse_WhenTransactionWithIdDoesNotExist()
        {
            Assert.That(this.chainblock.Contains(this.CreateSimpleTransaction()), Is.False);
        }

        [Test]
        public void ContainsTransaction_ReturnsFalse_WhenTransactionWithIdExistButOtherPropertiesDoNotMatch()
        {
            ITransaction transaction = this.CreateSimpleTransaction();

            this.chainblock.Add(transaction);

            ITransaction searchingTransaction = new Transaction()
            {
                Id = transaction.Id,
                Amount = transaction.Amount + 50,
                From = transaction.From + "Fake",
                To = transaction.To + "Fake",
                Status = TransactionStatus.Aborted
            };

            Assert.That(this.chainblock.Contains(searchingTransaction), Is.False);
        }

        [Test]
        public void Contains_ReturnsTrue_WhenTransactionMatchesChainblockTransaction()
        {
            ITransaction transaction = this.CreateSimpleTransaction();

            this.chainblock.Add(transaction);

            ITransaction searchingTransaction = new Transaction()
            {
                Id = transaction.Id,
                Amount = transaction.Amount,
                From = transaction.From,
                To = transaction.To,
                Status = transaction.Status
            };

            Assert.That(this.chainblock.Contains(searchingTransaction), Is.True);
        }

        private ITransaction CreateSimpleTransaction()
        {
            return new Transaction()
            {
                Id = 1,
                Status = TransactionStatus.Successfull,
                From = "firstPerson",
                To = "secondPerson",
                Amount = 100
            };
        }
        //-------------------------------------------------------------------
        // My code
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
                this.chainblock.GetByReceiverOrderedByAmountThenById(this.transaction.To);

            int currentId = actualResult.First().Id;
            double amount = double.PositiveInfinity;
            foreach (ITransaction currentTransaction in actualResult)
            {
                Assert.That(currentTransaction.To, Is.EqualTo(this.transaction.To));
                Assert.That(currentTransaction.Amount, Is.LessThanOrEqualTo(amount));

                if (currentTransaction.Amount == amount)
                {
                    Assert.That(currentTransaction.Id, Is.GreaterThanOrEqualTo(currentId));
                }

                amount = currentTransaction.Amount;
            }
        }

        public void GetByReceiverOrderedByAmountThenByIdShouldReturnExceptionWhenReceiverDoesNotExist()
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

            Assert.Throws<InvalidOperationException>(() =>
            {
                this.chainblock.GetBySenderOrderedByAmountDescending("NotExistReceiver");
            });
        }

        [Test]
        public void GetByTransactionStatusAndMaximumAmountShouldReturnTransactions()
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

            double maxAmount = 214;

            IEnumerable<ITransaction> actualResult =
                this.chainblock.GetByTransactionStatusAndMaximumAmount(this.transaction.Status, maxAmount);

            double currentAmount = double.PositiveInfinity;
            foreach (ITransaction currentTransaction in actualResult)
            {
                Assert.That(currentTransaction.Status, Is.EqualTo(this.transaction.Status));
                Assert.That(currentTransaction.Amount, Is.LessThanOrEqualTo(maxAmount));
                Assert.That(currentTransaction.Amount, Is.LessThanOrEqualTo(currentAmount));
            }
        }

        public void GetBySenderAndMinimumAmountDescendingShouldReturnExceptionWhenNoTransactionsFound()
        {
            ITransaction firstTestTransaction = new Transaction()
            {
                Id = 1234567,
                From = "firstTestTransaction",
                To = "firstTestTransaction",
                Status = TransactionStatus.Unauthorized,
                Amount = 2241.22
            };

            ITransaction secondTestTransaction = new Transaction()
            {
                Id = 98765,
                From = "secondTestTransaction",
                To = "secondTestTransaction",
                Status = TransactionStatus.Aborted,
                Amount = 132.31
            };

            this.chainblock.Add(firstTestTransaction);
            this.chainblock.Add(secondTestTransaction);

            double minAmount = 100;

            Assert.Throws<InvalidOperationException>(() =>
            {
                this.chainblock.GetBySenderAndMinimumAmountDescending("FakeSender", minAmount);
            });

        }

        [Test]
        public void GetBySenderAndMinimumAmountDescendingShouldReturnAllTransactionWithSenderAndMinimumAmount()
        {
            ITransaction firstTestTransaction = new Transaction()
            {
                Id = 1234567,
                From = this.transaction.From,
                To = "firstTestTransaction",
                Status = TransactionStatus.Unauthorized,
                Amount = 2241.22
            };

            ITransaction secondTestTransaction = new Transaction()
            {
                Id = 98765,
                From = this.transaction.From,
                To = "secondTestTransaction",
                Status = TransactionStatus.Aborted,
                Amount = 132.31
            };

            this.chainblock.Add(firstTestTransaction);
            this.chainblock.Add(secondTestTransaction);

            double minAmount = 100;

            IEnumerable<ITransaction> actualResult =
                this.chainblock.GetBySenderAndMinimumAmountDescending(this.transaction.From, minAmount);

            double currentAmount = double.PositiveInfinity;
            foreach (ITransaction currentTransaction in actualResult)
            {
                Assert.That(currentTransaction.From, Is.EqualTo(this.transaction.From));
                Assert.That(currentTransaction.Amount, Is.GreaterThan(minAmount));
                Assert.That(currentTransaction.Amount, Is.LessThanOrEqualTo(currentAmount));
            }
        }

        [Test]
        public void GetByReceiverAndAmountRangeShouldReturnExceptionWhenThereAreNoTransactions()
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

            double amountMin = 100;
            double amountMax = 250;

            Assert.Throws<InvalidOperationException>(() => 
            this.chainblock.GetByReceiverAndAmountRange(this.transaction.To, amountMin, amountMax));

        }

        [Test]
        public void GetByReceiverAndAmountRangeShouldReturnAllTransactionByReceiverAndAmounRange()
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

            double amountMin = 10;
            double amountMax = 25;

            IEnumerable<ITransaction> actualTransactions =
                this.chainblock.GetByReceiverAndAmountRange(this.transaction.To, amountMin, amountMax);

            int currentId = actualTransactions.FirstOrDefault().Id;
            double currentAmount = double.PositiveInfinity;
            foreach (ITransaction currentTransaction in actualTransactions)
            {
                Assert.That(currentTransaction.To, Is.EqualTo(this.transaction.To));
                Assert.That(currentTransaction.Amount, Is.LessThanOrEqualTo(amountMax));
                Assert.That(currentTransaction.Amount, Is.GreaterThanOrEqualTo(amountMin));
                Assert.That(currentTransaction.Amount, Is.LessThanOrEqualTo(currentAmount));

                if (currentAmount == currentTransaction.Amount)
                {
                    Assert.That(currentTransaction.Id, Is.GreaterThanOrEqualTo(currentId));
                }

                currentAmount = currentTransaction.Amount;
                currentId = currentTransaction.Id;
            }
        }

        [Test]
        public void GetAllInAmountRange()
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

            double amountMin = 10;
            double amountMax = 30;

            IEnumerable<ITransaction> actualResult = this.chainblock.GetAllInAmountRange(amountMin, amountMax);
            IEnumerable<ITransaction> expectedResult = 
            new List<ITransaction>() { firstTestTransaction, secondTestTransaction};

            Assert.That(actualResult, Is.EquivalentTo(expectedResult));

            actualResult = this.chainblock.GetAllInAmountRange(50, 100);

            Assert.That(actualResult.Count(), Is.EqualTo(0));
        }
    }
}
