namespace Kontenery.Classes;

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
