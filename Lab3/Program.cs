using Lab3;
#region Øvelse 1

/*
 * Basert på programmet vi skrev sammen i forrige forelesningen, så skal du utvide koden sånn at den tar inndata fra brukeren
 * og lager så mange objekter av type person som brukeren vil til at brukeren gir beskjed "exit". Da stopper applikasjonen
 * ved "exit" beskjed og ender med å skrive ut en melding til brukeren som for eksempel "slutt!" eller noe lignende.
 */

    var persons = new List<Person>(); //liste for å lagre person objekter
    string? input = String.Empty; //Lagrer input fra consoll, og sjekker i while loop
    while (input.ToLower() != "exit") //med unntak av apploop, og noen få andre tilfeller. Ikke bruk en while(true)
    {
        Console.Write("\nInput person name (or type 'exit' to quit): ");
        input = Console.ReadLine();
        string? name = input;
        if (input == null || input.ToLower() == "exit")
        {
            break; //Bryter ut av loopen https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/statements/jump-statements
        }
        
        Console.Write("Input person ID (or type 'exit' to quit): ");
        input = Console.ReadLine();
        
        if (input == null || input.ToLower() == "exit")
        {
            break; //Bryter ut av loopen https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/statements/jump-statements
        }
        
        //tryparse for å unngå exceptions ved ugylidg input https://www.bytehide.com/blog/tryparse-csharp
        //input Prøver å parse input til int, hvis det feiler settes personId til 0
        //out brukes for å gi tryparse en referanse til hvilken variabel som skal ha den parset verdien https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/out
        int.TryParse(input, out int personId); 
        if (name != null)
        {
            var person = new Person(personId, name); //Oppretter nytt person objekt
            persons.Add(person); //Legger til person objektet i listen
        }
    }
    Console.Write("\n");

    //Kaller visInformasjon metoden på alle person objektene i listen
    foreach (var person in persons)
    {
        person.VisInformasjon();
        Console.Write("\n");
    }
    
#endregion
#region Øvelse 2

    /*
     * Basert på øvelse 1 i Lab øvelse 2, så skal du opprette en klasse og kalle den "MatteKlasse".
     * Opprett metoder for hver matte operasjon. Opprett et objekt av klassen i Program.cs og utvid koden sånn at den tar
     * inn verdiene av tallene og operasjonen fra brukeren. Kall metodene på objektet basert på operasjonen som brukeren gir til programmet.
     */
    
    int val1, val2; //Deklarer to integers samtidig
    char operation; //Deklarer en char for å lagre operation

    Console.Write("\nEnter first number: ");
    int.TryParse(Console.ReadLine(), out val1); //Bruker tryparse for å unngå exceptions ved ugyldig input som tidligre https://www.bytehide.com/blog/tryparse-csharp

    Console.Write("Enter second number: ");
    int.TryParse(Console.ReadLine(), out val2);

    Console.Write("Enter operation (+, -, *, /): ");
    char.TryParse(Console.ReadLine(), out operation);

    //Bruker switch for å velge riktig operasjon basert på input
    switch (operation)
    {
        case '+':
            //bruker string interpolation for å formatere output og kalle metoder i en smekk https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/tokens/interpolated
            Console.WriteLine($"{val1} + {val2} = {Mathops.Add(val1, val2)}");
            break;
        case '-':
            Console.WriteLine($"{val1} - {val2} = {Mathops.Subtract(val1, val2)}");
            break;
        case '*':
            Console.WriteLine($"{val1} * {val2} = {Mathops.Multiply(val1, val2)}");
            break;
        case '/':
            if (val2 == 0) //Sjekker for deling på null før kall til Divide metoden
            {
                Console.WriteLine("Error: Division by zero is not allowed.\n");
                break;
            }
            
            Console.WriteLine($"{val1} / {val2} = {Mathops.Divide(val1, val2)}");
            break;
        default:
            Console.WriteLine("Invalid operation.");
            break;
    }

#endregion
#region Øvelse 3
    
    /*
     * Skriv en kode som tar inn en integer (heltall) verdi fra brukeren og sjekker om tallet er oddball eller parallel.
     * Koden skal skrive ut en melding til brukeren at tallet er oddball eller parallel.  
     */

    Console.Write("Enter an integer: ");
    int.TryParse(Console.ReadLine(), out int number);

    //Oddetall defineres som tall som ikke er delelig på 2, mens partall er tall som er delelig på 2.
    //Derfor bruker vi modulus operatoren (%) for å finne resten av divisjonen med 2. https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/operators/arithmetic-operators#remainder-operator-
    //Hvis resten er 0, er tallet et partall, ellers er det et oddetall.
    //Bruker ternary operator for å sjekke om tallet er oddetall eller partall og skrive ut riktig melding https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/operators/conditional-operator
    //dersom sant kjøres det første uttrykket før kolon, hvis ikke kjøres det andre uttrykket etter kolon
    Console.WriteLine(number % 2 == 0 ? $"{number} is even.\n" : $"{number} is odd.\n");

#endregion
#region Øvelse 4

    /*
     * Opprett en klasse og kall den "Student" som et institutt kan bruke til å representere informasjon som instansvariabler:
     * studentId (type string), studentNavn (type string) og tre separate variabler for poengsummer i tre fag (type decimal).
     * Klassen din bør ha en konstruktør som initialiserer de fem verdiene. Opprett Set og Get metoder for alle instansvariabler.
     * Oprett også metoder "GetAggregate()" og "GetPercentage()" som beregner de samlede poengsummene i de tre fagene
     * (summen av tre fagpoengsummer) og prosentandelen (dvs. sum delt på maksimumspoengsummen, 60, og deretter multiplisert med 100),
     * og returner deretter aggregatet og prosentandelen som desimalverdi. Skriv en kode i Program.cs som demonstrerer klassens Student-evner
     */
    
    //lager en liste for å innholde studenter, og oppretter objekter samtidig.
    //M må legges til på decimal slik kompilator vet at dette ikke er en double, samme som ved at floats må en legge til f
    var students = new List<Student>
    {
        new Student("1", "Sarumann", 20m, 18.3m, 2.32m),
        new Student("2", "Gandalf", 20m, 19.9m, 20m),
        new Student("3", "Aragorn", 15m, 14.5m, 13.2m)
    };

    //Itererer gjennom listen av studenter og skriver ut navnet, aggregat og prosentandel.
    foreach (var student in students)
    {
        //:F2 er en format specifier og brukes for å formatere desimalverdien til to desimaler https://learn.microsoft.com/en-us/dotnet/standard/base-types/standard-numeric-format-strings#the-f-format-specifier-fixed-point
        Console.WriteLine($"Student: {student.Name}, Aggregate: {student.GetAggregate():F2} points, Percentage: {student.GetPercentage():F2}%");
    }

#endregion