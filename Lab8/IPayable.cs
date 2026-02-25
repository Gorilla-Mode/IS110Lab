namespace Lab8;

public interface IPayable
{
    /// <summary>
    /// Calculates the price for the implementing object.
    /// </summary>
    /// <returns>
    /// The total price as a double value.
    /// </returns>
    double CalculatePrice();
}