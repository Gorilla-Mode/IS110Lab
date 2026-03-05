using System.Globalization;

namespace Lab8;

//bruker primary constructor syntaks: https://learn.microsoft.com/en-us/dotnet/csharp/whats-new/tutorials/primary-constructors
//Arver fra interface IPayable og IReceipt, da må metodene implementeres de kan også sendes ned i hieerarkiet med abstract
public class Subscription(string name, uint months, double monthlyRate) : IPayable, IReceipt
{
    //Setter alt til private og readonly, siden ingen utvendine skal bruke disse. Readonly kan eventuelt fjernes
    //dersom en trenger logikk til å endre noe
    private readonly string _name = name;
    private readonly uint _months = months;
    private readonly double _monthlyRate = monthlyRate;

    //denne er implementasjonen av IPayable
    public double CalculatePrice()
    {
       return Math.Round((_months * _monthlyRate), 2);
    }

    //denne er implementasjonen av IReceipt
    public void PrintReceipt()
    {
        Console.WriteLine($"Subscription: {_name}\nDuration: {_months} months\nMonthly Rate: ${_monthlyRate}\n" +
                          $"Total Price: {CalculatePrice().ToString("C", CultureInfo.CreateSpecificCulture("NO"))}");
    }
}