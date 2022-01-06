using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using Trigan.DiscountLib.Interfaces;

namespace Trigan.DiscountLib.Tests
{
    [ExcludeFromCodeCoverage]
    [TestClass()]
    public class TotalPriceForBasketServiceTests
    {
        private IItem vase = new Item() { Id = 90, Name = "Vase", Price = 1.2m };
        private IItem bigMug = new Item() { Id = 100, Name = "Big mug", Price = 1.0m };
        private IItem napkinsPack = new Item() { Id = 110, Name = "Napkins pack", Price = 0.45m };
        private IDiscountMaker discount = new BuyXForDiscount();

        [TestMethod()]
        public void GetTotalTest()
        {
            IBasket basket = new Basket();

            IItem bigMug2 = new Item() { Id = 100, Name = "Big mug", Price = 1.0m };

            basket.Add(vase);
            basket.Add(bigMug);
            basket.Add(napkinsPack, 3);
            basket.Add(bigMug2);

            ITotalPriceForBasket service = new TotalPriceForBasketService();
            service.AddDiscountMaker(discount);

            decimal price = service.GetTotal(basket);
            decimal expectedPrice = 3.6m;

            Assert.AreEqual(expectedPrice, price);
        }

        [TestMethod()]
        public void GetTotalTest2()
        {
            IBasket basket = new Basket();

            basket.Add(vase);
            basket.Add(bigMug, 5);
            basket.Add(napkinsPack, 8);

            ITotalPriceForBasket service = new TotalPriceForBasketService();
            service.AddDiscountMaker(discount);

            decimal price = service.GetTotal(basket);
            decimal expectedPrice = 7.9m;

            Assert.AreEqual(expectedPrice, price);
        }

        [TestMethod()]
        public void CheckTotalTest()
        {
            IBasket basket = new Basket();

            basket.Add(vase);
            basket.Add(bigMug, 5);
            basket.Add(napkinsPack, 8);

            ITotalPriceForBasket service = new TotalPriceForBasketService();
            service.AddDiscountMaker(discount);

            decimal price = service.CheckTotal(basket);
            decimal expectedPrice = 7.9m;
            int expectedCount = 3;

            Assert.AreEqual(expectedPrice, price);
            Assert.AreEqual(expectedCount, basket.GetBasketItems().Count());
        }
    }
}