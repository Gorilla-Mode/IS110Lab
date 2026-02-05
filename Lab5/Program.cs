using System.Globalization;
using Lab5;

#region Task1

int[] array = [1, 2, 3, 4, 5, 54, 232, 1234 ,432, 12, 124, 534, 23, 45, 67, 89, 90];
    int largestVal = array[0];
    int sum = 0; //setter sum til å begynne på 0

    for (int i = 0; i < array.Length; i++) //Legger sammen alle verdiene i arrayet, og legger det til sum
    {
        sum += array[i];
    }

    foreach (var val in array)
    {
        if (val > largestVal) //Sjekker verdien er større enn den største verdien vi har funnet så langt, og oppdaterer largestVal hvis det er tilfelle
        {
            largestVal = val;
        }
    }

    Console.WriteLine($"The sum of the array is: {sum}");
    Console.WriteLine($"The largest number in the array is: {largestVal}");
    ConsoleUtils.AwaitKeypress();
#endregion
#region Task 2

bool task2 = true; //Ungår while true
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
                      "[7] Display products over given price\n" +
                      "[0] Exit");
    
    //Bruker TryParse for å håndtere feilinput.
    //Out legger referansen til choice variabelen, som da får verdien av det brukeren skrev inn hvis parsing var vellykket. 
    //Her blir også variablen choice deklarert samtidig.
    bool parseSuccess = byte.TryParse(Console.ReadLine(), out byte choice); 
    if (!parseSuccess) //Hvis input ikke kan parses til en byte, starter loopen på nytt.
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
            ConsoleUtils.PrintProducts(Queries.GetAllProducts()); //Se consoleutils for hvordan PrintProducts fungerer, og queries for GetAllProducts
            ConsoleUtils.AwaitKeypress(); //Se consoleutils for hvordan AwaitKeypress fungerer
            break;
        case 2:
            Console.Clear();
            Console.WriteLine("All Products Sorted by Price Ascending:");
            ConsoleUtils.PrintProducts(Queries.SortByPriceAscending());
            ConsoleUtils.AwaitKeypress();
            break;
        case 3:
            Console.Clear();
            
            //meny for å velge kategori
            Console.WriteLine("Select Category:\n\t[1] GraphicsCard\n\t[2] Processor\n\t[3] Motherboard\n\t" +
                              "[4] Ram\n\t[5] Storage\n\t[6] PowerSupply");
            
            //Parser input til kategori enum
            parseSuccess = Enum.TryParse(Console.ReadLine(), out Product.Categories categoryChoice);
            if (!parseSuccess) //Hvis input ikke kan parses til enum, bryter vi ut av switch casen
            {
                Console.Clear();
                Console.WriteLine("Invalid input");
                ConsoleUtils.AwaitKeypress();
                break;
            }

            //Må sjekke at inputen er en definert enum verdi i "Product.Categories", hvis ikke kunne f.eks. 12 vært gyldig input
            if (!Enum.IsDefined(typeof(Product.Categories), categoryChoice))
            {
                Console.Clear();
                Console.WriteLine("Invalid category choice");
                ConsoleUtils.AwaitKeypress();
                break;
            }
            
            switch (categoryChoice)
            {
                //Ved bruk av enum får du statisk analyse i IDEen, og unngår "magic numbers". Mye lettere å debugge.
                //Anbefaler STERKT å bruke enums i tilfeller det du har et sett med navnede konstante verider, som kategori, status, osv.
                case Product.Categories.GraphicsCard: 
                    Console.Clear();
                    Console.WriteLine("Graphics Cards:");
                    ConsoleUtils.PrintProducts(Queries.SelectCategory(Product.Categories.GraphicsCard));
                    ConsoleUtils.AwaitKeypress();
                    break;
                case Product.Categories.Processor:
                    Console.Clear();
                    Console.WriteLine("Processors:");
                    ConsoleUtils.PrintProducts(Queries.SelectCategory(Product.Categories.Processor));
                    ConsoleUtils.AwaitKeypress();
                    break;
                case Product.Categories.Motherboard:
                    Console.Clear();
                    Console.WriteLine("Motherboards:");
                    ConsoleUtils.PrintProducts(Queries.SelectCategory(Product.Categories.Motherboard));
                    ConsoleUtils.AwaitKeypress();
                    break;
                case Product.Categories.Ram:
                    Console.Clear();
                    Console.WriteLine("RAM:");
                    ConsoleUtils.PrintProducts(Queries.SelectCategory(Product.Categories.Ram));
                    ConsoleUtils.AwaitKeypress();
                    break;
                case Product.Categories.Storage:
                    Console.Clear();
                    Console.WriteLine("Storage:");
                    ConsoleUtils.PrintProducts(Queries.SelectCategory(Product.Categories.Storage));
                    ConsoleUtils.AwaitKeypress();
                    break;
                case Product.Categories.PowerSupply:
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
            bool minParseSuccess = decimal.TryParse(Console.ReadLine(), out decimal minPrice); //Parser input til decimal, 
            if (!minParseSuccess) //sjekker om parsing var vellykket
            {
                Console.Clear();
                Console.WriteLine("Invalid minimum price");
                ConsoleUtils.AwaitKeypress();
                break;
            }

            Console.Write("Enter maximum price:");
            bool maxParseSuccess = decimal.TryParse(Console.ReadLine(), out decimal maxPrice); //Parser input til decimal
            if (!maxParseSuccess) //sjekker om parsing var vellykket
            {
                Console.Clear();
                Console.WriteLine("Invalid maximum price");
                ConsoleUtils.AwaitKeypress();
                break;
            }

            if (minPrice >= maxPrice) //Sjekker at maks pris er større enn min pris
            {
                Console.Clear();
                Console.WriteLine("Minimum price must be less than maximum price");
                ConsoleUtils.AwaitKeypress();
                break;
            }
            
            var productsInRange = Queries.SelectByPriceRange(minPrice, maxPrice); //Henter produkter i prisområdet
            if (!productsInRange.Any()) //Sjekker listen inneholder noen produkter
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
            //Formatterer totalprisen som norsk valuta
            // C er currency
            // CultureInfo.CreateSpecificCulture("NO") spesifiserer norsk kultur for riktig valutaformat
            // Sjekk denne linker for mer info: https://learncsharpmastery.com/string-formatting/
            Console.WriteLine($"Total Price of all Products: {Queries.TotalPrice().ToString("C", CultureInfo.CreateSpecificCulture("NO"))}");
            ConsoleUtils.AwaitKeypress();
            break;
        case 7:
            Console.Clear();
            Console.Write("Enter price:");
            
            bool priceParseSuccess = decimal.TryParse(Console.ReadLine(), out decimal price); //Parser input til decimal
            if (!priceParseSuccess) //sjekker om parsing var vellykket
            {
                Console.Clear();
                Console.WriteLine("Invalid price");
                ConsoleUtils.AwaitKeypress();
                break;
            }

            Console.WriteLine("Products over given price:");
            ConsoleUtils.PrintProducts(Queries.SelectHigherPrice(price));
            ConsoleUtils.AwaitKeypress();
            break;
            
        default:
            Console.WriteLine("Invalid choice");
            break;
    }
    
}
#endregion
#region task3

var shoppingList = new List<string>(); //Liste for å lagre handlelisteelementer
bool task3 = true; //Ungår while true
while (task3)
{
    Console.Clear();
    Console.WriteLine("Shopping List Manager\n[1] Add Item\n[2] Remove Item\n[3] View Items\n[4] View alphabetically" +
                      "\n[5] Search\n[0] Exit");
    bool parseSuccess = byte.TryParse(Console.ReadLine(), out byte choice); //Parser input til byte
    if (!parseSuccess) //Sjekker om parsing var vellykket
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
            
            //Bryter ut dersom input er tom eller kun whitespace
            //.IsNullOrWhiteSpace sjekker både for null, tom streng, og strenger som kun inneholder whitespace. Da slipper vi å gjøre alt det selv.
            if (string.IsNullOrWhiteSpace(itemToAdd)) 
            {
                Console.Clear();
                Console.WriteLine("Item cannot be empty");
                ConsoleUtils.AwaitKeypress();
                break;
            }
            
            shoppingList.Add(itemToAdd); //Legger til element i handlelisten
            Console.WriteLine($"{itemToAdd} added to the shopping list.");
            ConsoleUtils.AwaitKeypress();
            break;
        case 2:
            Console.Clear();
            Console.Write("Enter item to remove: ");
            //Bruker null-coalescing operator for å sikre at itemToRemove aldri blir null
            //Uten hadde programmet feilet hvis input er null.
            string itemToRemove = Console.ReadLine() ?? string.Empty; 
            
            if (!shoppingList.Contains(itemToRemove)) //Sjekker om elementet finnes i handlelisten
            {
                Console.WriteLine($"Item {itemToRemove} does not exist.");
                ConsoleUtils.AwaitKeypress();
                break;
            }
            
            shoppingList.Remove(itemToRemove); // Fjerner element fra handlelisten
            Console.WriteLine($"{itemToRemove} removed from the shopping list.");
            ConsoleUtils.AwaitKeypress();
            break;
        case 3:
            Console.Clear();
            
            if (!shoppingList.Any()) //sjekker om handlelisten er tom
            {
                Console.WriteLine("No items in the shopping list.");
                ConsoleUtils.AwaitKeypress();
                break;
            }
            
            Console.WriteLine("Shopping List Items:");
            foreach (var item in shoppingList) //skriver ut alle elementene i handlelisten
            {
                Console.WriteLine($"- {item}");
            }
            ConsoleUtils.AwaitKeypress();
            break;
        case 4:
            Console.Clear();

            if (!shoppingList.Any()) //sjekker om handlelisten er tom
            {
                Console.WriteLine("No items in the shopping list.");
                ConsoleUtils.AwaitKeypress();
                break;
            }

            //Linq OrderBy for å sortere listen, blir alfabetisk på strings
            //Bruker lambda uttrykk for å spesifisere sorteringskriteriet, caster fra IEnumerable til list.
            // https://learncsharpmastery.com/orderby-and-sorting/
            // Lurt å lese litt om lambda, nyttig sammen med linq. https://www.csharptutorial.net/csharp-tutorial/csharp-lambda-expression/
            var sortedList = shoppingList.OrderBy(item => item).ToList();
            
            Console.WriteLine("Shopping List Items (Alphabetically):");
            foreach (var item in sortedList)
            {
                Console.WriteLine($"- {item}");
            }
            
            ConsoleUtils.AwaitKeypress();
            break;
        case 5:
            Console.Clear();
            Console.Write("Enter search term:");
            string? searchTerm = Console.ReadLine();

            foreach (var item in shoppingList)
            {
                //Sjekker om elementet inneholder søketermen, ignorerer case ved å gjøre begge til uppercase
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