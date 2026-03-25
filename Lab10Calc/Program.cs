namespace Lab10Calc;

//Viser litt ekstra  om hvordan en kan håndtere bruker input

/// <summary>
/// Enum med meny valg
/// </summary>
enum MenuOptions
{
    Exit = 0,
    Add,
    Subtract,
    Multiply,
    Divide
}

static class Program
{
    public static void Main(string[] args)
    {
        for (bool run = true; run;) //Basically en while loop, men der iterator har scope til kun loopen. Ikke veldig praktisk, men en mulighet 
        {
            Console.Clear();
            Console.WriteLine("Choose an option: ");
            Console.WriteLine("1. Add\n2. Subtract\n3. Multiply\n4. Divide\n0. Exit\n");

            //Sjekker at input fra bruker, kan parses til den definerte enumen
            if (!Enum.TryParse(Console.ReadLine(), out MenuOptions result))
            {
                InvalidOption();
                continue;
            }
            
            //Switch expression, mapper enum verdi til metode. Action enkapsulerer metoden, slik at den kan kalles direkte.
            //Fordelen med en switch expression ovenfor switch statement, er den er exhaustive, du vil få en warnning
            //hvis du ikke håndterer alle mulige enum verdier. Den kan være mer knotete å holde på med enn switch statement,
            //siden den må returnere noe.
            Action option = result switch
            {
                MenuOptions.Add      => AddNumbers,
                MenuOptions.Subtract => SubtractNumbers,
                MenuOptions.Multiply => MultiplyNumbers,
                MenuOptions.Divide   => DivideNumbers,
                MenuOptions.Exit     => () => run = false, //Lambda expression, slik at den kan kalles direkte
                _                    => InvalidOption
            };
            
            option(); //Kaller den valgte metoden
        }

        int[] GetInput() //Håndter input fra brukeren 
        {
            Console.Write("Input first number : ");
            if (!int.TryParse(Console.ReadLine(), out int tall1))
            {
                throw new Exception("Invalid input"); //Kaster exception, siden denne metoden ikke skal håndtere det
            }

            Console.Write("\nInput second number: ");
            if (!int.TryParse(Console.ReadLine(), out int tall2))
            {
                throw new Exception("Invalid input"); 
            }
            
            return [tall1, tall2];
        }
        
        void AddNumbers()
        {
            Console.WriteLine("Add numbers");
            try //Bruker try-catch for å håndtere input feil
            {
                var numbers = GetInput();
                Console.WriteLine($"Result: {Calculator.AddNumbers(numbers[0], numbers[1])}");
                Console.ReadLine();
            }
            catch (Exception e) //Fanger alle exception, siden her vil vi bare be om nytt input fra bruker
            {
                Console.WriteLine(e.Message); //Returner eller thrower ikke, siden her ønsker vi bare om å få nytt input fra brukeren.
                Console.ReadLine(); //IKKE bruk Console.Read(), den tømmer ikke bufferen. Dvs at neste read/readline, tar med newline/carrige fra bufferen og går videre uten å vente på input.
            }
        }
    
        void SubtractNumbers()
        {
            Console.WriteLine("Subtract numbers");

            try
            {
                var numbers = GetInput();
                Console.WriteLine($"Result: {Calculator.SubtractNumbers(numbers[0], numbers[1])}");
                Console.ReadLine();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.ReadLine(); 
            }
        }
    
        void MultiplyNumbers()
        {
            Console.WriteLine("Multiply numbers");
            
            try
            {
                var numbers = GetInput();
                Console.WriteLine($"Result: {Calculator.MultiplyNumbers(numbers[0], numbers[1])}");
                Console.ReadLine();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.ReadLine();
            }
        }
    
        void DivideNumbers()
        {
            Console.WriteLine("Divide numbers");
            
            try
            {
                var numbers = GetInput();
                Console.WriteLine($"Result: {Calculator.DivideNumbers(numbers[0], numbers[1])}");
                Console.ReadLine();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message); 
                Console.ReadLine(); 
            }
        }
        
        void InvalidOption()
        {
            Console.Clear();
            Console.WriteLine("Invalid option\nPress any key to continue..");
            Console.ReadLine();
        }
    }
}