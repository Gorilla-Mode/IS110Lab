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
            ConsoleUtils.DisplayMessage("Invalid input, please enter a number.");
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
                if (!parseSuccess)
                {
                    ConsoleUtils.DisplayMessage("Invalid publication year. Book not added.");
                    break;
                }
                
                books.Add(new Book(title, author, publicationYear));
                ConsoleUtils.DisplayMessage("Book added successfully!");
                break;
            case 2:
                Console.Clear();
                Console.WriteLine("Books in collection:");
                for (int i = 0; i < books.Count; i++)
                {
                    Console.WriteLine($"\t- {books[i].GetInfo()}");
                }
                ConsoleUtils.AwaitKeyPress();
                break;
            case 3:
                Console.Clear();
                task1 = false;
                break;
            default:
                ConsoleUtils.DisplayMessage("Invalid choice, please try again.\n");
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
        
        bool parseSuccess = byte.TryParse(Console.ReadLine(), out byte task2Choice);
        if (!parseSuccess)
        {
            ConsoleUtils.DisplayMessage("Invalid input, please enter a number.");
            continue;
        }

        switch (task2Choice)
        {
            case 1:
                Console.Clear();
                Console.WriteLine("Enter username:");
                string username = Console.ReadLine() ?? string.Empty;
                Console.WriteLine("Enter password:");
                string password = Console.ReadLine() ?? string.Empty;

                users.Add(new UserAccount(username, password));

                ConsoleUtils.DisplayMessage("Account created successfully!");
                break;
            case 2:
                Console.Clear();
                Console.WriteLine($"Total users: {users.Count}");
                Console.WriteLine($"| {"Username",-50}| {"Created at",-50}|");
                foreach (var user in users)
                {
                    Console.WriteLine($"| {user.Username,-50}| {user.CreatedAt,-50}|");  
                }
                
                ConsoleUtils.AwaitKeyPress();
                break;
            case 3:
                UserMenu();
                break;
            case 4:
                Console.Clear();
                task2 = false;
                break;
            default:
                ConsoleUtils.DisplayMessage("Invalid choice, please try again.");
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
            ConsoleUtils.DisplayMessage("User not found.");
            return;
        }
        
        bool userMenuActive = true;    
        while (userMenuActive)
        {
            Console.Clear();
            Console.WriteLine($"User {selectedUser.Username} selected. Select an option:\n[1] Display account info\n[2] Change password\n[3] Back to main menu\n");
            
            bool parseSuccess = byte.TryParse(Console.ReadLine(), out byte userMenuChoice);
            if (!parseSuccess)
            {
                ConsoleUtils.DisplayMessage("Invalid input, please enter a number.");
                continue;
            }

            switch (userMenuChoice)
            {
                case 1:
                    Console.Clear();
                    Console.WriteLine("Enter password to display account info:");
                    string userPwd = Console.ReadLine() ?? string.Empty;
                    selectedUser.DisplayAccountInfo(userPwd);
                
                    ConsoleUtils.AwaitKeyPress();
                    break;
                case 2:
                    Console.Clear();
                    Console.WriteLine("Enter current password:");
                    string currentPassword = Console.ReadLine() ?? string.Empty;
                    Console.WriteLine("Enter new password:");
                
                    string newPassword = Console.ReadLine() ?? string.Empty;
                
                    Console.Clear();
                    selectedUser.ChangePassword(currentPassword, newPassword);
                
                    ConsoleUtils.AwaitKeyPress();
                    break;
                case 3:
                    Console.Clear();
                    userMenuActive = false;
                    break;
                default:
                    ConsoleUtils.DisplayMessage("Invalid choice, please try again.");
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

    ConsoleUtils.AwaitKeyPress();
#endregion
#region Task 4

bool task4 = true;
var employees = new List<Employee>();
    
while (task4)
{
    Console.Clear();
   
    
    Console.WriteLine("Task 4 - Choices:\n[1] Create Employee\n[2] List Employees\n[3] Change Employee Salary\n[4] Exit\n");
    
    bool parseSuccess = byte.TryParse(Console.ReadLine(), out byte task4Choice);
    if (!parseSuccess)
    {
        ConsoleUtils.DisplayMessage("Invalid input, please enter a number.");
        continue;
    }

    switch (task4Choice)
    {
        case 1:
            Console.Clear();
            Console.WriteLine("Enter employee name:");
            string name = Console.ReadLine() ?? string.Empty;
            
            Console.WriteLine("Enter employee salary:");
            parseSuccess = double.TryParse(Console.ReadLine(), out double salary);
            if (!parseSuccess)
            {
                ConsoleUtils.DisplayMessage("Invalid salary. Employee not created.");
                break;
            }
            
            Console.WriteLine("Select employee role:\n[1] Employee\n[2] Manager\n[3] Director");
            parseSuccess = byte.TryParse(Console.ReadLine(), out byte roleChoice);
            if (!parseSuccess)
            {
                ConsoleUtils.DisplayMessage("Invalid input. Enter a number.");
                break;
            }
            bool enumParseSuccess = Enum.TryParse((roleChoice - 1).ToString(), out Employee.Role role);
            if (!enumParseSuccess)
            {
                ConsoleUtils.DisplayMessage("Invalid role selection.");
                break;
            }
            
            employees.Add(new Employee(name, salary, role));
            ConsoleUtils.DisplayMessage("Employee created successfully!");
            break;
        case 2:
            Console.Clear();

            if (employees.Count == 0)
            {
                ConsoleUtils.DisplayMessage("No employees found.");
                break;
            }
            
            Console.WriteLine($"Total Employees: {employees.Count}");
            Console.WriteLine($"| {"ID",-25}| {"Name",-25}| {"Salary",-25}| {"Role",-25}|");
            foreach (var emp in employees)
            {
                emp.PrintInfo();
            }
            
            ConsoleUtils.AwaitKeyPress();
            break;
        case 3:
            Console.Clear();
            
            Console.WriteLine("Enter name of the employee whose salary you want to change:");
            string empName = Console.ReadLine() ?? string.Empty;
            var employeeToChange = employees.Find(e => e.Name == empName);
            if (employeeToChange == null)
            {
                ConsoleUtils.DisplayMessage("Employee not found.");
                break;
            }
            
            Console.WriteLine("Enter name of the authorizer (Manager or Director):");
            string authorizerName = Console.ReadLine() ?? string.Empty;
            var authorizer = employees.Find(e => e.Name == authorizerName);
            if (authorizer == null)
            {
                ConsoleUtils.DisplayMessage("Authorizer not found.");
                break;
            }
            
            Console.WriteLine("Enter new salary:");
            parseSuccess = double.TryParse(Console.ReadLine(), out double newSalary);
            if (!parseSuccess)
            {
                ConsoleUtils.DisplayMessage("Invalid salary input.");
                break;
            }
            
            employees[(employees.IndexOf(employeeToChange))].ChangeSalary(newSalary, authorizer);
            break;
        case 4:
            Console.Clear();
            task4 = false;
            break;
        default:
            ConsoleUtils.DisplayMessage("Invalid choice, please try again.");
            break;
    }
}
#endregion