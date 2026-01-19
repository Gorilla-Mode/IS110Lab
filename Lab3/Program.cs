using Lab3;
#region Øvelse 1
    var persons = new List<Person>(); //liste for å lagre person objekter

    while (true)
    {
        Console.Write("Input person name (or type 'exit' to quit): ");
        string? name = Console.ReadLine();
        if (name == null || name.ToLower() == "exit")
        {
            break;
        }
        
        Console.Write("Input person ID (or type 'exit' to quit): ");
        string? id = Console.ReadLine();
        if (id == null || name.ToLower() == "exit")
        {
            break;
        }
        int.TryParse(id, out int personId);
        
        var person = new Person(personId, name);
        persons.Add(person);
    }
#endregion
#region Øvelse 2

    int val1, val2;
    char operation;

    Console.Write("\nEnter first number: ");
    int.TryParse(Console.ReadLine(), out val1);

    Console.Write("Enter second number: ");
    int.TryParse(Console.ReadLine(), out val2);

    Console.Write("Enter operation (+, -, *, /): ");
    char.TryParse(Console.ReadLine(), out operation);

    switch (operation)
    {
        case '+':
            Console.WriteLine($"{val1} + {val2} = {Mathops.Add(val1, val2)}");
            break;
        case '-':
            Console.WriteLine($"{val1} - {val2} = {Mathops.Subtract(val1, val2)}");
            break;
        case '*':
            Console.WriteLine($"{val1} * {val2} = {Mathops.Multiply(val1, val2)}");
            break;
        case '/':
            if (val2 == 0)
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



#endregion
#region Øvelse 4



#endregion