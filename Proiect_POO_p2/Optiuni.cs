namespace Proiect_POO_p2;

public class Optiuni
{
   
    public static int Citeste()
    {
        string input = Console.ReadLine();
        if (int.TryParse(input, out int rezultat))
        {
            return rezultat;
        }
        
        Console.WriteLine("Eroare: Te rugăm să introduci un număr valid.");
        return -1; 
    }
}
