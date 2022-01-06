namespace Trigan.DiscountLib.Interfaces;

/// <summary>
/// Interface for service to calculate or check Total for the basket
/// </summary>
public interface ITotalPriceForBasket
{
    /// <summary>
    /// Method to change basket and calculate new total with discount makers
    /// </summary>
    /// <param name="basket">basket to calculate</param>
    /// <returns>total for basket after all discounts</returns>
    decimal GetTotal(IBasket basket);

    /// <summary>
    /// Method to only calculate total with discount makers, but the basket remains without change
    /// </summary>
    /// <param name="basket">basket to calculate</param>
    /// <returns>total for basket after all discounts</returns>
    decimal CheckTotal(IBasket basket);

    /// <summary>
    /// Method to add new class to provide discount algoritmus
    /// </summary>
    /// <param name="discountMaker">discount maker</param>
    void AddDiscountMaker(IDiscountMaker discountMaker);

    /// <summary>
    /// Method to remove class provided discount algoritmus
    /// </summary>
    /// <param name="discountMaker">discount maker</param>
    void RemoveDiscountMaker(IDiscountMaker discountMaker);
}