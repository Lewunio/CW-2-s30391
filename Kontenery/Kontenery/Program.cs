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
    protected double Cisnienie { get; }
    public KontenerNaGaz(double wysokosc, double masaWlasna, double glebokosc, double maxLadownosc, double cisnienie) 
        : base(wysokosc, masaWlasna, glebokosc, maxLadownosc, "G")
    {
        Cisnienie = cisnienie;
    }

    public override void Laduj(double waga)
    {
        if (waga > (MaxLadownosc-MasaLadunku))
        {
            NotifyHazard($"Próba przeładowania kontenera {NumerSeryjny}");
            throw new Exception("Overfill Exception");
        }
        MasaLadunku += waga;
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
class KontenerChlodniczy : Kontener
{
    protected string TypProduktu { get; }
    protected double Temperatura { get; }
    private static Dictionary<string, double> TemperaturaProduktow = new()
    {
        { "Bananas", 13.3 },
        { "Chocolate", 18.0 },
        { "Fish", 2.0 },
        { "Meat", -15.0 },
        { "Ice Cream", -18.0 },
        { "Frozen Pizza", -30.0 },
        { "Cheese", 7.2 },
        { "Sausages", 5.0 },
        { "Butter", 20.5 },
        { "Eggs", 19.0 }
};
    public KontenerChlodniczy(double wysokosc, double masaWlasna, double glebokosc, double maxLadownosc, string typProduktu) 
        : base(wysokosc, masaWlasna, glebokosc, maxLadownosc, "C")
    {
        TypProduktu = typProduktu;
        if (TemperaturaProduktow.ContainsKey(typProduktu)) Temperatura = TemperaturaProduktow[typProduktu];
        else
        {
            Console.WriteLine("Nieznany produkt dodaj temperature: ");
            double liczba = Convert.ToDouble(Console.ReadLine());
            TemperaturaProduktow.Add(typProduktu, liczba);
            Temperatura = liczba;
        }
    }

    public override void Laduj(double waga)
    {
        if (waga > MaxLadownosc)
        {
            Console.WriteLine("Za duza waga");
        }
        else MasaLadunku = waga;
    }

    public override void Rozladuj()
    {
        MasaLadunku = 0;
    }
}
class Statek
{
    protected List<Kontener> Zaladunek { get; } = new();
    protected double MaxPredkosc { get; }
    protected int MaxKontenerow { get; }


}
public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Hello World!");
    }
}