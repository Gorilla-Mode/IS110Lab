using static Lab5.Product.Categories;

namespace Lab5;

public class Product
{
    //Lager enum for kategorier, Enum er en datatype som kan ha et sett med forhåndsdefinerte konstanter.
    //Dette gir full statisk analyse i IDE, og en kan ikke skrive inn feil kategori ved et uhell.
    //Enums gjør det også enkelt å sjekke om input verdier er gyldige.
    //Enums er LETT min favoritt datatype
    //https://www.w3schools.com/cs/cs_enums.php
    public enum Categories
    {
        GraphicsCard,
        Processor,
        Motherboard,
        Ram,
        Storage,
        PowerSupply,
    }

    //genererer et tilfeldig ID for hvert produkt
    //her hadde det vært lurt å bekrefte at ID er unik, men for enkelhets skyld hopper vi over det, siden kollisjoner med 64-bit er sjeldne
    private ulong Id { get; init; } = (ulong)Random.Shared.Next(); 
    public string? Name { get; init; }
    public Categories Category { get; init; }
    public decimal Price { get; set; }
    
    //Lager en statisk liste med produkter, slik at den er den samme for alle instanser av Product
    //protected gir kun tilgang til denne listen fra klasser som arver fra Product. https://www.w3schools.com/cs/cs_access_modifiers.php
    //bruker object initializer syntax for å initialisere produktene i listen. Da slipper vi og kjøre .add på hvert produkt
    //https://www.geeksforgeeks.org/c-sharp/object-and-collection-initializer-in-c-sharp/
    protected static List<Product> Stock =
    [
        new Product() { Name = "NVIDIA GeForce RTX 5090", Category = GraphicsCard, Price = 44950.99m },
        new Product() { Name = "AMD Radeon RX 7900 XTX", Category = GraphicsCard, Price = 39999.50m },
        new Product() { Name = "Intel Core i9-13900K", Category = Processor, Price = 19999.99m },
        new Product() { Name = "AMD Ryzen 9 7950X", Category = Processor, Price = 18999.00m },
        new Product() { Name = "ASUS ROG Strix Z790-E", Category = Motherboard, Price = 9999.99m },
        new Product() { Name = "MSI MPG B650 Carbon WiFi", Category = Motherboard, Price = 7999.49m },
        new Product() { Name = "Corsair Vengeance LPX 32GB", Category = Ram, Price = 3999.99m },
        new Product() { Name = "G.Skill Trident Z5 RGB 32GB", Category = Ram, Price = 4299.99m },
        new Product() { Name = "Samsung 980 Pro 1TB", Category = Storage, Price = 2499.99m },
        new Product() { Name = "Western Digital Black SN850X 1TB", Category = Storage, Price = 2299.99m },
        new Product() { Name = "Corsair RM850x", Category = PowerSupply, Price = 1999.99m },
        new Product() { Name = "EVGA SuperNOVA 850 G5", Category = PowerSupply, Price = 1899.99m }
    ];
}