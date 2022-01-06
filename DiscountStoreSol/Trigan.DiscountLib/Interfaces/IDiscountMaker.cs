namespace Trigan.DiscountLib.Interfaces;

/// <summary>
/// Interface for discount algoritmus
/// </summary>
public interface IDiscountMaker
{
    /// <summary>
    /// Method to count discount and change the basket
    /// </summary>
    /// <param name="basket">basket for discount</param>
    void GetDiscount(IBasket basket);
}