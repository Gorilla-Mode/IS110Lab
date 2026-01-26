namespace Lab4ExternalProj;

public static class Lab4Application
{
    public const string AppName = "Lab4ExternalProj";
    public static string Version { get; set; } = "1.0.0";
    

    public static void Main()
    {
        Console.WriteLine("This is an external project referenced by Lab4.");
    }
}