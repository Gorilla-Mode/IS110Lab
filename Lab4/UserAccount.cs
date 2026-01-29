namespace Lab4;

public class UserAccount
{
    private readonly List<string> _usedPasswords = new List<string>(); // Lagrer tidligere brukte passord
    private string _password; 
    public string Username { get; private set; } // privat setter, kan kun endres innenfor klassen
    public DateTime CreatedAt { get; init; }
    
    public UserAccount(string username, string password)
    {
        Username = username;
        _password = password;
        CreatedAt = DateTime.Now; // Setter opprettelsestidspunkt til nåværende tid
        _usedPasswords.Add(password); // Legger til det opprinnelige passordet i listen over brukte passord
    }
    
    public void ChangePassword(string oldPassword, string newPassword)
    {
        if (_usedPasswords.Contains(newPassword)) // Guard clause for å sjekke om passordet er brukt før
        {
            Console.WriteLine("This password has been used before. Please choose a different password.");
            return;
        }
        if (oldPassword != _password) // Guard clause for å sjekke om det gamle passordet er korrekt
        {
            Console.WriteLine("Enter current password to change password:");
            return;
        }
        
        _password = newPassword; // Oppdaterer passordet hvis alle sjekker er bestått
        _usedPasswords.Add(newPassword); // Legger til det nye passordet i listen over brukte passord
        Console.WriteLine("Password changed successfully.");
    }
    
   public void DisplayAccountInfo(string password)
   {
       if (password != _password) // Guard clause for å sjekke om passordet er korrekt
       {
           Console.WriteLine("Incorrect password.");
           return;
       }
       
       // -1 fordi det opprinnelige passordet også er lagret i listen
       Console.WriteLine($"Username: {Username}\nAccount Created At: {CreatedAt}\nCompleted Password Changes: {_usedPasswords.Count - 1}" +
                         $"\nCurrent Password: {_password}");
   }
}