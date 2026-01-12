#region Øvelse 1

using System.Threading.Channels;

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
    Console.WriteLine("Ukedag\n");
}
else if (weekday == 6 || weekday == 7)
{
    Console.WriteLine("Helg\n");
}
else
{
    Console.WriteLine("Ugyldig\n");
}

#endregion

#region Øving 3

int x = 10;
int y = 10;

if (x == y)
{
    Console.WriteLine("x er lik y\n");
}
else
{
    Console.WriteLine($"{Math.Max(x, y)} er størst\n");
}

#endregion