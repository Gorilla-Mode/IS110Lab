using System.Globalization;

namespace Lab8;

public readonly struct PizzaSize
{
    private enum SizeName
    {
        Small,
        Medium,
        Large
    }
    
    public static readonly PizzaSize Small = new(SizeName.Small,1.0f);
    public static readonly PizzaSize Medium = new(SizeName.Medium, 1.25f);
    public static readonly PizzaSize Large = new(SizeName.Large,1.60f);
    
    public float Multiplier { get; }
    private SizeName Name { get; }
    

    private PizzaSize(SizeName name, float multiplier)
    {
        Name = name;
        Multiplier = multiplier;
    }

    public override string ToString() => Name.ToString();
}

public class Pizza : IPayable, IReceipt
{
    public string Name { get; }
    private string _toppings;
    private double _totalprice;
    private PizzaSize _size;

    public Pizza(string name, string toppings, double baseprice, PizzaSize size)
    {
        Name = name;
        _toppings = toppings;
        _size = size;
        _totalprice = Math.Round((baseprice * _size.Multiplier), 2);
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