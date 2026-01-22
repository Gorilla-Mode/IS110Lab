namespace Lab3;

/// <summary>
/// Class for basic math operations
/// </summary>
public static class Mathops
{
    public static int Add(int a, int b)
    {
        return a + b;
    }
    public static int Subtract(int a, int b)
    {
        return a - b;
    }

    public static int Multiply(int a, int b)
    {
        return a * b;
    }
    
    public static double Divide(int a, int b)
    {
        if (b == 0) //guard clause for å unngå deling på null. https://youtu.be/CFRhGnuXG-4
        {
            //kaster en exception dersom b er null. https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/statements/exception-handling-statements
            throw new DivideByZeroException("Denominator cannot be zero."); 
        }
        return (double)a / b; //Caster til double for å unngå heltallsdivisjon. https://www.delftstack.com/howto/csharp/csharp-integer-division/
    }
}