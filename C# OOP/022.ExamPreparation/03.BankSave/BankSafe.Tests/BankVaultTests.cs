using NUnit.Framework;
using System;

namespace BankSafe.Tests
{
    public class BankVaultTests
    {
        BankVault bankVault;
        Item item;
        [SetUp]
        public void Setup()
        {
            this.bankVault = new BankVault();
            this.item = new Item("Koki", "111");
        }

        // My code
        [Test]
        public void BankVault_AddItem()
        {
            string cell = "A1";
            this.bankVault.AddItem(cell, this.item);

            Assert.That(this.bankVault.VaultCells[cell], Is.EqualTo(this.item));
            Assert.That(this.bankVault.VaultCells[cell], Is.Not.Null);
        }

        [Test]
        public void BankVault_AddSameItem()
        {
            string cell = "A1";
            this.bankVault.AddItem(cell, this.item);

            cell = "A2";

            Assert.Throws<InvalidOperationException>( () => this.bankVault.AddItem(cell, this.item));
        }

        [Test]
        public void BankVault_AddItemInSameCell()
        {
            string cell = "A1";
            this.bankVault.AddItem(cell, this.item);

            Assert.Throws<ArgumentException>(() => this.bankVault.AddItem(cell, this.item));
        }

        [Test]
        public void BankVault_CurrentCellDontExist()
        {
            string cell = "Z1";

            Assert.Throws<ArgumentException>(() => this.bankVault.AddItem(cell, this.item));
        }


        [Test]
        public void BankVault_RemoveItem()
        {
            string cell = "A1";
            this.bankVault.AddItem(cell, this.item);

            this.bankVault.RemoveItem(cell, this.item);
            Assert.That(this.bankVault.VaultCells[cell], Is.Null);
        }

        [Test]
        public void BankVault_CurrentItemDoestExistInCurrentCell()
        {
            string cell = "A1";
            this.bankVault.AddItem(cell, this.item);

            Item newItem = new Item("Ivan", "222");

            string newCel = "A2";
            this.bankVault.AddItem(newCel, newItem);

            Assert.Throws<ArgumentException>(() => this.bankVault.RemoveItem(cell, newItem));
        }


        [Test]
        public void BankVault_CurrentCellDoestExist()
        {
            string cell = "A1";
            this.bankVault.AddItem(cell, this.item);

            Item newItem = new Item("Ivan", "222");

            string newCel = "A2";
            this.bankVault.AddItem(newCel, newItem);

            string wrongCell = "Z1";

            Assert.Throws<ArgumentException>(() => this.bankVault.RemoveItem(wrongCell, newItem));
        }

        //Code from the lecture
        [Test]
        public void WhenCellDoesntNotExist_ShouldThrowExecption()
        {
            Exception exception = Assert.Throws<ArgumentException>(() =>
            {
                this.bankVault.AddItem("Z!", this.item);
            });

            Assert.AreEqual(exception.Message, "Cell doesn't exists!");
        }

        [Test]
        public void WhenCellIsAlreadyTaken_ShouldThrowExecption()
        {
            Exception exception = Assert.Throws<ArgumentException>(() =>
            {
                this.bankVault.AddItem("A2", this.item);
                this.bankVault.AddItem("A2", new Item("Owner", "333"));
            });

            Assert.AreEqual(exception.Message, "Cell is already taken!");
        }

        [Test]
        public void WhenItemIsAdded_ShouldReturnCorrectMessage()
        {       
            string result = this.bankVault.AddItem("A2", this.item);

            Assert.AreEqual(result, $"Item:{this.item.ItemId} saved successfully!");
        }

        [Test]
        public void WhenItemIsAdded_ShouldSetItemToCell()
        {
            this.bankVault.AddItem("A2", this.item);

            //Item currentItem = this.bankVault.VaultCells["A2"];

            Assert.AreEqual(this.item, this.bankVault.VaultCells["A2"]);
        }

        [Test]
        public void WhenRemoveCellAndCellDoesntNotExist_ShouldThrowExecption()
        {
            Exception exception = Assert.Throws<ArgumentException>(() =>
            {
                this.bankVault.RemoveItem("Z!", this.item);
            });

            Assert.AreEqual(exception.Message, "Cell doesn't exists!");
        }

        [Test]
        public void WhenRemoveCellAndItemDoesntNotExist_ShouldThrowExecption()
        {
            Exception exception = Assert.Throws<ArgumentException>(() =>
            {
                this.bankVault.RemoveItem("A2", this.item);
            });

            Assert.AreEqual(exception.Message, "Item in that cell doesn't exists!");
        }


        [Test]
        public void WhenItemIsRemoved_ShouldReturnCorrectMessage()
        {
            this.bankVault.AddItem("A2", this.item);

            string result = this.bankVault.RemoveItem("A2", this.item);

            Assert.AreEqual(result, $"Remove item:{item.ItemId} successfully!");
        }

        [Test]
        public void WhenItemIsRemoved_ShouldMakeTheCellNull()
        {
            this.bankVault.AddItem("A2", this.item);

            //Item currentItem = this.bankVault.VaultCells["A2"];

            string result = this.bankVault.RemoveItem("A2", this.item);

            Assert.AreEqual(null, this.bankVault.VaultCells["A2"]);
        }
    }
}