namespace INStock.Tests
{
    using System;
    using System.Collections.Generic;
    using INStock.Contracts;
    using INStock.Fake;
    using Moq;
    using NUnit.Framework;
    [TestFixture]
    public class ProductStockTests
    {
        string productLabel = "TestLabel";
        decimal productPrice = 11111;
        int productQuantity = 111;

        FakeProductStockSystem fakeProductStock;
        FakeProduct fakeProduct;

        Mock<IProduct> secondProduct;
        Mock<IProduct> thirdProduct;
        Mock<IProduct> mockProduct;
        Mock<IProductStock> mockProductStock;
        [SetUp]
        public void Setup()
        {
            // Mock products
            mockProduct = new Mock<IProduct>();
            mockProduct.Setup(l => l.Label).Returns(productLabel);
            mockProduct.Setup(p => p.Price).Returns(11111M);
            mockProduct.Setup(q => q.Quantity).Returns(111);

            this.secondProduct = new Mock<IProduct>();
            this.secondProduct.Setup(l => l.Label).Returns("SecondProduct");
            this.secondProduct.Setup(p => p.Price).Returns(123M);
            this.secondProduct.Setup(q => q.Quantity).Returns(21);

            this.thirdProduct = new Mock<IProduct>();
            this.thirdProduct.Setup(l => l.Label).Returns("ThirdProduct");
            this.thirdProduct.Setup(p => p.Price).Returns(333M);
            this.thirdProduct.Setup(q => q.Quantity).Returns(33);
            this.mockProductStock = new Mock<IProductStock>();

            // Fake product and fake productStock
            this.fakeProductStock = new FakeProductStockSystem();
            this.fakeProduct = new FakeProduct(this.productLabel, this.productPrice, this.productQuantity);

            // Fake SetUp
            this.fakeProductStock.Add(this.fakeProduct);

            // Mock SetUp
            this.mockProductStock.Setup(ps => ps.Add(It.IsAny<IProduct>()))
                    .Callback(() =>
                    {
                        this.mockProductStock.Object.Add(this.mockProduct.Object);
                    });

            this.mockProductStock.Setup(ps => ps.Contains(this.mockProduct.Object)).Returns(true);

            this.mockProductStock.Setup(ps => ps.Count).Returns(1);

            //this.mockProductStock.Setup(ps => ps[It.IsAny<int>()]).Returns(this.mockProduct.Object);

            //this.mockProductStock.Setup(ps => ps.Find(1)).Returns(this.mockProduct.Object);

            //this.mockProductStock.Setup(ps => ps.FindByLabel(productLabel)).Returns(this.mockProduct.Object);

            //this.mockProductStock.Setup(ps => ps.FindMostExpensiveProduct()).Returns(this.mockProduct.Object);

            //this.mockProductStock.Setup(ps => ps.FindAllInRange(123, 333))
            //    .Returns(() =>
            //{
            //    new List<IProduct>()
            //    {  this.mockProduct.Object, this.secondProduct.Object, this.thirdProduct.Object};
            //});

            //this.mockProductStock.Setup(ps => ps.FindAllByPrice(this.productPrice))
            //    .Returns(() =>
            //    {
            //        new List<IProduct> { this.mockProduct.Object };
            //    });

            //this.mockProductStock.Setup(ps => ps.FindAllByQuantity(this.productQuantity))
            //    .Returns(() =>
            //    {
            //        new List<IProduct> { this.mockProduct.Object };
            //    });
        }

        [Test]
        public void FakeAddMethodShouldAddProduct()
        {

            Assert.That(this.fakeProductStock.Count, Is.EqualTo(1));
        }

        [Test]
        public void FakeContainsMethodShouldReturnTrue()
        {

            Assert.That(this.fakeProductStock.Contains(this.fakeProduct), Is.EqualTo(true));
        }

        [Test]
        public void FakeRemoveMethodShouldRemoveProduct()
        {
            this.fakeProductStock.Remove(this.fakeProduct);

            Assert.That(this.fakeProductStock.Count, Is.EqualTo(0));
        }

        [Test]
        public void FakeFindMethodShouldFindFakeProduct()
        {
            Assert.That(this.fakeProductStock.Find(0), Is.EqualTo(this.fakeProduct));
        }

        [Test]
        public void FakeFindByLabelMethodShouldFindFakeProduct()
        {
            Assert.That(this.fakeProductStock.FindByLabel(this.productLabel), Is.EqualTo(this.fakeProduct));
        }

        public void FakeFindMostExpensiveProductShouldFindFakeProduct()
        {
            IProduct product = new FakeProduct("FakePoductLabel", 1234M, 13);
            this.fakeProductStock.Add(product);

            Assert.That(this.fakeProductStock.FindMostExpensiveProduct(), Is.EqualTo(this.fakeProduct));
        }

        [Test]
        public void FakeFindAllInRangeMehodShouldReturntAllProductInRange()
        {
            IProduct firstProduct = new FakeProduct("FakePoductLabel", 21M, 13);
            IProduct secondProduct = new FakeProduct("FakePoductLabel", 9M, 13);
            this.fakeProductStock.Add(firstProduct);
            this.fakeProductStock.Add(secondProduct);

            IEnumerable<IProduct> products = new List<IProduct>() { firstProduct, secondProduct };

            Assert.That(this.fakeProductStock.FindAllInRange(5, 25), Is.EqualTo(products));
        }

        [Test]
        public void FakeFindAllByPriceMethodShouldFindAllProductByPrice()
        {
            IProduct firstProduct = new FakeProduct("FakePoductLabel", 21M, 13);
            IProduct secondProduct = new FakeProduct("FakePoductLabel", 21M, 13);
            this.fakeProductStock.Add(firstProduct);
            this.fakeProductStock.Add(secondProduct);

            IEnumerable<IProduct> products = new List<IProduct>() { firstProduct, secondProduct };

            Assert.That(this.fakeProductStock.FindAllByPrice(21),
            Is.EqualTo(products));

        }

        [Test]
        public void FakeFindAllByQuantityMethodShouldFindAllProductByQuantity()
        {
            IProduct firstProduct = new FakeProduct("FakePoductLabel", 21M, 13);
            IProduct secondProduct = new FakeProduct("FakePoductLabel", 21M, 13);
            this.fakeProductStock.Add(firstProduct);
            this.fakeProductStock.Add(secondProduct);

            IEnumerable<IProduct> products = new List<IProduct>() { firstProduct, secondProduct };

            Assert.That(this.fakeProductStock.FindAllByQuantity(13),
            Is.EqualTo(products));

        }

        [Test]
        public void FakeCountShouldReturnZero()
        {
            this.fakeProductStock.Remove(this.fakeProduct);

            Assert.That(this.fakeProductStock.Count, Is.EqualTo(0));
        }
        
        [Test]
        public void FakeIndexShouldReturnFakeProduct()
        {
            Assert.That(this.fakeProductStock[0], Is.EqualTo(this.fakeProduct));
        }
    }
}
