using System.ComponentModel;
using System.Globalization;

namespace Lab8;

//Mer avansert enum implementasjon enn tidligre, denne støtter andre typer data enn int, eksplisitt casting, og kaster
//exception dersom en type ikke er definert, aka typesafe. Les mer om type safety her: https://www.c-sharpcorner.com/UploadFile/vikie4u/type-safety-in-net/ 

//Structs er enkle "klasser" uten metoder, som kan sees på som en bruker definert type. Den største forskjellen er at structs
//er value typer imotsetning til kasser som er referanse typer. Som regel er structs raskere dersom størrelsen er under ca. 16-24 bytes,
//er de større er det blir det raskere med en referanse type som klasse. Dette er fordi hele structen må kopieres hver gang den brukes,
//mens en referanse type bare kopierer minneadressen (8 bytes) til objektet. Det er mange grunner til at det er forsatt raskere med
//struct opp til 16-24 bytes selv om de er større en pekeren til objektet f.eks. dynamisk vs lineær allokering av minne, object headere, cache misses.
//Dere har nok mer om dette i is-105
//
//Value typer: https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/value-types
//Referanse typer: https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/reference-types

/// <summary>
/// Enum for pizza sizes. Type-safe at compile time, except if default(PizzaSize) is used.
/// </summary>
public readonly struct PizzaSize
{
    //Privat enum til størrelse på navn. Bruker enum ovenfor string pga av minnestørrelse størrelse og bedre å kjøre sjekker imot.
    //For å beskytte imot en default konstruktør eller default(PizzaSize) setter vi default verdien til Undefined, og sjekker imot denne senere.
    private enum SizeName
    {
        Undefined = 0,
        Small,
        Medium,
        Large
    }

    //Definerer de tre størrelsene som static readonly fields, disse er immutable og kan ikke endres etter de er definert.
    //Dette er de gyldige verdiene.
    public static readonly PizzaSize Small = new(SizeName.Small,1.0f);
    public static readonly PizzaSize Medium = new(SizeName.Medium, 1.25f);
    public static readonly PizzaSize Large = new(SizeName.Large,1.60f);
    
    //Eksplicit operator for å konvertere fra float til PizzaSize, kaster exception dersom verdien ikke er gyldig.
    //Dette må gjøres fordi siden dette er ett struct, støttes ikke casting som en enum fra start. Så vi må definere type konverteringen selv
    //Les mer her: https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/operators/user-defined-conversion-operators
    //Her bruker vi en switch expression, nesten likt som statement, men den må returnere noe. https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/operators/switch-expression
    //Her sier vi dersom input er 1.25f returneres medium. Underscore (_) er samme som default i switch statment.
    public static explicit operator PizzaSize(float multiplier) => multiplier switch
    {
        1.0f => Small,
        1.25f => Medium,
        1.60f => Large,
        _ => throw new InvalidEnumArgumentException("Invalid multiplier for PizzaSize")
    };

    private SizeName Name { get; }

    //Custom get metode som sjekker om navn er undefined og kaster exception, hvis ikke returneres verdien.
    //Field må brukes slik at vi henter verdien. Bruker vi Multipler (navnet til feltet) kommer getteren til å bli kalt rekursift til hele driten krasjer
    //les mer her: https://www.c-sharpcorner.com/article/the-new-field-keyword-in-c-sharp-14-practical-usage-examples-and-best-practices/
    public float Multiplier
    {
        get => Name == SizeName.Undefined ? throw new InvalidEnumArgumentException("Undefined enum") : field;
        private init;
    }

    //privat konstruktør brukes til å definere gyldige verdier
    private PizzaSize(SizeName name, float multiplier)
    {
        Name = name;
        Multiplier = multiplier;
    }

    //Stopper bruk av default konstruktør, denne stopper på runtime, ikke compile time
    public PizzaSize()
    {
        throw new NotSupportedException("Default constructor is not allowed");
    }

    //Overrider slik at en variabel av pizzasize skrives som string, istedet for en objektreferanse.
    //Sjekker også om verdien er undefined, og kaster exception dersom det.
    public override string ToString()
    {
        return Name == SizeName.Undefined ? throw new InvalidEnumArgumentException("Undefined enum") : Name.ToString();
    }
}

//Arver fra interface IPayable og IReceipt, da må metodene implementeres de kan også sendes ned i hieerarkiet med abstract
public class Pizza : IPayable, IReceipt
{
    //Setter alt til private og readonly, siden ingen utvendine skal bruke disse. Readonly kan eventuelt fjernes
    //dersom en vil ha logikk for å kunne endre pris
    private readonly string _name;
    private readonly string _toppings;
    private readonly double _totalPrice;
    private readonly PizzaSize _size;

    public Pizza(string name, string toppings, double basePrice, PizzaSize size)
    
    {
        _name = name;
        _toppings = toppings;
        _size = size;
        _totalPrice = Math.Round(basePrice * _size.Multiplier, 2); //runder av til 2 desimalerplasser
    }
    
    //Implementerer metode fra IPayable
    public double CalculatePrice()
    {
        return _totalPrice;
    }

    //Implementerer metode fra IReceipt
    public void PrintReceipt()
    {
        Console.WriteLine($"Pizza: {_name}\nSize: {_size}\nToppings: {_toppings}\n" +
                          $"Price: {_totalPrice.ToString("C", CultureInfo.CreateSpecificCulture("NO"))}");
    }
}