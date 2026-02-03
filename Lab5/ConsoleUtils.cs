using System.Globalization;

namespace Lab5;

public static class ConsoleUtils
{
    public static void PrintProducts(List<Product> products)
    {
        
        //Litt mer avansert formattering av strings, slik at vi får en fin tabell
        if (!products.Any())
        {
            Console.WriteLine("No products in collection.");
            return;
        }
        
        int maxNameLength = products.Max(p => p.Name?.Length ?? 0);
        int maxPriceLength = products.Max(p => p.Price.ToString("C", CultureInfo.CreateSpecificCulture("NO")).Length);
        
        Console.WriteLine($"+ {new string('-', maxNameLength)} + {new string('-', maxPriceLength)} +");
        Console.WriteLine($"| {"Product Name".PadRight(maxNameLength)} | {"Price".PadRight(maxPriceLength)} |");
        
        foreach (var product in products)
        {
            Console.WriteLine($"| {new string('-', maxNameLength)} + {new string('-', maxPriceLength)} |");
            Console.WriteLine($"| {product.Name?.PadRight(maxNameLength)} | {product.Price.ToString("C", CultureInfo.CreateSpecificCulture("NO")).PadRight(maxPriceLength)} |");
            
        }
        
        Console.WriteLine($"+ {new string('-', maxNameLength)} + {new string('-', maxPriceLength)} +");
    }

    public static void PrintGroupedProducts( IEnumerable<(Product.Categories Category, int Count, IEnumerable<Product> Products)> groupedByCategory)
    {
        foreach (var item in groupedByCategory)
        {
            Console.WriteLine($"\t- {item.Category} - {item.Count}");
            foreach (var product in item.Products)
            {
                Console.WriteLine($"\t\t- {product.Name} - {product.Price.ToString("C", CultureInfo.CreateSpecificCulture("NO"))}");
            }
        }
    }
    
    public static void AwaitKeypress()
    {
        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();
        Console.Clear();
    }
}
