interface IHazardNotifier
{
    void NotifyHazard(string message);
}
abstract class Kontener
{
    private static int Counter = 1;
    private double MasaLadunku { get; set; }
    private double Wysokosc { get; }
    private double MasaWlasna { get; }
    private double Glebokosc { get; }
    private string NumerSeryjny { get; }
    private double MaxLadownosc { get; }

    public Kontener(double masaLadunku, double wysokosc, double masaWlasna, double glebokosc, double maxLadownosc, string typ)
    {
        MasaLadunku = masaLadunku;
        Wysokosc = wysokosc;
        MasaWlasna = masaWlasna;
        Glebokosc = glebokosc;
        MaxLadownosc = maxLadownosc;
        NumerSeryjny = $"KON-{typ}-{Counter++}";
    }
    public abstract void Laduj(double waga);
    public abstract void Rozladuj();
}
public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Hello World!");
    }
}