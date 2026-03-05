using System.Globalization;

namespace Lab8;

//bruker primary constructor syntaks: https://learn.microsoft.com/en-us/dotnet/csharp/whats-new/tutorials/primary-constructors
//Arver fra interface IPayable og IReceipt, da må metodene implementeres de kan også sendes ned i hieerarkiet med abstract
public class MovieTicket(
    string movieName,
    string movieGenre,
    string movieDirector,
    ushort runtimeMinutes,
    uint ageRestriction,
    double price,
    DateTime showDate)
    : IPayable, IReceipt
{
    //Setter alt til private og readonly, siden ingen utvendine skal bruke disse. Readonly kan eventuelt fjernes
    //dersom en trenger logikk til å endre noe
    private string MovieName { get; } = movieName; 
    private readonly string _movieGenre = movieGenre;
    private readonly string _movieDirector = movieDirector;
    private readonly ushort _runtimeMinutes = runtimeMinutes;
    private readonly uint _ageRestriction = ageRestriction;
    private readonly double _price = price;
    private readonly DateTime _showDate = showDate;

    //denne er implementasjonen av IPayable
    public double CalculatePrice()
    {
        return _price;
    }

    //denne er implementasjonen av IReceipt
    public void PrintReceipt()
    {
        Console.WriteLine($"Movie: {MovieName}\nGenre: {_movieGenre}\nDirector: {_movieDirector}\nRuntime: {_runtimeMinutes} minutes\n" +
                          $"Age Restriction: {_ageRestriction}\nPrice: {_price.ToString("C", CultureInfo.CreateSpecificCulture("NO"))}" +
                          $"\nShow Date: {_showDate:dddd dd MMMM @ HH:mm}");
    }
}