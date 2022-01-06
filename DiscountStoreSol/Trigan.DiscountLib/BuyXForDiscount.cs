using System.Text.Json;
using Trigan.DiscountLib.Interfaces;

namespace Trigan.DiscountLib;

/// <summary>
/// Class counting discount for &quot;Buy X For yy €&quot; algoritmus.
/// Configuration for discount is in file buyxfor.json
/// </summary>
public class BuyXForDiscount : IDiscountMaker
{
    private const string dataFileName = "buyxfor.json";

    private static readonly IReadOnlyDictionary<long, BuyXForData> data;
    static BuyXForDiscount()
    {
        Dictionary<long, BuyXForData> dictionary = new();
        try
        {
            if (!File.Exists(dataFileName))
                return;

            var json = File.ReadAllText(dataFileName);

            var list = JsonSerializer.Deserialize<List<BuyXForData>>(json);

            if (list is null)
                return;

            foreach (var xForData in list)
            {
                try
                {
                    dictionary.Add(xForData.IdOriginal, xForData);
                }
                catch (ArgumentException)
                {
                    //Log duplicate item
                }

            }

            data = dictionary;
        }
        catch (Exception)
        {
            //There would be logging here in real programming
        }

    }

    /// <summary>
    /// Method to change basket by &quot;Buy X For ...&quot; algoritmus.
    /// When method find item with enough count, they prepare data to change basket and add new item for this discount
    /// </summary>
    /// <param name="basket">Basket to count discount</param>
    public void GetDiscount(IBasket basket)
    {
        var todo = basket.GetBasketItems()
            .Where(basketItem => data.ContainsKey(basketItem.Key.Id))
            .ToDictionary(basketItem => basketItem, basketItem => data[basketItem.Key.Id]);

        foreach (var ((item, count), buyXFor) in todo)
        {
            int discountCount = count / buyXFor.CountForDiscount;

            basket.Remove(item, discountCount * buyXFor.CountForDiscount);

            IItem newItem = new Item() { Id = buyXFor.IdBxfDiscount, Name = buyXFor.Name, Price = buyXFor.Price };
            basket.Add(newItem, discountCount);
        }
    }

    /// <summary>
    /// Internal class to store data for discount algoritmus
    /// </summary>
    record BuyXForData
    {
        public long IdOriginal { get; init; }
        public long IdBxfDiscount { get; init; }
        public int CountForDiscount { get; init; }
        public string Name { get; init; } = String.Empty;
        public decimal Price { get; init; }
    }
}