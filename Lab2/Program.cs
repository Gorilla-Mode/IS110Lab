
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

#region Øving 4

    var person1 = new Person(1, "Saruman", "Orthanc, Isengard", new DateOnly(9, 6, 7));

    person1.WriteInfo();

    class Person
    {
        public ulong Id { get; private set; }
        public string Name { get; private set; }
        public string Address { get; private set; }
        public DateOnly Birthdate { get; private set; }
        
        public Person(ulong id, string name, string address, DateOnly birthdate)
        {
            Id = id;
            Name = name;
            Address = address;
            Birthdate = birthdate;
        }

        public void WriteInfo()
        {
            Console.WriteLine($"ID: {Id}\nNavn: {Name}\nAdresse: {Address}\nFødselsdato: {Birthdate.ToString("dd/MMMM/yyyy")}\n");
        }
        
    }

    #endregion