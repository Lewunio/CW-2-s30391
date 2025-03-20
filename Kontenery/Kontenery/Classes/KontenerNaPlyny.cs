using Kontenery.Exception;
using Kontenery.Interface;

namespace Kontenery.Classes;


class KontenerNaPlyny : Kontener, IHazardNotifier
{
    public bool CzyNiebezpieczne { get; set; }

    public KontenerNaPlyny(double wysokosc, double masaWlasna, double glebokosc, double maxLadownosc, bool czyNiebezpieczne)
        : base(wysokosc, masaWlasna, glebokosc, maxLadownosc, "L")
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
        if (CzyNiebezpieczne) limit = (MaxLadownosc * 0.5)-MasaLadunku;
        else limit = (MaxLadownosc * 0.9)-MasaLadunku;

        if (waga > limit)
        {
            NotifyHazard($"Próba przeładowania kontenera {NumerSeryjny}");
            throw new OverfillException($"Próba przeładowania kontenera {NumerSeryjny}");
        }
        MasaLadunku += waga;
    }

    public override void Rozladuj()
    {
        MasaLadunku = 0;
    }
    public override string ToString()
    {
        return base.ToString() + $", Materiał niebezpieczny: {CzyNiebezpieczne}";
    }

}