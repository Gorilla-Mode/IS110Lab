namespace Lab5;

//Arver fra Product for å få tilgang til Stock, Abstract fordi vi ikke skal instansiere denne klassen
public abstract class Queries : Product 
{
    
    public static List<Product> SelectCategory(Categories category)
    {
        //LINQ returnerer liste med produkter som matcher kategorien
        //Product er navn på varablene vi sjekker imot
        //Stock inneholder alle produktene
        //Where sjekker om produktets kategori matcher den gitte kategorien
        //select velger produktene som matcher kriteriet
        var selectedCategory =
            from product in Stock
            where product.Category == category
            select product;

        return selectedCategory.ToList();
    }
    
    public static List<Product> SelectByPriceRange(decimal minPrice,decimal maxPrice)
    {
        //Where her sjekker om produktets pris er innenfor det gitte prisområdet
        var selectedByPriceRange =
            from product in Stock
            where product.Price >= minPrice && product.Price <= maxPrice
            select product;

        return selectedByPriceRange.ToList();
    }
    
    public static List<Product> SelectHigherPrice(decimal price)
    {
        //where sjekker om produktets pris er høyere enn den gitte prisen   
        var selectedHigherPrice =
            from product in Stock
            where product.Price > price
            select product;

        return selectedHigherPrice.ToList();
    }
    
    public static List<Product> SortByPriceAscending()
    {
        //Velger alle produkter og sorterer dem etter pris i stigende rekkefølge
        var sortedByPriceAscending =
            from product in Stock
            orderby product.Price //ascending er default
            select product;

        return sortedByPriceAscending.ToList();
    }
    
    public static IEnumerable<(Categories Category, int Count, IEnumerable<Product> Products)> GroupByCategory()
    {
        //Litt mer avansert med linq, grupperer produkter etter kategori og teller antall i hver kategori
        //Hvert produkt blir gruppert etter sin kategori (categoryGroup.Key)
        //Select velger ut enumerable av touples med kategori, antall producter i den kategorien, og selve produktene. https://www.geeksforgeeks.org/c-sharp/c-sharp-tuple/
        //Category: categoryGroup.Key refererer til kategorien som gruppen representerer, Count: categoryGroup.Count() teller antall produkter i den gruppen,
        //Products: categoryGroup.AsEnumerable() converterer til enumerable fra IGrouping slik at vi får riktig retur type
        var groupedByCategory =
            from product in Stock
            group product by product.Category into categoryGroup
            select (Category: categoryGroup.Key, Count: categoryGroup.Count(), Products: categoryGroup.AsEnumerable());
        
        return groupedByCategory;
    }
    
    public static List<Product> GetAllProducts()
    {
        return Stock;
    }
    
    public static decimal TotalPrice()
    {
        decimal sum = 0;
        foreach (var product in Stock)
        {
            sum += product.Price; 
        }
        
        return sum;
    }
}