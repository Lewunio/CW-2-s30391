namespace Kontenery.Classes;

abstract class Kontener
{
    private static int Counter = 1;
    protected double MasaLadunku { get; set; }
    protected double Wysokosc { get; }
    protected double MasaWlasna { get; }
    protected double Glebokosc { get; }
    protected string NumerSeryjny { get; }
    protected double MaxLadownosc { get; }

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
}