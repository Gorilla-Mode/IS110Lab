namespace Lab8;

//Interfacer er fullstendig abstrakte klasser, der metoder må implementeres av arvende klasser. Interfacer kan ha default
//implementasjoner og statiske variabler. https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/interface
public interface IPayable
{
    //Legg til docstrings på interfacer, alle implementasjoner av denne får docstringen. Funker også som god beskrivelse på hva
    //metoden er ment til å gjøre
    
    /// <summary>
    /// Calculates the price for the implementing object.
    /// </summary>
    /// <returns>
    /// The total price as a double value.
    /// </returns>
    double CalculatePrice();
}