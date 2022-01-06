using Trigan.DiscountLib.Interfaces;

namespace Trigan.DiscountLib;

/// <summary>
/// Class to represent Item in a basket. Class is immutable.
/// </summary>
public record Item : IItem
{
    /// <summary>
    /// Items Id
    /// </summary>
    public long Id { get; init; }
    /// <summary>
    /// Name for bill
    /// </summary>
    public string Name { get; init; } = String.Empty;
    /// <summary>
    /// Price for one item
    /// </summary>
    public decimal Price { get; init; }
}