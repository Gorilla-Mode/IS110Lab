using System.Reflection.Emit;

namespace Lab4;

internal class ConfigurationManager
{
    public required string AppName { get; init; }
    public string? Version { get; set; }
    
    public void DisplayConfiguration()
    {
        Console.WriteLine($"Application Name: {AppName}\nVersion: {Version}");
    }
}
