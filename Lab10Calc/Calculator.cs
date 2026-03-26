namespace Lab10Calc;

public static class Calculator
{
    public static double AddNumbers(int tall1, int tall2)
    {
        return tall1 + tall2;
    }

    public static double SubtractNumbers(int tall1, int tall2)
    {
        return tall1 - tall2;
    }

    public static double MultiplyNumbers(int tall1, int tall2)
    {
        return tall1 * tall2;
    }

    public static double DivideNumbers(int tall1, int tall2)
    {
        if (tall2 == 0)
        {
            throw new DivideByZeroException("Division by zero is undefined.");
        }
        
        return tall1 / (double)tall2;
    }
}