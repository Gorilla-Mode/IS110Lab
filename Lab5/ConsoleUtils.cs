namespace Lab5;

public static class ConsoleUtils
{
    public static void PrintProducts(List<Product> products)
    {
        foreach (var product in products)
        {
            Console.WriteLine($"{product.Name} - {product.Price}");
        }
    }

    public static void PrintGroupedProducts( IEnumerable<(Product.Categories Category, int Count, IEnumerable<Product> Products)> groupedByCategory)
    {
        foreach (var item in groupedByCategory)
        {
            Console.WriteLine($"{item.Category} - {item.Count}");
            foreach (var product in item.Products)
            {
                Console.WriteLine($"\t{product.Name} - {product.Price}");
            }
        }
    }
}
