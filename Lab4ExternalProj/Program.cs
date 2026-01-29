// using Lab4ExternalProj;
//
// Ukommenter, sammen med referanse i lab4.csproj-filen, for å teste tilgang til internals fra et eksternt prosjekt
// var configurationManager = new Lab4.ConfigurationManager
// {
//     AppName = Lab4Application.AppName,
//     Version = Lab4Application.Version
// };

namespace Lab4ExternalProj
{
    public class Lab4ExternApp
    {
        public const string AppName = "Lab4ExternalProj";
        public static string Version { get; set; } = "1.0.0";
        
        public static void Main()
        {
            Console.WriteLine("This is an external project referenced by Lab4.");
        }
    }
}
