using System.Globalization;
using Lab5;

#region Task1

int[] array = [1, 2, 3, 4, 5, 54, 232, 1234 ,432, 12, 124, 534, 23, 45, 67, 89, 90];
    int largestVal = array[0];
    int sum = 0;

    for (int i = 0; i < array.Length; i++)
    {
        sum += array[i];
    }

    foreach (var val in array)
    {
        if (val > largestVal)
        {
            largestVal = val;
        }
    }

    Console.WriteLine($"The sum of the array is: {sum}");
    Console.WriteLine($"The largest number in the array is: {largestVal}");
    ConsoleUtils.AwaitKeypress();
#endregion
#region Task 2

bool task2 = true;
while (task2)
{
    Console.Clear();
    Console.WriteLine("Product Management System");
    Console.WriteLine("[1] Display all products\n" +
                      "[2] Display price ascending\n" +
                      "[3] Display products by category\n" +
                      "[4] Display products by price range\n" +
                      "[5] Display products grouped by category\n" +
                      "[6] Display total price of all products\n" +
                      "[0] Exit");
    
    bool parseSuccess = byte.TryParse(Console.ReadLine(), out byte choice);
    if (!parseSuccess)
    {
        Console.WriteLine("Invalid choice");
        continue;
    }

    switch (choice)
    {
        case 0:
            task2 = false;
            break;
        case 1:
            Console.Clear();
            Console.WriteLine("All Products:");
            ConsoleUtils.PrintProducts(Queries.GetAllProducts());
            ConsoleUtils.AwaitKeypress();
            break;
        case 2:
            Console.Clear();
            Console.WriteLine("All Products Sorted by Price Ascending:");
            ConsoleUtils.PrintProducts(Queries.SortByPriceAscending());
            ConsoleUtils.AwaitKeypress();
            break;
        case 3:
            Console.Clear();
            Console.WriteLine("Select Category:\n\t[1] GraphicsCard\n\t[2] Processor\n\t[3] Motherboard\n\t" +
                              "[4] Ram\n\t[5] Storage\n\t[6] PowerSupply");
            parseSuccess = byte.TryParse(Console.ReadLine(), out byte categoryChoice);
            if (!parseSuccess)
            {
                Console.Clear();
                Console.WriteLine("Invalid input");
                ConsoleUtils.AwaitKeypress();
                break;
            }

            if (!Enum.IsDefined(typeof(Product.Categories), categoryChoice -1))
            {
                Console.Clear();
                Console.WriteLine("Invalid category choice");
                ConsoleUtils.AwaitKeypress();
                break;
            }
            

            switch (categoryChoice)
            {
                case 1:
                    Console.Clear();
                    Console.WriteLine("Graphics Cards:");
                    ConsoleUtils.PrintProducts(Queries.SelectCategory(Product.Categories.GraphicsCard));
                    ConsoleUtils.AwaitKeypress();
                    break;
                case 2:
                    Console.Clear();
                    Console.WriteLine("Processors:");
                    ConsoleUtils.PrintProducts(Queries.SelectCategory(Product.Categories.Processor));
                    ConsoleUtils.AwaitKeypress();
                    break;
                case 3:
                    Console.Clear();
                    Console.WriteLine("Motherboards:");
                    ConsoleUtils.PrintProducts(Queries.SelectCategory(Product.Categories.Motherboard));
                    ConsoleUtils.AwaitKeypress();
                    break;
                case 4:
                    Console.Clear();
                    Console.WriteLine("RAM:");
                    ConsoleUtils.PrintProducts(Queries.SelectCategory(Product.Categories.Ram));
                    ConsoleUtils.AwaitKeypress();
                    break;
                case 5:
                    Console.Clear();
                    Console.WriteLine("Storage:");
                    ConsoleUtils.PrintProducts(Queries.SelectCategory(Product.Categories.Storage));
                    ConsoleUtils.AwaitKeypress();
                    break;
                case 6:
                    Console.Clear();
                    Console.WriteLine("Power Supplies:");
                    ConsoleUtils.PrintProducts(Queries.SelectCategory(Product.Categories.PowerSupply));
                    ConsoleUtils.AwaitKeypress();
                    break;
                default:
                    Console.Clear();
                    Console.WriteLine("Invalid category choice");
                    ConsoleUtils.AwaitKeypress();
                    break;
            }
            break;
        case 4:
            Console.Clear();
            Console.Write("Enter minimum price:");
            bool minParseSuccess = decimal.TryParse(Console.ReadLine(), out decimal minPrice);
            if (!minParseSuccess)
            {
                Console.Clear();
                Console.WriteLine("Invalid minimum price");
                ConsoleUtils.AwaitKeypress();
                break;
            }

            Console.Write("Enter maximum price:");
            bool maxParseSuccess = decimal.TryParse(Console.ReadLine(), out decimal maxPrice);
            if (!maxParseSuccess)
            {
                Console.Clear();
                Console.WriteLine("Invalid maximum price");
                ConsoleUtils.AwaitKeypress();
                break;
            }

            if (minPrice >= maxPrice)
            {
                Console.Clear();
                Console.WriteLine("Minimum price must be less than maximum price");
                ConsoleUtils.AwaitKeypress();
                break;
            }
            
            var productsInRange = Queries.SelectByPriceRange(minPrice, maxPrice);
            if (!productsInRange.Any())
            {
                Console.Clear();
                Console.WriteLine("No products found in the given price range");
                ConsoleUtils.AwaitKeypress();
                break;
            }
            
            Console.Clear();
            Console.WriteLine($"Products in price range {minPrice} - {maxPrice}:");
            ConsoleUtils.PrintProducts(productsInRange);
            ConsoleUtils.AwaitKeypress();
            break;
        case 5:
            Console.Clear();
            Console.WriteLine("Products Grouped by Category:");
            ConsoleUtils.PrintGroupedProducts(Queries.GroupByCategory());
            ConsoleUtils.AwaitKeypress();
            break;
        case 6:
            Console.Clear();
            Console.WriteLine($"Total Price of all Products: {Queries.TotalPrice().ToString("C", CultureInfo.CreateSpecificCulture("NO"))}");
            ConsoleUtils.AwaitKeypress();
            break;
        default:
            Console.WriteLine("Invalid choice");
            break;
    }
    
}
#endregion
#region task3

var shoppingList = new List<string>();
bool task3 = true;
while (task3)
{
    Console.Clear();
    Console.WriteLine("Shopping List Manager\n[1] Add Item\n[2] Remove Item\n[3] View Items\n[4] View alphabetically" +
                      "\n[5] Search\n[0] Exit");
    bool parseSuccess = byte.TryParse(Console.ReadLine(), out byte choice);
    if (!parseSuccess)
    {
        Console.WriteLine("Invalid choice");
        continue;
    }

    switch (choice)
    {
        case 0:
            task3 = false;
            break;
        case 1:
            Console.Clear();
            Console.Write("Enter item to add: ");
            string? itemToAdd = Console.ReadLine();
            
            if (string.IsNullOrWhiteSpace(itemToAdd))
            {
                Console.Clear();
                Console.WriteLine("Item cannot be empty");
                ConsoleUtils.AwaitKeypress();
                break;
            }
            
            shoppingList.Add(itemToAdd);
            Console.WriteLine($"{itemToAdd} added to the shopping list.");
            ConsoleUtils.AwaitKeypress();
            break;
        case 2:
            Console.Clear();
            Console.Write("Enter item to remove: ");
            string itemToRemove = Console.ReadLine() ?? string.Empty;
            
            if (!shoppingList.Contains(itemToRemove))
            {
                Console.WriteLine($"Item {itemToRemove} does not exist.");
                ConsoleUtils.AwaitKeypress();
                break;
            }
            
            shoppingList.Remove(itemToRemove);
            Console.WriteLine($"{itemToRemove} removed from the shopping list.");
            ConsoleUtils.AwaitKeypress();
            break;
        case 3:
            Console.Clear();
            
            if (!shoppingList.Any())
            {
                Console.WriteLine("No items in the shopping list.");
                ConsoleUtils.AwaitKeypress();
                break;
            }
            
            Console.WriteLine("Shopping List Items:");
            foreach (var item in shoppingList)
            {
                Console.WriteLine($"- {item}");
            }
            ConsoleUtils.AwaitKeypress();
            break;
        case 4:
            Console.Clear();

            if (!shoppingList.Any())
            {
                Console.WriteLine("No items in the shopping list.");
                ConsoleUtils.AwaitKeypress();
                break;
            }

            var sortedList = shoppingList.OrderBy(item => item).ToList();
            Console.WriteLine("Shopping List Items (Alphabetically):");
            foreach (var item in sortedList)
            {                Console.WriteLine($"- {item}");
            }
            ConsoleUtils.AwaitKeypress();
            break;
        case 5:
            Console.Clear();
            Console.Write("Enter search term:");
            string? searchTerm = Console.ReadLine();

            foreach (var item in shoppingList)
            {
                if (item.ToUpper().Contains(searchTerm?.ToUpper() ?? string.Empty))
                {
                    Console.WriteLine($"- {item}");
                }
            }
            ConsoleUtils.AwaitKeypress();
            break;
        default:
            Console.WriteLine("Invalid choice");
            break;
    }
}
#endregion