using Trigan.DiscountLib.Interfaces;

namespace Trigan.DiscountLib;
/// <summary>
/// Class that maintains a list of items to purchase 
/// </summary>
public class Basket : IBasket
{
    private readonly Dictionary<IItem, int> items = new();

    /// <summary>
    /// Method to add items to basket
    /// </summary>
    /// <param name="item">Item to add to basket</param>
    /// <param name="count">Count of item to add to basket, must be positive</param>
    /// /// <exception cref="ArgumentOutOfRangeException">Raise when count is negative</exception>
    public void Add(IItem item, int count = 1)
    {
        switch (count)
        {
            case < 0:
                throw new ArgumentOutOfRangeException("count", count, "Parametr count must be positive");
            case 0:
                return;
        }

        if (items.ContainsKey(item))
        {
            items[item] += count;
            //special case when count before Add was negative
            if (items[item] == 0)
                items.Remove(item);
        }
        else
        {
            items.Add(item, count);
        }
    }

    /// <summary>
    /// Method to remove item from basket. 
    /// </summary>
    /// <remarks>If parameter count is more then items in basket, result is negative number of items in basket!</remarks>
    /// <param name="item">Item to remove</param>
    /// <param name="count">Number of items to remove, should be positive.</param>
    /// <exception cref="ArgumentOutOfRangeException">Raise when count is negative</exception>
    public void Remove(IItem item, int count = 1)
    {
        switch (count)
        {
            case < 0:
                throw new ArgumentOutOfRangeException("count", count, "Parametr count should be positive");
            case 0:
                return;
        }

        if (!items.ContainsKey(item))
            return;

        items[item] -= count;

        if (items[item] == 0)
            items.Remove(item);
    }

    /// <summary>
    /// Method to enumerate items in basket.
    /// </summary>
    /// <returns></returns>
    public IEnumerable<KeyValuePair<IItem, int>> GetBasketItems()
    {
        return items.AsEnumerable();
    }


}