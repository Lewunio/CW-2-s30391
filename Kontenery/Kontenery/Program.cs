using Kontenery.Classes;
public class Program
{
    public static void Main(string[] args)
    {
        KontenerChlodniczy kontenerChlodniczy = new(10.0, 200.5, 200.0, 1000, "Bananas");
        KontenerNaGaz kontenerNaGaz = new(15.5, 100.2, 22.5, 100, 5);
        KontenerNaPlyny kontenerNaPlyny = new(7.2,15,8.2,75,true);
        KontenerNaPlyny kontenerNaPlyny2 = new(7.2,15,8.2,75,false);

        Console.WriteLine("Test kontenera\n");
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

        Console.WriteLine("\nTest info o Kontenerze na statku\n");
        statek.InformacjaKontener("KON-C-1");

    }
}