namespace INStock.Tests
{
    using System;
    using System.Collections.Generic;
    using INStock.Contracts;
    using INStock.Fake;
    using Moq;
    using NUnit.Framework;
    using NUnit.Framework.Constraints;

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

        Market market;

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

            this.market = new Market(this.mockProductStock.Object);

            // Fake product and fake productStock
            this.fakeProductStock = new FakeProductStockSystem();
            this.fakeProduct = new FakeProduct(this.productLabel, this.productPrice, this.productQuantity);

            // Fake SetUp
            this.fakeProductStock.Add(this.fakeProduct);

            // Mock SetUp
            //this.mockProductStock.Setup(ps => ps.Add(It.IsAny<IProduct>()))
            //        .Callback(() =>
            //        {
            //            this.mockProductStock.Object.Add(this.mockProduct.Object);
            //        });

            //this.mockProductStock.Setup(ps => ps.Contains(this.mockProduct.Object)).Returns(true);

            //this.mockProductStock.Setup(ps => ps.Count).Returns(1);

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

        //Mock tests

        [Test]
        public void MockCountPropertyShouldReturnCountOfProduct()
        {
            this.mockProductStock.Setup(ps => ps.Count).Returns(10);

            Assert.That(this.market.CurrentProductCount(), Is.EqualTo(10));
        }

        [Test]
        public void MockGetProductByIndex()
        {
            int index = 0;
            this.mockProductStock.Setup(ps => ps[index]).Throws(new ArgumentOutOfRangeException());


            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                IProduct product = this.market[index];
            });

            index = 1;
            this.mockProductStock.Setup(ps => ps[index]).Returns(this.mockProduct.Object);

            Assert.That(this.mockProductStock.Object[index], Is.EqualTo(this.mockProduct.Object));
        }

        [Test]
        public void MockContainsMethodShouldReturnTrue()
        {
            this.mockProductStock.Setup(ps => ps.Contains(this.mockProduct.Object)).Returns(true);

            Assert.That(this.mockProductStock.Object.Contains(this.mockProduct.Object), Is.EqualTo(true));

            Assert.That(this.mockProductStock.Object.Contains(this.secondProduct.Object), Is.EqualTo(false));
        }

        [Test]
        public void MockAddMethodShouldAddProduct()
        {
            this.mockProductStock.Object.Add(this.mockProduct.Object);

            this.mockProductStock.Verify(ps => ps.Add(this.mockProduct.Object), Times.Once);

            this.mockProductStock.Setup(ps => ps.Add(It.IsAny<IProduct>()))
                                    .Callback(() =>
                                    {
                                        this.mockProductStock.Setup(ps => ps.Count).Returns(10);

                                    });

            this.mockProductStock.Object.Add(this.mockProduct.Object);

            Assert.That(this.mockProductStock.Object.Count, Is.EqualTo(10));
        }

        [Test]
        public void MockRemoveMethodShouldRemoveProduct()
        {
            this.mockProductStock.Object.Remove(this.mockProduct.Object);

            this.mockProductStock.Verify(ps => ps.Remove(this.mockProduct.Object), Times.Once);

            this.mockProductStock.Setup(ps => ps.Remove(It.IsAny<IProduct>()))
                        .Callback(() =>
                        {
                            this.mockProductStock.Setup(ps => ps.Count).Returns(9);

                        });

            this.mockProductStock.Object.Remove(this.thirdProduct.Object);

            Assert.That(this.mockProductStock.Object.Count, Is.EqualTo(9));
        }

        [Test]
        public void MockFindMethodShouldFindProduct()
        {
            int index = 0;
            this.mockProductStock.Setup(ps => ps.Find(index)).Returns(this.mockProduct.Object);

            Assert.That(this.mockProductStock.Object.Find(index), Is.EqualTo(this.mockProduct.Object));

            index = 100;
            Assert.That(this.mockProductStock.Object.Find(index), Is.EqualTo(null));
        }

        [Test]
        public void MockFindByLabelShouldFindProductByLabel()
        {
            this.mockProductStock.Setup(ps => ps.FindByLabel(this.productLabel)).Returns(this.mockProduct.Object);

            Assert.That(this.mockProductStock.Object.FindByLabel(this.productLabel), 
                Is.EqualTo(this.mockProduct.Object));

            string testLabel = "NoLabel";
            Assert.That(this.mockProductStock.Object.FindByLabel(testLabel), Is.EqualTo(null));
        }

        [Test]
        public void MockFindMostExpensiveProductShouldReturnProduct()
        {
            this.mockProductStock.Setup(ps => ps.FindMostExpensiveProduct()).Returns(this.mockProduct.Object);

            Assert.That(this.mockProductStock.Object.FindMostExpensiveProduct(),
                Is.EqualTo(this.mockProduct.Object));
        }

        [Test]
        public void MockFindAllInRangeShouldReturnAllProductInRange()
        {
            this.mockProductStock.Setup(ps => ps.FindAllInRange(100, 400))
                .Returns(new List<IProduct>() { this.secondProduct.Object, this.thirdProduct.Object });

            List<IProduct> products = new List<IProduct>()
            { this.secondProduct.Object, this.thirdProduct.Object};

            Assert.That(this.mockProductStock.Object.FindAllInRange(100, 400), Is.EqualTo(products));

            List<IProduct> emptyCollection = new List<IProduct>();

            Assert.That(this.mockProductStock.Object.FindAllInRange(10, 40), Is.EqualTo(emptyCollection));
        }

        [Test]
        public void MockFindAllByPriceAhouldFindAllProductByPrice()
        {
            Mock<IProduct> samePriceProduct = new Mock<IProduct>();
            samePriceProduct.Setup(p => p.Label).Returns("sameProductLabel");
            samePriceProduct.Setup(p => p.Price).Returns(123M);
            samePriceProduct.Setup(p => p.Quantity).Returns(21);

            this.mockProductStock.Setup(ps => ps.FindAllByPrice(123))
                .Returns(new List<IProduct>() { this.secondProduct.Object, samePriceProduct.Object });

            List<IProduct> products = new List<IProduct>()
            { this.secondProduct.Object, samePriceProduct.Object};

            Assert.That(this.mockProductStock.Object.FindAllByPrice(123), Is.EqualTo(products));

            List<IProduct> emptyCollection = new List<IProduct>();

            Assert.That(this.mockProductStock.Object.FindAllByPrice(300), Is.EqualTo(emptyCollection));
        }

        [Test]
        public void MockFindAllByQuantityShouldReturnAllProductByQuantity()
        {
            Mock<IProduct> samePriceProduct = new Mock<IProduct>();
            samePriceProduct.Setup(p => p.Label).Returns("sameProductLabel");
            samePriceProduct.Setup(p => p.Price).Returns(123M);
            samePriceProduct.Setup(p => p.Quantity).Returns(21);

            this.mockProductStock.Setup(ps => ps.FindAllByQuantity(21))
                .Returns(new List<IProduct>() { this.secondProduct.Object, samePriceProduct.Object });

            List<IProduct> products = new List<IProduct>()
            { this.secondProduct.Object, samePriceProduct.Object};

            Assert.That(this.mockProductStock.Object.FindAllByQuantity(21), Is.EqualTo(products));

            List<IProduct> emptyCollection = new List<IProduct>();

            Assert.That(this.mockProductStock.Object.FindAllByQuantity(4), Is.EqualTo(emptyCollection));
        }
    }
}
