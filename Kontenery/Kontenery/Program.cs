interface IHazardNotifier
{
    void NotifyHazard(string message);
}
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
class KontenerNaPlyny : Kontener, IHazardNotifier
{
    protected bool CzyNiebezpieczne { get; set; }

    public KontenerNaPlyny(double wysokosc, double masaWlasna, double glebokosc, double maxLadownosc, bool czyNiebezpieczne)
        : base(wysokosc,masaWlasna,glebokosc,maxLadownosc,"L")
    {
        CzyNiebezpieczne = czyNiebezpieczne;
    }

    public void NotifyHazard(string message)
    {
        Console.WriteLine($"ALERT! {message}");
    }

    public override void Laduj(double waga)
    {
        double limit;
        if (CzyNiebezpieczne) limit = MaxLadownosc * 0.5;
        else limit = MaxLadownosc * 0.9;

        if(waga > limit)
        {
            NotifyHazard($"Próba przeładowania kontenera {NumerSeryjny}");
            throw new Exception("Overfill Exception");
        }
        MasaLadunku = waga;
    }

    public override void Rozladuj()
    {
        MasaLadunku = 0;
    }
}
class KontenerNaGaz : Kontener, IHazardNotifier
{
    protected double Cisnienie;
    public KontenerNaGaz(double wysokosc, double masaWlasna, double glebokosc, double maxLadownosc, double cisnienie) 
        : base(wysokosc, masaWlasna, glebokosc, maxLadownosc, "G")
    {
        Cisnienie = cisnienie;
    }

    public override void Laduj(double waga)
    {
        if (waga > MaxLadownosc)
        {
            NotifyHazard($"Próba przeładowania kontenera {NumerSeryjny}");
            throw new Exception("Overfill Exception");
        }
        MasaLadunku = waga;
    }

    public void NotifyHazard(string message)
    {
        Console.WriteLine($"ALERT! {message}");
    }

    public override void Rozladuj()
    {
        MasaLadunku *= 0.05;
    }
}
public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Hello World!");
    }
}