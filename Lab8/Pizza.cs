using System.Globalization;

namespace Lab8;

public enum PizzaSize
{
    Small,
    Medium,
    Large
}

public class Pizza : IPayable, IReceipt
{
    static readonly float[] SizeMultipliers = [1.0f, 1.25f, 1.60f];
    public string Name { get; }
    private string _toppings;
    private double _totalprice;
    private PizzaSize _size;
    private double SizeMultiplier => SizeMultipliers[(int)_size];

    public Pizza(string name, string toppings, double baseprice, PizzaSize size)
    {
        if (!Enum.IsDefined(typeof(PizzaSize), size))
        {
            throw new ArgumentException("Invalid pizza size.");
        }
        
        Name = name;
        _toppings = toppings;
        _size = size;
        _totalprice = Math.Round((baseprice * SizeMultiplier), 2);
    }
    public double CalculatePrice()
    {
        return _totalprice;
    }

    public void PrintReceipt()
    {
        Console.WriteLine($"Pizza: {Name}\nSize: {_size}\nToppings: {_toppings}\n" +
                          $"Price: {_totalprice.ToString("C", CultureInfo.CreateSpecificCulture("NO"))}");
    }
}