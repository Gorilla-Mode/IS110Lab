using System.Globalization;

namespace Lab8;

public class Subscription(string name, uint months, double monthlyRate) : IPayable, IReceipt
{
    public string Name { get; } = name;
    private uint _months = months;
    private double _monthlyRate = monthlyRate;

    public double CalculatePrice()
    {
       return Math.Round((_months * _monthlyRate), 2);
    }

    public void PrintReceipt()
    {
        Console.WriteLine($"Subscription: {Name}");
        Console.WriteLine($"Duration: {_months} months");
        Console.WriteLine($"Monthly Rate: ${_monthlyRate}");
        Console.WriteLine($"Total Price: {CalculatePrice().ToString("C", CultureInfo.CreateSpecificCulture("NO"))}");
    }
}