using System.Globalization;

namespace Lab8;

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
    public string MovieName { get; } = movieName; 
    private string _movieGenre = movieGenre;
    private string _movieDirector = movieDirector;
    private ushort _runtimeMinutes = runtimeMinutes;
    private uint _ageRestriction = ageRestriction;
    private double _price = price;
    private DateTime _showDate = showDate;

    public double CalculatePrice()
    {
        return _price;
    }

    public void PrintReceipt()
    {
        Console.WriteLine($"Movie: {MovieName}\nGenre: {_movieGenre}\nDirector: {_movieDirector}\nRuntime: {_runtimeMinutes} minutes\n" +
                          $"Age Restriction: {_ageRestriction}\nPrice: {_price.ToString("C", CultureInfo.CreateSpecificCulture("NO"))}" +
                          $"\nShow Date: {_showDate:ddddd dd MMMM @ HH:mm}");
    }
}