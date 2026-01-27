using System.Globalization;

namespace Lab4;

public class Employee
{
    public enum Role
    {
        Employee = 0,
        Manager,
        Director
    }
    
    private long Id { get; init; }
    public string? Name { get; set; }
    public double Salary { get; set; }
    public Role EmployeeRole { get; set; }
    
    public Employee(string? name, double salary, Role role)
    {
        if (salary < 0)
        {
            throw new ArgumentException("Salary cannot be negative.");
        }
        
        Id = Random.Shared.NextInt64();
        Name = name;
        Salary = salary;
        EmployeeRole = role;
    }
    
    public void PrintInfo()
    {
        Console.WriteLine($"| {Id, -25}| {Name, -25}| {Salary.ToString("C", CultureInfo.CreateSpecificCulture("NO")), -25}" +
                          $"| {EmployeeRole, -25}|");
    }
    
    public void ChangeSalary(double newSalary, Employee authorizer)
    {
        if (!(authorizer.EmployeeRole == Role.Manager || authorizer.EmployeeRole == Role.Director))
        {
            ConsoleUtils.DisplayMessage("Only Managers or Directors can change salaries.");
            return;
        }

        if (newSalary < 0)
        {
            ConsoleUtils.DisplayMessage("Salary cannot be negative.");
            return;
        }
        
        Salary = newSalary;
        ConsoleUtils.DisplayMessage($"Salary changed to {newSalary} successfully.");
    }
}