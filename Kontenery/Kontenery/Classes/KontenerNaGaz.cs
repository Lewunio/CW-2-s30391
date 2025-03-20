using Kontenery.Interface;
using Kontenery.Exception;

namespace Kontenery.Classes;


class KontenerNaGaz : Kontener, IHazardNotifier
{
    public double Cisnienie { get; }
    public KontenerNaGaz(double wysokosc, double masaWlasna, double glebokosc, double maxLadownosc, double cisnienie)
        : base(wysokosc, masaWlasna, glebokosc, maxLadownosc, "G")
    {
        Cisnienie = cisnienie;
    }

    public override void Laduj(double waga)
    {
        if (waga > (MaxLadownosc - MasaLadunku))
        {
            NotifyHazard($"Próba przeładowania kontenera {NumerSeryjny}");
            throw new OverfillException($"Próba przeładowania kontenera {NumerSeryjny}");
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
    public override string ToString()
    {
        return base.ToString() + $", Ciśnienie: {Cisnienie} atm";
    }

}

