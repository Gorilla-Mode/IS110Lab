namespace Lab10Calc;

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
        for (bool run = true; run;)
        {
            Console.Clear();
            Console.WriteLine("Choose an option: ");
            Console.WriteLine("1. Add\n2. Subtract\n3. Multiply\n4. Divide\n0. Exit\n");

            if (!Enum.TryParse(Console.ReadLine(), out MenuOptions result))
            {
                InvalidOption();
                continue;
            }
            
            Action option = result switch
            {
                MenuOptions.Add      => AddNumbers,
                MenuOptions.Subtract => SubtractNumbers,
                MenuOptions.Multiply => MultiplyNumbers,
                MenuOptions.Divide   => DivideNumbers,
                MenuOptions.Exit     => () => run = false,
                _                    => InvalidOption
            };
            
            option();
        }

        int[] getInput()
        {
            Console.Write("Input first number : ");
            if (!int.TryParse(Console.ReadLine(), out int tall1))
            {
                Console.WriteLine("Invalid input");
                getInput();
            }

            Console.Write("\nInput second number: ");
            if (!int.TryParse(Console.ReadLine(), out int tall2))
            {
                Console.WriteLine("Invalid input");
                getInput();
            }
            
            return [tall1, tall2];
        }
        
        void AddNumbers()
        {
            Console.WriteLine("Add numbers");
            
            var numbers= getInput();
            Console.WriteLine($"Result: {Calculator.AddNumbers(numbers[0], numbers[1])}");
        }
    
        void SubtractNumbers()
        {
            Console.WriteLine("Subtract numbers");
            
            var numbers = getInput();
            Console.WriteLine($"Result: {Calculator.SubtractNumbers(numbers[0], numbers[1])}");
        }
    
        void MultiplyNumbers()
        {
            Console.WriteLine("Multiply numbers");
            
            var numbers = getInput();
            Console.WriteLine($"Result: {Calculator.MultiplyNumbers(numbers[0], numbers[1])}");
        }
    
        void DivideNumbers()
        {
            Console.WriteLine("Divide numbers");
            
            var numbers = getInput();
            Console.WriteLine($"Result: {Calculator.DivideNumbers(numbers[0], numbers[1])}");
        }
        
        void InvalidOption()
        {
            Console.Clear();
            Console.WriteLine("Invalid option\nPress any key to continue..");
            Console.Read();
        }
    }
}