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

        IChainblock firstChainblock;
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

            this.firstChainblock = new Chainblock();

            this.firstChainblock.Add(this.transaction);
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
                Status = TransactionStatus.Failed
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

        [Test]
        public void Count_ReturnZero_WhenChainblockIsEmpty()
        {
            Assert.That(this.chainblock.Count, Is.Zero);
        }

        [Test]
        public void ChangeTransactionStatus_ThrowsException_WhenIdDoesNotExist()
        {
            this.chainblock.Add(this.CreateSimpleTransaction());

            Assert.Throws<ArgumentException>(() =>
            {
                this.chainblock.ChangeTransactionStatus(100, TransactionStatus.Failed);
            });
        }

        [Test]
        public void ChangeTransactionStatus_ChangesTransactionStatus_WhenIdExists()
        {
            ITransaction transaction = this.CreateSimpleTransaction();

            this.chainblock.Add(transaction);

            TransactionStatus transactionStatus = TransactionStatus.Unauthorized;

            this.chainblock.ChangeTransactionStatus(transaction.Id, transactionStatus);

            Assert.That(transaction.Status, Is.EqualTo(transactionStatus));
        }

        [Test]
        public void RemoveTransactionById_ThrowsException_WhenIdDoesNotExist()
        {
            this.chainblock.Add(this.CreateSimpleTransaction());

            Assert.Throws<InvalidOperationException>(() => this.chainblock.RemoveTransactionById(100));
        }

        [Test]
        public void RemoveTransaction_RemoveChainblockTransaction_WhenIdExists()
        {
            ITransaction transaction = this.CreateSimpleTransaction();

            this.chainblock.Add(transaction);
            this.chainblock.RemoveTransactionById(transaction.Id);

            Assert.That(this.chainblock.Count, Is.Zero);
            Assert.That(this.chainblock.Contains(transaction.Id), Is.False);
        }
        
        [Test]
        public void GetById_ThrowsException_WhenIdDoesNotExist()
        {
            ITransaction transaction = this.CreateSimpleTransaction();

            this.chainblock.Add(transaction);

            Assert.Throws<InvalidOperationException>(() => this.chainblock.GetById(transaction.Id + 1 ));
        }

        [Test]
        public void GetById_ReturnsExpectedTransaction_WhenIdExists()
        {
            ITransaction transaction = this.CreateSimpleTransaction();

            this.chainblock.Add(transaction);

            ITransaction chainblockTransaction = this.chainblock.GetById(transaction.Id);

            Assert.That(transaction, Is.EqualTo(transaction));
        }

        [Test]
        public void GetByTransactionStatus_ThrowsException_WhenThereAreNoTransactionWithStatus()
        {
            this.AddThreeTransactionWithDifferentStatus();

            Assert.Throws<InvalidOperationException>(() => 
            this.chainblock.GetByTransactionStatus(TransactionStatus.Unauthorized));
        }

        [Test]
        public void GetByTransactionStatus_ReturnsFilteredAndSortedData_WhenChainblockContainsTransactionsWithStatus()
        {
            this.AddBulkOfTransactions();

            TransactionStatus filterStatus = TransactionStatus.Successfull;

            List<ITransaction> expectedTransactions = this.chainblock
                                                    .Where(t => t.Status == filterStatus)
                                                    .OrderByDescending(t => t.Amount)
                                                    .ToList();

            List<ITransaction> actualTransactions = this.chainblock.GetByTransactionStatus(filterStatus).ToList();

            Assert.That(expectedTransactions, Is.EquivalentTo(actualTransactions));
        }

        [Test]
        public void GetAllSendersWithTransactionStatus_ThrowsExecption_WhenTransactionDoNotExistWithStatus()
        {
            this.AddThreeTransactionWithDifferentStatus();

            Assert.Throws<InvalidOperationException>(() =>
                            this.chainblock.GetAllSendersWithTransactionStatus(TransactionStatus.Unauthorized));
        }

        public void GetAllSendersWithTransactionStatus_ReturnsFilteredAndSortedData_WhenTransactionsExists()
        {
            this.AddBulkOfTransactions();

            TransactionStatus transactionStatus = TransactionStatus.Successfull;

            List<string> expected = this.chainblock
                                    .Where(t => t.Status == transactionStatus)
                                    .OrderBy(t => t.Amount)
                                    .Select(t => t.From)
                                    .ToList();

            List<string> actual = this.chainblock
                                .GetAllSendersWithTransactionStatus(transactionStatus)
                                .ToList();

            Assert.That(expected, Is.EquivalentTo(actual));
        }

        [Test]
        public void GetAllReceiversWithTransactionStatus_ThrowsException_WhenTransactionWithStatusDoNotExist()
        {
            this.AddThreeTransactionWithDifferentStatus();

            Assert.Throws<InvalidOperationException>(() => 
            this.chainblock.GetAllReceiversWithTransactionStatus(TransactionStatus.Unauthorized)); 
        }

        [Test]
        public void GetAllReceiversWithTransactionStatus_ReturnsFilteredAndSortedData_WhenTransactionWithStatusExist()
        {
            this.AddBulkOfTransactions();

            TransactionStatus transactionStatus = TransactionStatus.Successfull;

            List<string> expected = this.chainblock
                                    .Where(t => t.Status == transactionStatus)
                                    .OrderBy(t => t.Amount)
                                    .Select(t => t.To)
                                    .ToList();

            List<string> actual = this.chainblock.GetAllReceiversWithTransactionStatus(transactionStatus).ToList();

            Assert.That(expected, Is.EquivalentTo(actual));
        }

        public void GetAllOrderedByAmountDescendingThenById_ReturnsTransactionInExpectedOrder()
        {
            this.AddBulkOfTransactions();

            List<ITransaction> expected = this.chainblock
                                        .OrderByDescending(t => t.Amount)
                                        .ThenBy(t => t.Id)
                                        .ToList();

            List<ITransaction> actual = this.chainblock.GetAllOrderedByAmountDescendingThenById().ToList();

            Assert.That(expected, Is.EquivalentTo(actual));
        }

        [Test]
        public void GetBySenderOrderedByAmountDescending_ThrowsException_WhenThereAreNoTransactionBySender()
        {
            this.AddBulkOfTransactions();

            Assert.Throws<InvalidOperationException>(() =>
            this.chainblock.GetBySenderOrderedByAmountDescending("FakeSender"));
        }

        [Test]
        public void GetBySenderOrderedByAmountDescending_ReturnsFilteredAndSortedData()
        {
            this.AddBulkOfTransactions();

            string sender = this.chainblock.FirstOrDefault().From;

            List<ITransaction> expected = this.chainblock
                                        .Where(t => t.From == sender)
                                        .OrderByDescending(t => t.Amount)
                                        .ToList();

            List<ITransaction> actual = this.chainblock.GetBySenderOrderedByAmountDescending(sender).ToList();

            Assert.That(expected, Is.EquivalentTo(actual));
        }

        [Test]
        public void GetByReceiverOrderedByAmountThenById_ThrowsException_WhenReceiverDoesNotExist()
        {
            this.AddBulkOfTransactions();

            Assert.Throws<InvalidOperationException>(() =>
            this.chainblock.GetByReceiverOrderedByAmountThenById("FakeReceiver "));
        }

        [Test]
        public void GetByReceiverOrderedByAmountThenById_ReturnsFilteredAndSortedData()
        {
            this.AddBulkOfTransactions();

            string receiver = this.chainblock.FirstOrDefault().To;

            List<ITransaction> result = this.chainblock.GetByReceiverOrderedByAmountThenById(receiver).ToList();

            double prevAmount = double.PositiveInfinity;
            int id = 0;

            foreach (ITransaction transaction in result)
            {
                Assert.That(transaction.To, Is.EqualTo(receiver));
                Assert.That(transaction.Amount, Is.LessThanOrEqualTo(prevAmount));

                if (transaction.Amount == prevAmount)
                {
                    Assert.That(transaction.Id, Is.GreaterThan(id));
                }

                prevAmount = transaction.Amount;
                id = transaction.Id;
            }
        }

        private void AddBulkOfTransactions()
        {
            int n = 100;
            for (int i = 0; i <= n; i++)
            {
                TransactionStatus transactionStatus = TransactionStatus.Successfull;
                string from = "Jonh";
                string to = "Niki";

                if (i % 2 == 0)
                {
                    transactionStatus = TransactionStatus.Unauthorized;
                    from = "Ani";
                    to = "Dido";
                }
                else if (i % 3 == 0)
                {
                    transactionStatus = TransactionStatus.Aborted;
                    from = "Stoyan";
                    to = "Yoanna";
                }
                else if (i % 5 == 0)
                {
                    transactionStatus = TransactionStatus.Failed;
                    from = "Nasko";
                    to = "Ina";
                }

                double amount = i % 2 == 0 ? 100 : 100 + i;

                ITransaction transaction = new Transaction()
                {
                    Id = n - i,
                    Amount = amount,
                    From = from,
                    To = to,
                    Status = transactionStatus
                };

                this.chainblock.Add(transaction);
            }
        }

        private void AddThreeTransactionWithDifferentStatus()
        {
            this.chainblock.Add(new Transaction()
            {
                Id = 1,
                From = "firstTransaction",
                To = "firstTransaction",
                Amount = 11.00,
                Status = TransactionStatus.Successfull
            });

            this.chainblock.Add(new Transaction()
            {
                Id = 2,
                From = "secondTransaction",
                To = "secondTransaction",
                Amount = 22.00,
                Status = TransactionStatus.Failed
            });

            this.chainblock.Add(new Transaction()
            {
                Id = 3,
                From = "secondTransaction",
                To = "secondTransaction",
                Amount = 33.00,
                Status = TransactionStatus.Aborted
            });
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

            Assert.That(this.firstChainblock.Count, Is.EqualTo(1));
            Assert.That(this.firstChainblock.Contains(this.transaction.Id));
        }

        [Test]
        public void AddMethodCannotAddExistingTransaction()
        {
            this.firstChainblock.Add(this.transaction);

            Assert.That(this.firstChainblock.Count, Is.EqualTo(1));
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

            Assert.That(this.firstChainblock.Contains(this.transaction), Is.EqualTo(true));
        }

        [Test]
        public void ContainsMethodShouldReturnFalseWhenItDoesNotFindTransaction()
        {

            Assert.That(this.firstChainblock.Contains(this.secondTransaction), Is.EqualTo(false));
        }

        [Test]
        public void ContainsMethodShouldReturnTrueWhenFindTransactionId()
        {
            Assert.That(this.firstChainblock.Contains(this.transaction.Id), Is.EqualTo(true));
        }

        [Test]
        public void ContainsMethodShouldReturnFalseWhenItDoesNotFindTransactionId()
        {
            Assert.That(this.firstChainblock.Contains(this.secondTransaction), Is.EqualTo(false));
        }

        [Test]
        public void CountPropertyShouldReturnCorrecntNumberOfTransaction()
        {
            Assert.That(this.firstChainblock.Count, Is.EqualTo(1));

            this.firstChainblock.Add(this.secondTransaction);

            Assert.That(this.firstChainblock.Count, Is.EqualTo(2));
        }

        [Test]
        public void ChangeTransactionStatusMethodShouldChangeTransactionStatus()
        {
            this.firstChainblock.ChangeTransactionStatus(this.transaction.Id, TransactionStatus.Failed);

            Assert.That(this.transaction.Status, Is.EqualTo(TransactionStatus.Failed));
        }

        [Test]
        public void ChangeTransactionStatusMethodShouldReturnExceptionWhenTransactionDoesNotExist()
        {
            Assert.Throws<ArgumentException>(
            () => this.firstChainblock.ChangeTransactionStatus(this.secondTransaction.Id, TransactionStatus.Aborted));
        }

        [Test]
        public void RemoveTransactionByIdMethodShouldRemoveTranaction()
        {
            this.firstChainblock.RemoveTransactionById(this.transaction.Id);

            Assert.That(this.firstChainblock.Contains(this.transaction.Id), Is.EqualTo(false));
            Assert.That(this.firstChainblock.Count, Is.EqualTo(0));
        }

        [Test]
        public void RemoveTransactionByIdMethodShouldReturnExceptionWhenTransactionDoesNotExist()
        {
            Assert.Throws<InvalidOperationException>(
            () => this.firstChainblock.RemoveTransactionById(this.secondTransaction.Id));
        }

        [Test]
        public void GetByIdMethodShouldReturnTransanction()
        {
            ITransaction expectedTransaction = this.firstChainblock.GetById(this.transaction.Id);

            Assert.True(expectedTransaction.Equals(this.transaction));
        }

        [Test]
        public void GetByIdMethodShouldReturnExceptionWhenTransactionDoesNotExist()
        {
            Assert.Throws<InvalidOperationException>(
                () => this.firstChainblock.GetById(this.secondTransaction.Id));
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

            this.firstChainblock.Add(testTransaction);

            IEnumerable<ITransaction> actualTransactions = this.firstChainblock.GetByTransactionStatus
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
            () => this.firstChainblock.GetByTransactionStatus(TransactionStatus.Unauthorized));
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

            this.firstChainblock.Add(testTransaction);

            IEnumerable<string> actualResult =
                this.firstChainblock.GetAllSendersWithTransactionStatus(transactionStatusSuccessfull);

            IEnumerable<string> expectedResult = new List<string>() { this.transaction.From, testTransaction.From };

            Assert.That(actualResult, Is.EquivalentTo(expectedResult));
        }

        [Test]
        public void  GetAllSendersWithTransactionStatusShouldReturnException()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                this.firstChainblock.GetAllSendersWithTransactionStatus(TransactionStatus.Unauthorized);
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

            this.firstChainblock.Add(firstTestTransaction);
            this.firstChainblock.Add(secondTestTransaction);

            IEnumerable<string> actualResult = 
            this.firstChainblock.GetAllReceiversWithTransactionStatus(transactionStatusFailed);

            IEnumerable<string> expectedResult = new List<string>()
            { firstTestTransaction.To, secondTestTransaction.To};

            Assert.That(actualResult, Is.EquivalentTo(expectedResult));
        }

        [Test]
        public void GetAllReceiversWithTransactionStatusShouldReturnExceptionWhenTransactionStatusDoesNotExist()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                this.firstChainblock.GetAllReceiversWithTransactionStatus(TransactionStatus.Aborted);
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

            IEnumerable<ITransaction> actualResult = this.firstChainblock.GetAllOrderedByAmountDescendingThenById();

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

            this.firstChainblock.Add(firstTestTransaction);
            this.firstChainblock.Add(secondTestTransaction);

            IEnumerable<ITransaction> actualResult =
                this.firstChainblock.GetBySenderOrderedByAmountDescending(this.transaction.From);

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

            this.firstChainblock.Add(firstTestTransaction);
            this.firstChainblock.Add(secondTestTransaction);

            Assert.Throws<InvalidOperationException>(() =>
            {
                this.firstChainblock.GetBySenderOrderedByAmountDescending("DontExist");
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

            this.firstChainblock.Add(firstTestTransaction);
            this.firstChainblock.Add(secondTestTransaction);

            IEnumerable<ITransaction> actualResult =
                this.firstChainblock.GetByReceiverOrderedByAmountThenById(this.transaction.To);

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

            this.firstChainblock.Add(firstTestTransaction);
            this.firstChainblock.Add(secondTestTransaction);

            Assert.Throws<InvalidOperationException>(() =>
            {
                this.firstChainblock.GetBySenderOrderedByAmountDescending("NotExistReceiver");
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

            this.firstChainblock.Add(firstTestTransaction);
            this.firstChainblock.Add(secondTestTransaction);

            double maxAmount = 214;

            IEnumerable<ITransaction> actualResult =
                this.firstChainblock.GetByTransactionStatusAndMaximumAmount(this.transaction.Status, maxAmount);

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

            this.firstChainblock.Add(firstTestTransaction);
            this.firstChainblock.Add(secondTestTransaction);

            double minAmount = 100;

            Assert.Throws<InvalidOperationException>(() =>
            {
                this.firstChainblock.GetBySenderAndMinimumAmountDescending("FakeSender", minAmount);
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

            this.firstChainblock.Add(firstTestTransaction);
            this.firstChainblock.Add(secondTestTransaction);

            double minAmount = 100;

            IEnumerable<ITransaction> actualResult =
                this.firstChainblock.GetBySenderAndMinimumAmountDescending(this.transaction.From, minAmount);

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

            this.firstChainblock.Add(firstTestTransaction);
            this.firstChainblock.Add(secondTestTransaction);

            double amountMin = 100;
            double amountMax = 250;

            Assert.Throws<InvalidOperationException>(() => 
            this.firstChainblock.GetByReceiverAndAmountRange(this.transaction.To, amountMin, amountMax));

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

            this.firstChainblock.Add(firstTestTransaction);
            this.firstChainblock.Add(secondTestTransaction);

            double amountMin = 10;
            double amountMax = 25;

            IEnumerable<ITransaction> actualTransactions =
                this.firstChainblock.GetByReceiverAndAmountRange(this.transaction.To, amountMin, amountMax);

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

            this.firstChainblock.Add(firstTestTransaction);
            this.firstChainblock.Add(secondTestTransaction);

            double amountMin = 10;
            double amountMax = 30;

            IEnumerable<ITransaction> actualResult = this.firstChainblock.GetAllInAmountRange(amountMin, amountMax);
            IEnumerable<ITransaction> expectedResult = 
            new List<ITransaction>() { firstTestTransaction, secondTestTransaction};

            Assert.That(actualResult, Is.EquivalentTo(expectedResult));

            actualResult = this.firstChainblock.GetAllInAmountRange(50, 100);

            Assert.That(actualResult.Count(), Is.EqualTo(0));
        }
    }
}
