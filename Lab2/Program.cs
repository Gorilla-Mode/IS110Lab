//https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/preprocessor-directives#defining-regions
//Region har ingen påvirkning på koden, men gjør det mulig å kollapse/ekspandere deler av koden i IDEer som støtter det. (Rider GOAT)

#region Øvelse 1

    /*
     * deklarerer to variabler med meningsfulle navn og tilpassende datatyper. Gjennomfør +, -, * og / operasjoner på
     * de to variablene og legg resultatet i en variabel. Skriv ut resultatet.
     */

    int value1 = 11;
    int value2 = 23;

    int addition = value1 + value2;
    int subtraction = value2 - value1;
    int multiplication = value1 * value2;
    
    // Caster teller til double slik at desimaler ikke blir forkaster. Bruk i tilegg:  Floor, Ceiling eller Round fra Math-klassen dersom heltall ønskes. 
    double division = (double)value2 / value1; 

    /*
     * \n Escape sequence for ny linje. https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/strings/#string-escape-sequences
     * Gjør dette slik at vi ikke trenger å kalle writeLine flere ganger.
     *
     * $"" interpolated string. https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/tokens/interpolated
     * Brukes for å kunne putte variabler direkte inn i stringen, istendet for å bruke string.format eller concatenation.
     */
    Console.WriteLine($"Resultat av addisjon: {addition}\nResultat av subtraksjon: {subtraction}\nResultat av multiplikasjon:" +
                      $"{multiplication}\nResultat av divisjon: {division}\n"); 

#endregion
#region Øvelse 2

    /*
     * deklarerer en variabel av type heltall og skriver ut "arbeidsdag" hvis verdien til variabelen er fra 1 til 5 eller
     * "helg" hvis verdien til variabelen er 6 og 7. Koden skal skrive ut "ugyldig" hvis verdien er noe annen enn 1 - 7.
     */
    
    int weekday = 2;
    
    //Pattern matching syntaks, mulig å sjekke intervaller med switches og slipper å hente verdien til weekday flere ganger
    //noe som gjør koden mer lesbar. Her kunne en også brukt if - if else statements.
    //https://learn.microsoft.com/en-us/dotnet/csharp/fundamentals/functional/pattern-matching
    switch (weekday) 
    {
         case >= 1 and <= 5:
            Console.WriteLine("Ukedag\n"); 
            break;
         case 6 or 7:
            Console.WriteLine("Helg\n");
            break;
        default:
          Console.WriteLine("Ugyldig\n");
            break;
    }

#endregion
#region Øving 3

    /*
     * deklarerer to variabler av type heltall. Gi verdi til hver variabel og skriv kode som sjekker hvilket tall som har
     * høyere verdi og skriver ut det tallet med verdi som er høyere enn det andre. Ellers skriv ut at tallene er like.
     */
    
    int x = -11;
    int y = -10;

    if (x == y)
    {
        Console.WriteLine("x er lik y\n");
    }
    else
    {
        Console.WriteLine($"{Math.Max(x, y)} er størst\n"); // Math.Max returnerer det største av to tall. https://learn.microsoft.com/en-us/dotnet/api/system.math.max
    }
    
    //Eksempel på en funksjon som returnerer det største verdi av to doubles. Dersom du ikke vil bruke Math.Max og heller skrive din egen funksjon.
    double? MaxValue (double val1, double val2) 
    {
        double tolerance = 0.0001; //Definer en liten margin for sammenligning av floats.
        
        //Guard clause, bruk tidlige returns når mulig for å redusere nesting. https://www.youtube.com/watch?v=CFRhGnuXG-4
        //Sjekker om tallene er innenfor en liten margin for å unngå problemer med floating point presisjon. https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/floating-point-numeric-types
        //Abs returnerer absoluttverdien til et tall, gjøre dette slik at negative verdier kan sammenlignes riktig.
        //Uten vil tolerance trigges dersom resultatet av val1 - val2 er negativt, og returnere null. 
        if (Math.Abs(val1 - val2) < tolerance) 
        {
            return null; //Null returners siden tallene er like (nesten).
        }
        
        return (val1 > val2) ? val1 : val2; //Ternary operator for enkel if-else statement. https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/operators/conditional-operator
    }
    
#endregion
#region Øving 4
    
    /*
     * deklarerer en klasse og kaller den "Person". Deklarer variabler ID, navn, fødselsdato og adresse. Skriv en metode
     * som skriver ut informasjon om person.
     */

    //instantierer et objekt av klassen Person
    var person1 = new Person(1, "Saruman", "Orthanc, Isengard", new DateOnly(9, 6, 7));

    //kaller metoden som skriver ut informasjon om personen
    person1.WriteInfo();

    class Person
    {
        //Fields med properties (get; private set;) for å gjøre dem lesbare utenfor klassen, men ikke endringsbare.
        public ulong Id { get; private set; } //Ulong 64-bit unsigned integer for ID, da ID vanligvis ikke er negativt. https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/integral-numeric-types
        public string Name { get; private set; } 
        public string Address { get; private set; }
        public DateOnly Birthdate { get; private set; } //DateOnly struct for å lagre dato uten tid, DateTime kan brukes hvis tid er nyttig.  https://learn.microsoft.com/en-us/dotnet/api/system.dateonly
        
        //constructor
        public Person(ulong id, string name, string address, DateOnly birthdate)
        {
            Id = id;
            Name = name;
            Address = address;
            Birthdate = birthdate;
        }

        //Docstring, nytting å legge til på metoder. Gjør det mulig å se dokumentasjon i IDE ved å holde musen over metodenavnet.
        /// <summary>
        /// Denne metoden skriver ut informasjon om personen.
        /// </summary>
        public void WriteInfo()
        {
            //Ved å bruke ToString på en DateOnly/DateTime kan vi formatere datoen slik vi ønsker. https://learn.microsoft.com/en-us/dotnet/standard/base-types/custom-date-and-time-format-strings
            Console.WriteLine($"ID: {Id}\nNavn: {Name}\nAdresse: {Address}\nFødselsdato: {Birthdate.ToString("dd/MMMM/yyyy")}\n");
        }
    }

#endregion