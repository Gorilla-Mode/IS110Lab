#region Øvelse 1

int value1 = 10;
int value2 = 20;

int addition = value1 + value2;
int subtraction = value2 - value1;
int multiplication = value1 * value2;
double division = (double)value2 / value1;

Console.WriteLine($"Resultat av addisjon: {addition}\nResultat av subtraksjon: {subtraction}\nResultat av multiplikasjon: {multiplication}\nResultat av divisjon: {division}\n");

#endregion

#region Øvelse 2

int weekday = 7;

if (weekday is >= 1 and <= 5)
{
    Console.WriteLine("Ukedag");
}
else if (weekday == 6 || weekday == 7)
{
    Console.WriteLine("Helg");
}
else
{
    Console.WriteLine("Ugyldig");
}

#endregion