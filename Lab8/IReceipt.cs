namespace Lab8;

//Interfacer er fullstendig abstrakte klasser, der metoder må implementeres av arvende klasser. Interfacer kan ha default
//implementasjoner og statiske variabler. https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/interface
public interface IReceipt
{
    //Legg til docstrings på interfacer, alle implementasjoner av denne får docstringen. Funker også som god beskrivelse på hva
    //metoden er ment til å gjøre
    
    /// <summary>
    /// Generates and displays a receipt for the implementing object.
    /// The receipt typically includes details relevant to the object,
    /// such as pricing, description, or duration information.
    /// </summary>
    void PrintReceipt();
}