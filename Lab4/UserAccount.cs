namespace Lab4;

public class UserAccount
{
    private List<string> _usedPasswords = new List<string>();
    private string _password;
    public string Username { get; private set; } 
    public DateTime CreatedAt { get; init; }
    
    public UserAccount(string username, string password)
    {
        Username = username;
        _password = password;
        CreatedAt = DateTime.Now;
        
        _usedPasswords.Add(password);
    }
    
    public void ChangePassword(string oldPassword, string newPassword)
    {
        if (_usedPasswords.Contains(newPassword))
        {
            Console.WriteLine("This password has been used before. Please choose a different password.");
            return;
        }
        if (oldPassword != _password)
        {
            Console.WriteLine("Enter current password to change password:");
            return;
        }
        
        _password = newPassword;
        _usedPasswords.Add(newPassword);
        Console.WriteLine("Password changed successfully.");
    }
    
   public void DisplayAccountInfo(string password)
   {
       if (password != _password)
       {
           Console.WriteLine("Incorrect password.");
           return;
       }
       
       Console.WriteLine($"Username: {Username}\nAccount Created At: {CreatedAt}\nCompleted Password Changes: {_usedPasswords.Count - 1}" +
                         $"\nCurrent Password: {_password}");
   }
}