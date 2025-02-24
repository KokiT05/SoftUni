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

        public void WhenCellDoesntNotExist_ShouldThrowExecption()
        {
            Exception exception = Assert.Throws<ArgumentException>(() =>
            {
                this.bankVault.AddItem("Z!", this.item);
            });

            Assert.AreEqual(exception.Message, "Cell doesn't exists!");
        }
    }
}