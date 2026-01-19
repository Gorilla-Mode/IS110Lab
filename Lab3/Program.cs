using System.Numerics;
using Lab3;

bool task1Run = true;
var persons = new Vector<Person>();

while (task1Run)
{
    Console.WriteLine("Input person ID (or type 'exit' to quit): ");
    string? input = Console.ReadLine();
    if (input != null || input?.ToLower() != "exit")
    {
        
    }
    else
    {
        task1Run = false; 
    }
}