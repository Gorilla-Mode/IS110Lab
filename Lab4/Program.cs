using Lab4;

bool task1 = true;
var books = new List<Book>();
while(task1)
{
    Console.WriteLine("Choices:\n[1] Add book\n[2] List books\n[3] Exit\n");
    byte task1Choice = byte.Parse(Console.ReadLine() ?? string.Empty);
    switch (task1Choice)
    {
        case 1:
            Console.Clear();
            
            Console.WriteLine("Enter book title:");
            string title = Console.ReadLine() ?? string.Empty;
            Console.WriteLine("Enter book author:");
            string author = Console.ReadLine() ?? string.Empty;
            Console.WriteLine("Enter publication year:");
            uint.TryParse(Console.ReadLine(), out uint publicationYear);
            
            books.Add(new Book(title, author, publicationYear));
            
            Console.Clear();
            Console.WriteLine("Book added successfully!\nPress any key to continue...\n");
            Console.ReadKey();
            Console.Clear();
            break;
        case 2:
            Console.Clear();
            Console.WriteLine("Books in collection:");
            for (int i = 0; i < books.Count; i++)
            {
                Console.WriteLine($"\t- {books[i].GetInfo()}");
            }
            Console.WriteLine("\nPress any key to continue...\n");
            Console.ReadKey();
            Console.Clear();
            break;
        case 3:
            Console.Clear();
            task1 = false;
            break;
        default:
            Console.Clear();
            Console.WriteLine("Invalid choice, please try again.\n");
            break;
    }
}