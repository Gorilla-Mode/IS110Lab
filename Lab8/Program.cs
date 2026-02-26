using System.Globalization;
using Lab8;


//Ekstrem lat måte å legge til objektene i begge lister. Bruker objekt typem som alle andre objekter arver ifra, dvs
//at et hvilket som helst objekt kan legges til i listen. Gjøre dette KUN slik at jeg kan gjøre en loop og legge de til
//i listene av interface type automatisk.
//https://www.geeksforgeeks.org/c-sharp/c-sharp-object-class/
IList<object> objects = new List<object>
{
    //Parametere kan settes eksplistt med navn, istendenfor rekkefølge. Kan være nytting for bedre lesbarehet når det er
    //mange parametere
    new Subscription(
        name: "Netflix",
        months: 12,
        monthlyRate: 109.99),
    new Subscription(
        name: "Spotify",
        months: 12,
        monthlyRate: 99.99),
    
    new MovieTicket(
        movieName: "Lord of the Rings: The Fellowship of the Ring",
        movieGenre: "Fantasy",
        movieDirector:"Peter Jackson",
        runtimeMinutes:178, 
        ageRestriction:12,
        price:150.00,
        showDate: new DateTime(2026, 7, 1, 19, 30, 0)),
    new MovieTicket(
        movieName: "Black Hawk Down",
        movieGenre: "War",
        movieDirector: "Ridley Scott",
        runtimeMinutes: 120, 
        ageRestriction: 18,
        price: 120.00,
        showDate: new DateTime(2026, 7, 1, 19, 30, 0)),
    
    new Pizza(
        name: "Parma", 
        toppings:  "Mozzarella, Tomato, Parmigiano, Parma ham, Rocket, Balsamic",
        basePrice: 203.49,
        size: PizzaSize.Large),
    new Pizza(
        name: "Margherita", 
        toppings:"Mozzarella, Tomato, Parmigiano, Basil", 
        basePrice: 179.99,
        size: PizzaSize.Small),
    new Pizza(
        name:"Roma", 
        toppings: "Mozzarella, Tomato, Parmigiano, Parma ham, Rocket, Balsamic", 
        basePrice: 203.49,
        size: PizzaSize.Medium)
};

//Definererer lister med interface typene
IList<IPayable> payables = new List<IPayable>();
IList<IReceipt> receipts = new List<IReceipt>();

//legger til objektene i listene, ved å caste til tilsvarende interface
foreach (var obj in objects)
{
    payables.Add((IPayable)obj);
    receipts.Add((IReceipt)obj);
}

//Lambda fuksjon, kjører calculate på alle elementene i listen, og summerer resultatet, så formatteres det til currency, med norsk valuta
Console.WriteLine($"Total price for all items: {payables.Sum(p => p.CalculatePrice()).ToString("C", CultureInfo.CreateSpecificCulture("NO"))}\n");

//Printer ut kvittering for alle elementene i listen, ved å kalle printreceipt på alle elementene i listen.
//Denne og lambda funksjonen er begge gode eksempler på polymorfisme, da typene og implementasjonen av metodene er ulike.
for (int i = 0; i < receipts.Count; i++)
{
    Console.WriteLine($"[{i + 1}] Receipt:");
    receipts[i].PrintReceipt();
    Console.WriteLine("\n");
}