namespace Trigan.DiscountLib.Interfaces;

/// <summary>
/// Interface for basket
/// </summary>
public interface IBasket
{
    /// <summary>
    /// Method to add an item to the basket
    /// </summary>
    /// <param name="item">Item to add</param>
    /// <param name="count">Number of items to add</param>
    void Add(IItem item, int count = 1);
    /// <summary>
    /// Method to remove an item to the basket
    /// </summary>
    /// <param name="item">Item to remove</param>
    /// <param name="count">Number of items to remove</param>
    void Remove(IItem item, int count = 1);

    /// <summary>
    /// method to get items and count KeyValuePair enumerator
    /// </summary>
    /// <returns>Enumerator with data in the basket. Key is item, value is count of items</returns>
    IEnumerable<KeyValuePair<IItem, int>> GetBasketItems();
}