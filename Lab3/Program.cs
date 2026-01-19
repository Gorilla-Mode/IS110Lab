using System.Numerics;
using Lab3;

var persons = new List<Person>();

while (true)
{
    Console.WriteLine("Input person name (or type 'exit' to quit): ");
    string? name = Console.ReadLine();
    if (name == null || name.ToLower() == "exit")
    {
        break;
    }
    
    Console.WriteLine("Input person ID (or type 'exit' to quit): ");
    string? id = Console.ReadLine();
    if (id == null || name?.ToLower() == "exit")
    {
        break;
    }
    int.TryParse(id, out int personId);

    if (name != null)
    {
        var person = new Person(personId, name);
        persons.Add(person);
    }
    else
    {
        Console.WriteLine("Invalid name input. Please try again.");
    }
}