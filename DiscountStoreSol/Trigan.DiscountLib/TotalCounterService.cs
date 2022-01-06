using Trigan.DiscountLib.Interfaces;

namespace Trigan.DiscountLib;

/// <summary>
/// Main service to calculate Total for the basket.
/// </summary>
public class TotalPriceForBasketService : ITotalPriceForBasket
{
    private readonly List<IDiscountMaker> discountMakers = new();

    /// <summary>
    /// Method to calculate discounts and change basket (add new Items to realize discount)
    /// </summary>
    /// <param name="basket">basket for count</param>
    /// <returns>total with all discounts</returns>
    public decimal GetTotal(IBasket basket)
    {
        foreach (var discountMaker in discountMakers)
        {
            discountMaker.GetDiscount(basket);
        }

        return basket.GetBasketItems().Sum(x => x.Key.Price * x.Value);
    }
    /// <summary>
    /// Method to calculate discounts but not change basket. This method only returns total, for example for info panel.
    /// </summary>
    /// <param name="basket">basket to count</param>
    /// <returns>total with all discounts</returns>
    public decimal CheckTotal(IBasket basket)
    {
        IBasket basketToCheck = new Basket();

        foreach (var basketItem in basket.GetBasketItems())
        {
            basketToCheck.Add(basketItem.Key, basketItem.Value);
        }

        return GetTotal(basketToCheck);
    }

    /// <summary>
    /// Method to add new class to provide discount algoritmus
    /// </summary>
    /// <param name="discountMaker">discount maker</param>
    public void AddDiscountMaker(IDiscountMaker discountMaker)
    {
        if (!discountMakers.Contains(discountMaker))
            discountMakers.Add(discountMaker);
    }

    /// <summary>
    /// Method to remove class provided discount algoritmus
    /// </summary>
    /// <param name="discountMaker">discount maker</param>
    public void RemoveDiscountMaker(IDiscountMaker discountMaker)
    {
        discountMakers.Remove(discountMaker);
    }
}