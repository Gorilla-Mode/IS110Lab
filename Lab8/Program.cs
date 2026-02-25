using System.Globalization;
using Lab8;

IList<object> objects = new List<object>
{
    new Subscription(name: "Netflix", months: 12, monthlyRate: 109.99),
    new Subscription(name: "Spotify", months: 12, monthlyRate: 99.99),
    
    new MovieTicket(movieName: "Lord of the Rings: The Fellowship of the Ring",
        movieGenre: "Fantasy",
        movieDirector:"Peter Jackson",
        runtimeMinutes:178, 
        ageRestriction:12,
        price:150.00,
        showDate: new DateTime(2026, 7, 1, 19, 30, 0)),
    new MovieTicket(movieName: "Black Hawk Down",
        movieGenre: "War",
        movieDirector: "Ridley Scott",
        runtimeMinutes: 120, 
        ageRestriction: 18,
        price: 120.00,
        showDate: new DateTime(2026, 7, 1, 19, 30, 0)),
    
    new Pizza("Parma", "Mozzarella, Tomato, Parmigiano, Parma ham, Rocket, Balsamic", 203.49, PizzaSize.Large),
    new Pizza("Margherita", "Mozzarella, Tomato, Parmigiano, Basil", 179.99, PizzaSize.Small),
    new Pizza("Roma", "Mozzarella, Tomato, Parmigiano, Parma ham, Rocket, Balsamic", 203.49, PizzaSize.Medium),
};

IList<IPayable> payables = new List<IPayable>();
IList<IReceipt> receipts = new List<IReceipt>();

foreach (var obj in objects)
{
    payables.Add((IPayable)obj);
    receipts.Add((IReceipt)obj);
}

Console.WriteLine($"Total price for all items: {payables.Sum(p => p.CalculatePrice()).ToString("C", CultureInfo.CreateSpecificCulture("NO"))}\n");

for (int i = 0; i < receipts.Count; i++)
{
    Console.WriteLine($"[{i + 1}] Receipt:");
    receipts[i].PrintReceipt();
    Console.WriteLine("\n");
}