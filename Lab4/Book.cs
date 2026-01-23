namespace Lab4;

public class Book(string title, string author, uint publicationYear)
{
    public string Title { get; set; } = title;
    public string Author { get; set; } = author;
    public uint PublicationYear { get; set; } = publicationYear;
    
    public string GetInfo()
    {
        return $"{Title} by {Author}, published in {PublicationYear}";
    }
}