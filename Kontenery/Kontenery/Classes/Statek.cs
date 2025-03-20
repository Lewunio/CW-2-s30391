namespace Kontenery.Classes;

class Statek
{
    public static int Counter = 1;
    public int IdStatku;
    public List<Kontener> Zaladunek { get; } = new();
    public double MaxPredkosc { get; }
    public int MaxKontenerow { get; }
    public double MaxZaladunek { get; }

    public Statek(double maxPredkosc, int maxKontenerow, double maxZaladunek)
    {
        MaxPredkosc = maxPredkosc;
        MaxKontenerow = maxKontenerow;
        MaxZaladunek = maxZaladunek;
        IdStatku = Counter++;
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
        if (ZnajdzKontener(idKontenera) == null)
        {
            throw new System.Exception($"Brak kontenera {idKontenera} na statku");
        }
        if (waga+WagaZaladunku()>MaxZaladunek*1000)
        {
            throw new System.Exception("Osiągnieto max wage kontenerów");
        }
        ZnajdzKontener(idKontenera).Laduj(waga);
    }
    public void RozladujKontener(string idKontenera)
    {
        if (ZnajdzKontener(idKontenera) == null)
        {
            throw new System.Exception($"Brak kontenera {idKontenera} na statku");
        }
        ZnajdzKontener(idKontenera).Rozladuj();
    }
    public void UsunKontener(string idKontenera)
    {
        if (ZnajdzKontener(idKontenera) != null)
        {
            Zaladunek.Remove(ZnajdzKontener(idKontenera));
        }
    }
    public void ZamienKontener(Kontener kontener, string idKontenera)
    {
        if (ZnajdzKontener(idKontenera) == null)
        {
            throw new System.Exception($"Brak kontenera {idKontenera} na statku");
        }
        UsunKontener(idKontenera);
        DodajKontener(kontener);
    }
    public void PrzeniesKontener(Statek s, string idKontenera)
    {
        if (ZnajdzKontener(idKontenera) == null)
        {
            throw new System.Exception($"Brak kontenera {idKontenera} na statku");
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
        string str = $"Id statku: {IdStatku}, Max prędkość: {MaxPredkosc} węzłów, Max Kontenerów: {MaxKontenerow} sztuk, Aktualnie Kontenerów {Zaladunek.Count}, Max załadunku: {MaxZaladunek} ton, Aktualnie Załadunku: {WagaZaladunku()}: \n";
        foreach (Kontener k in Zaladunek)
        {
            str += $"{id++}. {k}\n";
        }
        return str;
    }

}
