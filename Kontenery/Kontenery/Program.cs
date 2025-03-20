using Kontenery.Classes;
public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Test kontenera\n");
        KontenerChlodniczy kontenerChlodniczy = new(10.0, 200.5, 200.0, 1000, "Bananas");
        KontenerNaGaz kontenerNaGaz = new(15.5, 100.2, 22.5, 100, 5);
        KontenerNaPlyny kontenerNaPlyny = new(7.2,15,8.2,75,true);
        KontenerNaPlyny kontenerNaPlyny2 = new(7.2,15,8.2,75,false);
        
        Console.WriteLine(kontenerNaGaz.NumerSeryjny);
        try
        {
            kontenerChlodniczy.Laduj(3000.0);
        } catch (Exception e)
        {
            Console.WriteLine(e.ToString()+"\n");
        }
        kontenerChlodniczy.Laduj(10);
        Console.WriteLine(kontenerChlodniczy);
        kontenerChlodniczy.Rozladuj();
        Console.WriteLine(kontenerChlodniczy);

        Console.WriteLine("\nTest statku cz1\n");
        Statek statek = new(10, 5, 2);
        statek.DodajKontener(kontenerChlodniczy);
        Console.WriteLine(statek.InformacjaStatek());

        Console.WriteLine("\nTest Kontenera na statku\n");
        statek.InformacjaKontener("KON-C-1");
        
        try
        {
            statek.LadujKontener("KON-C-1", 1799.5);
        } catch (Exception e)
        {
            Console.WriteLine(e.ToString() + "\n");
        }
        statek.LadujKontener("KON-C-1", 17);
        statek.InformacjaKontener("KON-C-1");

        statek.UsunKontener("KON-C-1");
        Console.WriteLine(statek.InformacjaStatek());

        Statek statek2 = new(2, 2, 1);
        statek.DodajKontener(kontenerNaGaz);
        Console.WriteLine(statek.InformacjaStatek());
        statek.PrzeniesKontener(statek2, "KON-G-2");
        Console.WriteLine(statek.InformacjaStatek());
        Console.WriteLine(statek2.InformacjaStatek());

        statek2.ZamienKontener(kontenerNaPlyny2, "KON-G-2");
        Console.WriteLine(statek2.InformacjaStatek());

        List<Kontener> listaKontenerow = new();
        listaKontenerow.Add(kontenerNaPlyny);
        listaKontenerow.Add(kontenerNaGaz);
        listaKontenerow.Add(kontenerChlodniczy);

        statek.DodajListeKontenerow(listaKontenerow);
        Console.WriteLine(statek.InformacjaStatek());

    }
}