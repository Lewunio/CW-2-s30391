namespace Kontenery.Classes;

class Statek
{
    public List<Kontener> Zaladunek { get; } = new();
    public double MaxPredkosc { get; }
    public int MaxKontenerow { get; }
    public double MaxZaladunek { get; }

    public Statek(double maxPredkosc, int maxKontenerow, double maxZaladunek)
    {
        MaxPredkosc = maxPredkosc;
        MaxKontenerow = maxKontenerow;
        MaxZaladunek = maxZaladunek;
    }
    public void DodajKontener(Kontener kontener)
    {
        if (Zaladunek.Count > MaxKontenerow)
            throw new System.Exception("Osiągnięto max kontenerów");
        
        if ((WagaZaladunku() + kontener.MasaWlasna + kontener.MasaLadunku) > MaxZaladunek*1000)
            throw new System.Exception("Osiągnieto max wage kontenerów");

        Zaladunek.Add(kontener);
    }
    public void DodajListeKontenerow(List<Kontener> listaKontenerow)
    {
        foreach(Kontener k in listaKontenerow){
            DodajKontener(k);
        }
    }
    public void LadujKontener(string idKontenera, double waga)
    {
        
        if (ZnajdzKontener(idKontenera) != null && waga+WagaZaladunku()<=MaxZaladunek*1000)
        {
            ZnajdzKontener(idKontenera).Laduj(waga);
        }
    }
    public void RozladujKontener(string idKontenera)
    {
        if (ZnajdzKontener(idKontenera) != null)
        {
            ZnajdzKontener(idKontenera).Rozladuj();
        }
    }
    public void UsunKontener(string idKontenera)
    {
        if (ZnajdzKontener(idKontenera) != null)
        {
            Zaladunek.Remove(ZnajdzKontener(idKontenera));
        }
    }
    public void PrzeniesKontener(Statek s, string idKontenera)
    {
        if (ZnajdzKontener(idKontenera) == null)
        {
            throw new System.Exception("Na statku nie ma miejsca");
        }
        s.DodajKontener(ZnajdzKontener(idKontenera));
        UsunKontener(idKontenera);
    }
    public void InformacjaKontener(string idKontenera)
    {
        if (ZnajdzKontener(idKontenera) != null)
        {
            Console.WriteLine(ZnajdzKontener(idKontenera).ToString());
        }
    }
    public Kontener? ZnajdzKontener(string idKontenera)
    {
        foreach (Kontener k in Zaladunek)
            if (k.NumerSeryjny.Equals(idKontenera))
                return k;
        return null;
    }
    public double WagaZaladunku()
    {
        double waga = 0;
        foreach (Kontener k in Zaladunek)
            waga += k.MasaWlasna + k.MasaLadunku;
        return waga;
    }
    public string InformacjaStatek()
        
    {
        int id = 1;
        string str = $"Max prędkość: {MaxPredkosc} węzłów, Max Kontenerów: {MaxKontenerow} sztuk, Max załadunku: {MaxZaladunek} ton, Aktualnie Załadunku: {WagaZaladunku()}: \n";
        foreach (Kontener k in Zaladunek)
        {
            str += $"{id++}. {k}\n";
        }
        return str;
    }

}
