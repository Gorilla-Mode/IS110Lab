namespace Lab8;

//Legg til docstrings på interfacer, alle implementasjoner av denne får docstringen. Funker også som god beskrivelse på hva
//metoden er ment til å gjøre
public interface IReceipt
{
    /// <summary>
    /// Generates and displays a receipt for the implementing object.
    /// The receipt typically includes details relevant to the object,
    /// such as pricing, description, or duration information.
    /// </summary>
    void PrintReceipt();
}