using System.Globalization;

namespace Lab5;

public static class ConsoleUtils
{
    public static void PrintProducts(List<Product> products)
    {
        
        //Sjekker om listen er tom
        if (!products.Any())
        {
            Console.WriteLine("No products in collection.");
            return;
        }
        
        //litt mer avansert formattering av strings her, for å lage en tabell
        
        //Finner lengden på den lengste strenger i Name og Price kolonnene for å justere tabellen dynamisk. Og passe på
        //at linjer er på lik linje fra rad til rad
        //Bruker lambda for å hente maks lengde i Name og Price kolonnene. https://learn.microsoft.com/en-us/dotnet/api/system.math.max?view=net-10.0
        //Konverterer Price til string med norsk valuta format for å få riktig lengde
        int maxNameLength = products.Max(p => p.Name?.Length ?? 0);
        int maxPriceLength = products.Max(p => p.Price.ToString("C", CultureInfo.CreateSpecificCulture("NO")).Length);
        
        //Lager top border på formatet "+---+---+"
        //New string('-', length) lager en string med '-' gjentatt 'length' ganger. 
        // Se første konstruktør her: https://learn.microsoft.com/en-us/dotnet/api/system.string?view=net-10.0)
        Console.WriteLine($"+ {new string('-', maxNameLength)} + {new string('-', maxPriceLength)} +"); //Top border
        //Lager header med kolonnenavn. .PadRight legger til whitspace til høyre for stringen for å fylle opp til max lengde.
        //https://learn.microsoft.com/en-us/dotnet/api/system.string.padright?view=net-10.0
        Console.WriteLine($"| {"Product Name".PadRight(maxNameLength)} | {"Price".PadRight(maxPriceLength)} |");//Header
        
        foreach (var product in products) //Løkke for å printe hver rad i tabellen
        {
            //Lager en separator mellom header og/eller rader. Fungerer likt som top border, men bruker '-' i stedet for '+' på endene
            Console.WriteLine($"| {new string('-', maxNameLength)} + {new string('-', maxPriceLength)} |"); //Seperator
            
            //Lager en rad for hvert produkt, med navn og pris. PadRight brukes igjen for å justere kolonnene
            //Price formateres til norsk valuta format for å få riktig lengde
            Console.WriteLine($"| {product.Name?.PadRight(maxNameLength)} | {product.Price.ToString("C", CultureInfo.CreateSpecificCulture("NO")).PadRight(maxPriceLength)} |"); //Row
            
        }
        
        Console.WriteLine($"+ {new string('-', maxNameLength)} + {new string('-', maxPriceLength)} +"); //Bottom border
    }

    public static void PrintGroupedProducts( IEnumerable<(Product.Categories Category, int Count, IEnumerable<Product> Products)> groupedByCategory)
    {
        //Foreach for hver kategori i den grupperte listen.
        foreach (var item in groupedByCategory)
        {
            //Printer kategori og antall produkter i den kategorien
            // \t er escape sequence for tab, som lager et innrykk i konsollen. https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/strings/#string-escape-sequences
            Console.WriteLine($"\t- {item.Category} - {item.Count}"); 
            
            foreach (var product in item.Products) //foreach for hvert produkt i den kategorien
            {
                //Printer produktets navn og pris, med litt innrykk for å vise at det er under kategorien
                Console.WriteLine($"\t\t- {product.Name} - {product.Price.ToString("C", CultureInfo.CreateSpecificCulture("NO"))}");
            }
        }
    }
    
    public static void AwaitKeypress()
    {
        //En liten metode for å vente på at brukeren trykker en tast før konsollen blir ryddet. Brukes for å gi brukeren tid til å lese output før den forsvinner.
        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();
        Console.Clear();
    }
}
