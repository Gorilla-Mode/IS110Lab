using Lab4;
using Lab4ExternalProj;

#region Task 1
    bool task1 = true;
    var books = new List<Book>();
    while(task1)
    {
        Console.WriteLine("Task 1 - Choices:\n[1] Add book\n[2] List books\n[3] Exit\n");
        
        bool parseSuccess = byte.TryParse(Console.ReadLine(), out byte task1Choice);
        if (!parseSuccess)
        {
            Console.Clear();
            Console.WriteLine("Invalid input, please enter a number.\nPress any key to continue...\n");
            Console.ReadKey();
            Console.Clear();
            
            continue;
        }
        
        switch (task1Choice)
        {
            case 1:
                Console.Clear();
                
                Console.WriteLine("Enter book title:");
                string title = Console.ReadLine() ?? string.Empty;
                Console.WriteLine("Enter book author:");
                string author = Console.ReadLine() ?? string.Empty;
                Console.WriteLine("Enter publication year:");
                
                parseSuccess = uint.TryParse(Console.ReadLine(), out uint publicationYear);
                if (parseSuccess)
                {
                    books.Add(new Book(title, author, publicationYear));
                
                    Console.Clear();
                    Console.WriteLine("Book added successfully!\nPress any key to continue...\n");
                    Console.ReadKey();
                    Console.Clear();
                    break;
                }
                
                Console.Clear();
                Console.WriteLine("Invalid publication year. Book not added.\nPress any key to continue...\n");
                Console.ReadKey();
                
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
#endregion

#region Task 2

    bool task2 = true; 
    var users = new List<UserAccount>();
        
    while (task2)
    {
        Console.WriteLine("Task 2 - Choices:\n[1] Create account\n[2] List users\n[3] Select user\n[4] Exit\n");
        byte task2Choice = byte.Parse(Console.ReadLine() ?? string.Empty);

        switch (task2Choice)
        {
            case 1:
                Console.Clear();
                Console.WriteLine("Enter username:");
                string username = Console.ReadLine() ?? string.Empty;
                Console.WriteLine("Enter password:");
                string password = Console.ReadLine() ?? string.Empty;

                users.Add(new UserAccount(username, password));

                Console.Clear();
                Console.WriteLine("Account created successfully!\nPress any key to continue...\n");
                Console.ReadKey();
                Console.Clear();
                break;
            case 2:
                Console.Clear();
                Console.WriteLine($"Total users: {users.Count}");
                Console.WriteLine($"| {"Username",-50}| {"Created at",-50}|");
                foreach (var user in users)
                {
                    Console.WriteLine($"| {user.Username,-50}| {user.CreatedAt,-50}|");  
                }
                
                Console.WriteLine("\nPress any key to continue...\n");
                Console.ReadKey();
                Console.Clear();
                break;
            case 3:
                UserMenu();
                break;
            case 4:
                Console.Clear();
                task2 = false;
                break;
            default:
                Console.Clear();
                Console.WriteLine("Invalid choice, please try again.\n");
                break;
        }
    }
        
    void UserMenu()
    {
        Console.Clear();
        Console.WriteLine("Enter username of the account to select:");
        string selectedUsername = Console.ReadLine() ?? string.Empty;
        var selectedUser = users.Find(u => u.Username == selectedUsername);
        
        if (selectedUser == null)
        {
            Console.Clear();
            Console.WriteLine("User not found.\nPress any key to continue...\n");
            Console.ReadKey();
            Console.Clear();
            return;
        }
        
        bool userMenuActive = true;    
        while (userMenuActive)
        {
            Console.Clear();
            Console.WriteLine($"User {selectedUser.Username} selected. Select an option:\n[1] Display account info\n[2] Change password\n[3] Back to main menu\n");
            byte userMenuChoice = byte.Parse(Console.ReadLine() ?? string.Empty);

            switch (userMenuChoice)
            {
                case 1:
                    Console.Clear();
                    Console.WriteLine("Enter password to display account info:");
                    string userPwd = Console.ReadLine() ?? string.Empty;
                    selectedUser.DisplayAccountInfo(userPwd);
                
                    Console.WriteLine("\nPress any key to continue...\n");
                    Console.ReadKey();
                    Console.Clear();
                    break;
                case 2:
                    Console.Clear();
                    Console.WriteLine("Enter current password:");
                    string currentPassword = Console.ReadLine() ?? string.Empty;
                    Console.WriteLine("Enter new password:");
                
                    string newPassword = Console.ReadLine() ?? string.Empty;
                
                    Console.Clear();
                    selectedUser.ChangePassword(currentPassword, newPassword);
                
                    Console.WriteLine("\nPress any key to continue...\n");
                    Console.ReadKey();
                    Console.Clear();
                    break;
                case 3:
                    Console.Clear();
                    userMenuActive = false;
                    break;
                default:
                    Console.Clear();
                    Console.WriteLine("Invalid choice, please try again.\n");
                    Console.WriteLine("Press any key to continue...\n");
                    Console.ReadKey();
                    Console.Clear();
                    break;
            }
        }
    }

#endregion
#region Task 3

    var configManager = new ConfigurationManager
    {
        AppName = Lab4ExternApp.AppName,
        Version = Lab4ExternApp.Version
    };

    configManager.DisplayConfiguration();

#endregion
#region Task 4



#endregion