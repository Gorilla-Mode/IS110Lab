using Lab4;
using Lab4ExternalProj;

//Lagt til noe ekstra funksjonalitet til laben med bruker input validering og bedre meny navigasjon.

#region Task 1

    // Øvelse 1: Lag en klasse som representerer en Book.
    // Klassen skal ha:
    //   Tittel
    //   Forfatter
    //   Utgivelsesår
    // Krav:
    //   Bruk auto-implementerte egenskaper
    //   Alle egenskapene skal være tilgjengelige utenfra klassen
    //   Klassen skal kunne brukes fra Program.cs

    bool task1 = true; // Kontoll variabel for while-løkken, unngå while(true)
    var books = new List<Book>(); // Liste for å lagre bøker
    while(task1)
    {
        Console.WriteLine("Task 1 - Choices:\n[1] Add book\n[2] List books\n[3] Exit\n");
        
        //Bruker tryparse, retunerer true/false basert på om konverteringen var vellykket. Unngår å bruke exceptions, og kan
        //heller sjekke med enkel if. https://learn.microsoft.com/en-us/dotnet/api/system.int32.tryparse?view=net-10.0
        //Parser til byte siden valgene er få og små tall. byte går fra 0-255, ved å bruke unsigned vil tryparse feile på negative tall.
        //Og vi slipper å sjekke for det selv. https://www.geeksforgeeks.org/digital-logic/basics-of-signed-binary-numbers-of-ranges-of-different-datatypes/
        //out gir tryparse en referanse til hvilken variabel som skal ha den parset verdien. https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/out
        bool parseSuccess = byte.TryParse(Console.ReadLine(), out byte task1Choice); 
        if (!parseSuccess) //Sjekker om parsing var vellykket, hvis ikke starter while-løkken på nytt
        {
            ConsoleUtils.DisplayMessage("Invalid input, please enter a number."); //Se ConsoleUtils.cs for mer info
            continue; //Går til starten av while-løkken igjen
        }
        
        switch (task1Choice)
        {
            case 1:
                Console.Clear(); //Rydder konsollen for bedre lesbarhet
                Console.WriteLine("Enter book title:");
                string title = Console.ReadLine() ?? string.Empty; // ?? null-coalescing operator for å unngå null verdier. https://www.geeksforgeeks.org/c-sharp/null-coalescing-operator-in-c-sharp/
                
                Console.WriteLine("Enter book author:");
                string author = Console.ReadLine() ?? string.Empty;
                
                Console.WriteLine("Enter publication year:");
                parseSuccess = uint.TryParse(Console.ReadLine(), out uint publicationYear); //Som tidligre bruker vi TryParse for å håndtere ugyldig input
                if (!parseSuccess) //Dersom parsing feilet, bryt ut av switch-casen
                {
                    ConsoleUtils.DisplayMessage("Invalid publication year. Book not added.");
                    break; //Bryter ut av casen
                }
                
                books.Add(new Book(title, author, publicationYear)); //Legger til ny bok i listen
                ConsoleUtils.DisplayMessage("Book added successfully!");
                break;
            case 2:
                Console.Clear();
                Console.WriteLine("Books in collection:");
                //Lister ut info til bøkene i listen ved å kalle GetInfo metoden på hver bok med indeksering
                for (int i = 0; i < books.Count; i++)
                {
                    Console.WriteLine($"\t- {books[i].GetInfo()}"); // \t escape sequence for tab for bedre lesbarhet. https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/strings/#string-escape-sequences
                }
                
                ConsoleUtils.AwaitKeyPress(); // Se ConsoleUtils.cs for mer info
                break;
            case 3:
                Console.Clear();
                task1 = false; //Setter kontroll variabel til false for å bryte ut av while-løkken
                break;
            default: //Håndterer ugyldige valg
                ConsoleUtils.DisplayMessage("Invalid choice, please try again.\n");
                break;
        }
    }
#endregion
#region Task 2
    
    // Øvelse 2: Lag en klasse UserAccount som representerer en bruker i et system.
    // Klassen skal ha:
    //   Brukernavn
    //   Passord
    //   Dato for opprettelse
    // 
    // Krav:
    // Bruk auto-implementerte egenskaper
    //   Bruk tilgangsmodifikatorer slik at:
    //     Brukernavn kan leses utenfra, men ikke endres
    //     Passord ikke kan leses eller endres direkte utenfra klassen
    //   Lag minst én metode som på en kontrollert måte endrer passordet

    bool task2 = true; // Kontoll variabel for while-løkken
    var users = new List<UserAccount>(); // Liste for å lagre brukere
        
    while (task2)
    {
        Console.WriteLine("Task 2 - Choices:\n[1] Create account\n[2] List users\n[3] Select user\n[4] Exit\n");
        
        //Som tidligre bruker vi TryParse for å håndtere ugyldig input
        bool parseSuccess = byte.TryParse(Console.ReadLine(), out byte task2Choice);
        if (!parseSuccess)
        {
            ConsoleUtils.DisplayMessage("Invalid input, please enter a number.");
            continue;
        }

        switch (task2Choice)
        {
            case 1:
                Console.Clear();
                Console.WriteLine("Enter username:");
                string username = Console.ReadLine() ?? string.Empty; // ?? null-coalescing operator for å unngå null verdier
                Console.WriteLine("Enter password:");
                string password = Console.ReadLine() ?? string.Empty;

                users.Add(new UserAccount(username, password)); //Legger til ny bruker i listen

                ConsoleUtils.DisplayMessage("Account created successfully!");
                break;
            case 2:
                Console.Clear();
                Console.WriteLine($"Total users: {users.Count}"); //.Count gir antall elementer i listen. https://learn.microsoft.com/en-us/dotnet/api/system.linq.enumerable.count?view=net-10.0
                Console.WriteLine($"| {"Username",-50}| {"Created at",-50}|"); //Formatterer output i tabell format, venstrejustert med 50 tegn bredde. https://www.csharptraining.co.uk/the-complete-guide-to-string-formatting-in-csharp/
                foreach (var user in users) //Lister ut info til brukerne i listen ved å iterere gjennom listen
                {
                    Console.WriteLine($"| {user.Username,-50}| {user.CreatedAt,-50}|");  
                }
                
                ConsoleUtils.AwaitKeyPress();
                break;
            case 3:
                UserMenu(); //Kaller UserMenu metoden for å håndtere bruker spesifikke operasjoner, Flyttet til egen metode for å unngå dyp nesting.
                break;
            case 4:
                Console.Clear();
                task2 = false; //Setter kontroll variabel til false for å bryte ut av while-løkken
                break;
            default: //Håndterer ugyldige valg
                ConsoleUtils.DisplayMessage("Invalid choice, please try again.");
                break;
        }
    }
    
    // Metode for å håndtere bruker spesifikke operasjoner
    void UserMenu()
    {
        Console.Clear();
        Console.WriteLine("Enter username of the account to select:");
        string selectedUsername = Console.ReadLine() ?? string.Empty; // ?? null-coalescing operator for å unngå null verdier
        
        //.Find søker gjennom listen og returnerer det første elementet som matcher betingelsen. https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1.find?view=net-10.0
        //Lambda utrykket u => u.Username == selectedUsername definerer betingelsen for søket. https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/operators/lambda-expressions
        //Uttrykket leses som "for hver bruker u i listen, sjekk om u.Username er lik selectedUsername"
        var selectedUser = users.Find(u => u.Username == selectedUsername);
        
        if (selectedUser == null) //Dersom null, betyr det at ingen bruker ble funnet med det brukernavnet
        {
            ConsoleUtils.DisplayMessage("User not found.");
            return; //Bryter ut av metoden
        }
        
        bool userMenuActive = true; // Kontroll variabel for while-løkken i bruker menyen
        while (userMenuActive)
        {
            Console.Clear();
            Console.WriteLine($"User {selectedUser.Username} selected. Select an option:\n[1] Display account info\n[2] Change password\n[3] Back to main menu\n");
            
            bool parseSuccess = byte.TryParse(Console.ReadLine(), out byte userMenuChoice); //Som tidligre bruker vi TryParse for å håndtere ugyldig input
            if (!parseSuccess) //Dersom parsing feilet, start while-løkken på nytt
            {
                ConsoleUtils.DisplayMessage("Invalid input, please enter a number.");
                continue;
            }

            switch (userMenuChoice)
            {
                case 1:
                    Console.Clear();
                    Console.WriteLine("Enter password to display account info:");
                    string userPwd = Console.ReadLine() ?? string.Empty; // ?? null-coalescing operator for å unngå null verdier
                    selectedUser.DisplayAccountInfo(userPwd); //Kaller DisplayAccountInfo metoden på den valgte brukeren
                
                    ConsoleUtils.AwaitKeyPress();
                    break;
                case 2:
                    Console.Clear();
                    Console.WriteLine("Enter current password:");
                    string currentPassword = Console.ReadLine() ?? string.Empty;
                    Console.WriteLine("Enter new password:");
                
                    string newPassword = Console.ReadLine() ?? string.Empty;
                
                    Console.Clear();
                    selectedUser.ChangePassword(currentPassword, newPassword); //Kaller ChangePassword metoden på den valgte brukeren
                
                    ConsoleUtils.AwaitKeyPress();
                    break;
                case 3:
                    Console.Clear();
                    userMenuActive = false; //Setter kontroll variabel til false for å bryte ut av while-løkken og gå tilbake til hovedmenyen
                    break;
                default: //Håndterer ugyldige valg
                    ConsoleUtils.DisplayMessage("Invalid choice, please try again.");
                    break;
            }
        }
    }

#endregion
#region Task 3
    
    // Øvelse 3: Du jobber i et system som består av flere prosjekter. Lag en klasse ConfigurationManager som:
    //   Ikke skal være tilgjengelig fra andre prosjekter
    //   Har egenskaper for:
    //   Applikasjonsnavn
    //   Versjonsnummer
    // Krav:
    //   Bruk internal der det er hensiktsmessig
    //   Bruk auto-implementerte egenskaper
    //   Klassen skal kunne brukes fritt innenfor samme prosjekt

    //Object initializer syntax for å initializer egenskaper ved opprettelse av objektet. https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/object-and-collection-initializers
    var configManager = new ConfigurationManager
    {
        AppName = Lab4ExternApp.AppName, //Tilgang til konstanten AppName fra det eksterne prosjektet
        Version = Lab4ExternApp.Version
    };

    configManager.DisplayConfiguration(); //Kaller DisplayConfiguration metoden for å vise konfigurasjonsinfo

    ConsoleUtils.AwaitKeyPress();
#endregion
#region Task 4
    
    // Øvelse 4: Design en klasse Employee for et HR-system.
    // Klassen skal ha:
    //   Ansattnummer
    //   Navn
    //   Månedslønn
    // Krav:
    //   Ansattnummer skal ikke kunne endres etter at objektet er opprettet
    //   Månedslønn skal ikke kunne endres direkte utenfra klassen
    //   Alle data skal være tilgjengelige for lesing der det er fornuftig
    //   Bruk auto-implementerte egenskaper

bool task4 = true; // Kontoll variabel for while-løkken
var employees = new List<Employee>(); // Liste for å lagre ansatte
    
while (task4)
{
    Console.Clear();
    Console.WriteLine("Task 4 - Choices:\n[1] Create Employee\n[2] List Employees\n[3] Change Employee Salary\n[4] Exit\n");
    
    bool parseSuccess = byte.TryParse(Console.ReadLine(), out byte task4Choice); //Som tidligre bruker vi TryParse for å håndtere ugyldig input
    if (!parseSuccess)
    {
        ConsoleUtils.DisplayMessage("Invalid input, please enter a number.");
        continue;
    }

    switch (task4Choice)
    {
        case 1:
            Console.Clear();
            Console.WriteLine("Enter employee name:");
            string name = Console.ReadLine() ?? string.Empty; // ?? null-coalescing operator for å unngå null verdier
            
            Console.WriteLine("Enter employee salary:");
            parseSuccess = double.TryParse(Console.ReadLine(), out double salary);
            if (!parseSuccess) //Dersom parsing feilet, bryt ut av switch-casen
            {
                ConsoleUtils.DisplayMessage("Invalid salary. Employee not created.");
                break;
            }
            
            Console.WriteLine("Select employee role:\n[1] Employee\n[2] Manager\n[3] Director");
            parseSuccess = byte.TryParse(Console.ReadLine(), out byte roleChoice); // Sjekker gyldig valg
            if (!parseSuccess)
            {
                ConsoleUtils.DisplayMessage("Invalid input. Enter a number.");
                break;
            }
            // Sjekker også at verdien kan castes til enum, Se employee.cs for mer info om enum
            // .IsDefined sjekker om en verdi er definert i enumet. https://learn.microsoft.com/en-us/dotnet/api/system.enum.isdefined?view=net-10.0
            // typeof henter system.type objektet for enumet Employee.Role. Dette er nødvendig for IsDefined metoden. https://www.geeksforgeeks.org/c-sharp/typeof-operator-keyword-in-c-sharp/
            // -1 fordi enum starter på 0
            if (!Enum.IsDefined(typeof(Employee.Role), roleChoice - 1))
            {
                ConsoleUtils.DisplayMessage("Invalid role selection.");
                break;
            }
            
            employees.Add(new Employee(name, salary, (Employee.Role)roleChoice)); //Legger til ny ansatt i listen
            ConsoleUtils.DisplayMessage("Employee created successfully!");
            break;
        case 2:
            Console.Clear();

            //Sjekker om det finnes ansatte i listen
            if (employees.Count == 0)
            {
                ConsoleUtils.DisplayMessage("No employees found.");
                break;
            }
            
            Console.WriteLine($"Total Employees: {employees.Count}");
            Console.WriteLine($"| {"ID",-25}| {"Name",-25}| {"Salary",-25}| {"Role",-25}|"); //Formatterer output i tabell format, venstrejustert med 25 tegn bredde. https://www.csharptraining.co.uk/the-complete-guide-to-string-formatting-in-csharp/
            foreach (var emp in employees) //Lister ut info til de ansatte i listen ved å iterere gjennom listen
            {
                emp.PrintInfo();
            }
            
            ConsoleUtils.AwaitKeyPress();
            break;
        case 3:
            Console.Clear();
            
            Console.WriteLine("Enter name of the employee whose salary you want to change:");
            string empName = Console.ReadLine() ?? string.Empty; // ?? null-coalescing operator for å unngå null verdier
            var employeeToChange = employees.Find(e => e.Name == empName); //Som tidligre, bruker .Find med lambda uttrykk for å finne den ansatte som skal få endret lønnen
            if (employeeToChange == null) //Dersom null, betyr det at ingen ansatt ble funnet med det navnet
            {
                ConsoleUtils.DisplayMessage("Employee not found.");
                break;
            }
            
            Console.WriteLine("Enter name of the authorizer (Manager or Director):");
            string authorizerName = Console.ReadLine() ?? string.Empty; // ?? null-coalescing operator for å unngå null verdier
            var authorizer = employees.Find(e => e.Name == authorizerName); //Som tidligre, bruker .Find med lambda uttrykk for å finne den ansatte som skal autorisere lønnsendringen
            if (authorizer == null) //Dersom null, betyr det at ingen ansatt ble funnet med det navnet
            {
                ConsoleUtils.DisplayMessage("Authorizer not found.");
                break;
            }
            
            Console.WriteLine("Enter new salary:");
            parseSuccess = double.TryParse(Console.ReadLine(), out double newSalary); //Sjekker gyldig input for ny lønn
            if (!parseSuccess)
            {
                ConsoleUtils.DisplayMessage("Invalid salary input.");
                break;
            }
            
            //Kaller ChangeSalary metoden på den ansatte som skal få endret lønnen
            //Bruke indeksering med [] på objektet som metoden skal kalles på.
            //.indexOf finner indeksen til objektet i listen som vi hentet tidligre. https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1.indexof?view=net-10.0
            employees[(employees.IndexOf(employeeToChange))].ChangeSalary(newSalary, authorizer);
            break;
        case 4:
            Console.Clear();
            task4 = false; //Setter kontroll variabel til false for å bryte ut av while-løkken
            break;
        default: //Håndterer ugyldige valg
            ConsoleUtils.DisplayMessage("Invalid choice, please try again.");
            break;
    }
}
#endregion