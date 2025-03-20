namespace Kontenery.Classes;

abstract class Kontener
{
    private static int Counter = 1;
    public double MasaLadunku { get; set; }
    public double Wysokosc { get; }
    public double MasaWlasna { get; }
    public double Glebokosc { get; }
    public string NumerSeryjny { get; }
    public double MaxLadownosc { get; }

    public Kontener(double wysokosc, double masaWlasna, double glebokosc, double maxLadownosc, string typ)
    {

        Wysokosc = wysokosc;
        MasaWlasna = masaWlasna;
        Glebokosc = glebokosc;
        MaxLadownosc = maxLadownosc;
        NumerSeryjny = $"KON-{typ}-{Counter++}";
    }
    public abstract void Laduj(double waga);
    public abstract void Rozladuj();
    public override string ToString()
    {
        return $"Numer seryjny: {NumerSeryjny}, Waga £adunku: {MasaLadunku} kg, Waga w³asna: {MasaWlasna} kg, Maksymalna ³adownoœæ: {MaxLadownosc} kg, Wysokoœæ: {Wysokosc}, G³êbokoœæ: {Glebokosc}";
    }
}