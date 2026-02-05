namespace Lab4;

public static class ConsoleUtils
{
    /// <summary>
    /// Clears the console, displays a message, waits for a key press, and then clears the console again.
    /// </summary>
    /// <param name="message">Message to be printed</param>
    public static void DisplayMessage(string message)
    {
        Console.Clear();
        Console.WriteLine($"{message}\nPress any key to continue...\n");
        Console.ReadKey();
        Console.Clear();
    }
    
    /// <summary>
    /// Awaits for a key press after displaying a message, then clears the console.
    /// </summary>
    public static void AwaitKeyPress()
    {
        Console.WriteLine("\nPress any key to continue...\n");
        Console.ReadKey();
        Console.Clear();
    }
}