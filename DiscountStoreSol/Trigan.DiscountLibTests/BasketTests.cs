using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using Trigan.DiscountLib.Interfaces;

namespace Trigan.DiscountLib.Tests
{
    [ExcludeFromCodeCoverage]
    [TestClass()]
    public class BasketTests
    {
        [TestMethod()]
        public void AddTest()
        {
            IBasket basket = new Basket();

            basket.Add(new Item { Id = 100, Name = "Big mug", Price = 1.5m });
            basket.Add(new Item { Id = 100, Name = "Big mug", Price = 1.5m }, 0);
            basket.Add(new Item { Id = 100, Name = "Big mug", Price = 1.5m }, 5);

            int expectedCount = 1;
            int expectedItemCount = 6;

            Assert.AreEqual(expectedCount, basket.GetBasketItems().Count());
            Assert.AreEqual(expectedItemCount, basket.GetBasketItems().First().Value);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void AddErrorTest()
        {
            IBasket basket = new Basket();

            basket.Add(new Item { Id = 100, Name = "Big mug", Price = 1.5m });
            basket.Add(new Item { Id = 100, Name = "Big mug", Price = 1.5m }, -2);

        }

        [TestMethod()]
        public void AddToZeroTest()
        {
            IBasket basket = new Basket();

            basket.Add(new Item { Id = 100, Name = "Big mug", Price = 1.5m });
            basket.Remove(new Item { Id = 100, Name = "Big mug", Price = 1.5m }, 2);
            basket.Add(new Item { Id = 100, Name = "Big mug", Price = 1.5m });

            int expectedCount = 0;

            Assert.AreEqual(expectedCount, basket.GetBasketItems().Count());
        }

        [TestMethod()]
        public void RemoveToNegativeTest()
        {
            IBasket basket = new Basket();

            basket.Add(new Item { Id = 100, Name = "Big mug", Price = 1.5m });
            basket.Remove(new Item { Id = 100, Name = "Big mug", Price = 1.5m }, 2);

            int expectedCount = 1;
            int expectedValue = -1;

            Assert.AreEqual(expectedCount, basket.GetBasketItems().Count());
            Assert.AreEqual(expectedValue, basket.GetBasketItems().First().Value);
        }

        [TestMethod()]
        public void RemoveTest()
        {
            IBasket basket = new Basket();

            basket.Add(new Item { Id = 100, Name = "Big mug", Price = 1.5m }, 5);
            basket.Remove(new Item { Id = 100, Name = "Big mug", Price = 1.5m }, 2);
            basket.Remove(new Item { Id = 100, Name = "Big mug", Price = 1.5m }, 0);
            basket.Remove(new Item { Id = 100, Name = "Big mug", Price = 1.5m }, 3);

            int expectedCount = 0;

            Assert.AreEqual(expectedCount, basket.GetBasketItems().Count());
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void RemoveErrorTest()
        {
            IBasket basket = new Basket();

            basket.Add(new Item { Id = 100, Name = "Big mug", Price = 1.5m }, 5);
            basket.Remove(new Item { Id = 100, Name = "Big mug", Price = 1.5m }, -3);
        }
    }
}