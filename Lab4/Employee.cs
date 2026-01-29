using System.Globalization;

namespace Lab4;

public class Employee
{
    // Enum for å representere ulike roller i selskapet
    // Enums gir bedre lesbarhet og debugging enn bruk av "magic numbers" eller strenger,
    // da de gir en klar definisjon av mulige verdier. https://www.w3schools.com/cs/cs_enums.php
    public enum Role
    {
        Employee = 0, // default verdi
        Manager,
        Director
    }
    
    private long Id { get; init; } // init-only property, kan kun settes under initialisering. https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/init
    public string? Name { get; set; }
    public double Salary { get; set; }
    public Role EmployeeRole { get; set; } // Bruker enum definert overq
    
    public Employee(string? name, double salary, Role role)
    {
        if (salary < 0) // Enkel validering for å sikre at lønnen ikke er negativ
        {
            throw new ArgumentException("Salary cannot be negative."); // Noen andre enn konstruktøren kan håndtere denne unntaket
        }
        
        Id = Random.Shared.NextInt64(); // Genererer et tilfeldig 64-bit tall som ID. https://learn.microsoft.com/en-us/dotnet/api/system.random?view=net-10.0
        Name = name;
        Salary = salary;
        EmployeeRole = role;
    }
    
    public void PrintInfo() // Formaterer og skriver ut ansattinformasjon i en tabellrad
    {
        // "C", CultureInfo.CreateSpecificCulture("NO") formaterer lønnen som norsk valuta. "C" betyr currency. https://www.csharptraining.co.uk/the-complete-guide-to-string-formatting-in-csharp/ 
        Console.WriteLine($"| {Id, -25}| {Name, -25}| {Salary.ToString("C", CultureInfo.CreateSpecificCulture("NO")), -25}" +
                          $"| {EmployeeRole, -25}|");
    }
    
    public void ChangeSalary(double newSalary, Employee authorizer)
    {
        //Guard clause for å sjekke om den som autoriserer lønnsendringen har riktig rolle
        if (!(authorizer.EmployeeRole == Role.Manager || authorizer.EmployeeRole == Role.Director))
        {
            ConsoleUtils.DisplayMessage("Only Managers or Directors can change salaries.");
            return;
        }

        //Guard clause for å sikre at den nye lønnen ikke er negativ
        if (newSalary < 0)
        {
            ConsoleUtils.DisplayMessage("Salary cannot be negative.");
            return;
        }
        
        Salary = newSalary; // Oppdaterer lønnen hvis alle sjekker er bestått
        ConsoleUtils.DisplayMessage($"Salary changed to {newSalary} successfully.");
    }
}