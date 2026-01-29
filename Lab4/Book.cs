namespace Lab4;

public class Book(string title, string author, uint publicationYear) // Primary constructor, enkel måte å initialisere properties. https://learn.microsoft.com/en-us/dotnet/csharp/whats-new/tutorials/primary-constructors 
{
    public string Title { get; set; } = title; // "= title" refererer til parameteren i den primære konstruktøren
    public string Author { get; set; } = author;
    public uint PublicationYear { get; set; } = publicationYear;
    
    public string GetInfo()
    {
        return $"{Title} by {Author}, published in {PublicationYear}";
    }
}