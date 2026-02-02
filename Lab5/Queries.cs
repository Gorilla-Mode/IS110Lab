namespace Lab5;

public abstract class Queries : Product
{
    
    public static List<Product> SelectCategory(Categories category)
    {
        var selectedCategory =
            from product in Stock
            where product.Category == category
            select product;

        return selectedCategory.ToList();
    }
    
    public static List<Product> SelectByPriceRange(decimal minPrice,decimal maxPrice)
    {
        var selectedByPriceRange =
            from product in Stock
            where product.Price >= minPrice && product.Price <= maxPrice
            select product;

        return selectedByPriceRange.ToList();
    }
    
    public static List<Product> SelectHigherPrice(decimal price)
    {
        var selectedHigherPrice =
            from product in Stock
            where product.Price > price
            select product;

        return selectedHigherPrice.ToList();
    }
    
    public static List<Product> SortByPriceAscending()
    {
        var sortedByPriceAscending =
            from product in Stock
            orderby product.Price //ascending er default
            select product;

        return sortedByPriceAscending.ToList();
    }
    
    public static IEnumerable<(Categories Category, int Count, IEnumerable<Product> Products)> GroupByCategory()
    {
        var groupedByCategory =
            from product in Stock
            group product by product.Category into categoryGroup
            select (Category: categoryGroup.Key, Count: categoryGroup.Count(), Products: categoryGroup.AsEnumerable());
        
        return groupedByCategory;
    }
    
    public static long TotalPrice()
    {
        long sum = 0;
        foreach (var product in Stock)
        {
            sum += (long)product.Price;
        }
        
        return sum;
    }
}