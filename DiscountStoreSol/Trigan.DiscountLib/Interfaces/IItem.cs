namespace Trigan.DiscountLib.Interfaces;

/// <summary>
/// Interface for items in system
/// </summary>
public interface IItem
{
    /// <summary>
    /// Items Id, interface needs only getters
    /// </summary>
    long Id { get; }
    /// <summary>
    /// Items name
    /// </summary>
    string Name { get; }
    /// <summary>
    /// Items price
    /// </summary>
    decimal Price { get; }
}