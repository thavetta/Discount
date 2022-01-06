using Microsoft.VisualStudio.TestTools.UnitTesting;
using Trigan.DiscountLib;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trigan.DiscountLib.Interfaces;

namespace Trigan.DiscountLib.Tests;

[ExcludeFromCodeCoverage]
[TestClass()]
public class BuyXForDiscountTests
{
    private IItem vase = new Item() { Id = 90, Name = "Vase", Price = 1.2m };
    private IItem bigMug = new Item() { Id = 100, Name = "Big mug", Price = 1.0m };
    private IItem napkinsPack = new Item() { Id = 110, Name = "Napkins pack", Price = 0.45m };

    [TestMethod()]
    public void GetDiscountTest()
    {
        IBasket basket = new Basket();
        basket.Add(vase,2);
        basket.Add(bigMug, 5);
        basket.Add(napkinsPack,10);
        IDiscountMaker discountMaker = new BuyXForDiscount();

        discountMaker.GetDiscount(basket);

        int expectedCount = 5;
        int expectedValue = 3;

        Assert.AreEqual(expectedCount,basket.GetBasketItems().Count());
        Assert.AreEqual(expectedValue,basket.GetBasketItems().First(x => x.Key.Id == 10110).Value);
    }
}