#region Task1

using Lab5;

int[] array = [1, 2, 3, 4, 5, 54, 232, 1234 ,432, 12, 124, 534, 23, 45, 67, 89, 90];
    int largestVal = array[0];

    foreach (var val in array)
    {
        if (val > largestVal)
        {
            largestVal = val;
        }
    }

    Console.WriteLine($"The largest number in the array is: {largestVal}");
#endregion
#region Task 2

var gpus = Queries.SelectCategory(Product.Categories.GraphicsCard);
Console.WriteLine("\nSelected Graphics Cards:");
ConsoleUtils.PrintProducts(gpus);

var inRange = Queries.SelectByPriceRange(2000, 9000);
Console.WriteLine("\nSelect by price range:");
ConsoleUtils.PrintProducts(inRange);

var higherThan = Queries.SelectHigherPrice(20000);
Console.WriteLine("\nSelect higher price:");
ConsoleUtils.PrintProducts(higherThan);

var sortedAsc = Queries.SortByPriceAscending();
Console.WriteLine("\nSort by ascending price:");
ConsoleUtils.PrintProducts(sortedAsc);

var groupedByCategory = Queries.GroupByCategory();
Console.WriteLine("\nGrouped by Category:");
ConsoleUtils.PrintGroupedProducts(groupedByCategory);


Console.WriteLine($"Total Price of all Products: {Queries.TotalPrice()}");

#endregion