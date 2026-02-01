using Infrastructura.Configuration;

namespace Proiect_POO_p2;
using System.Text.Json;

public class ManagerAbonamente
{
    public static void CumparaAbonament()
    {
        //Afisare Parcari
        string ParcariJson = File.ReadAllText("ParcariData.json");
        List<ZonaParcare> ListaZona = JsonSerializer.Deserialize<List<ZonaParcare>>(ParcariJson, JsonOptions.Create());

        foreach (var parcare in ListaZona)
        {
            Console.WriteLine($"Parcare {parcare.Id},");
            foreach (var locParcare in parcare.Locuri)
            {
                Console.WriteLine($"Loc parcare {locParcare.Id}");
            }
        }
        
        //Alege Zona, locul
        Console.WriteLine("Alege Id-ul parcarii dorite: ");
        int IdZona  = int.Parse(Console.ReadLine());

        ZonaParcare ZonaAleasa = null;
        for (int i=0; i < ListaZona.Count; i++)
        {
            if (IdZona == ListaZona[i].Id)
            {
                ZonaAleasa =  ListaZona[i];    
            }
        }
        if (ZonaAleasa == null)
        {
            Console.WriteLine("Parcarea nu există.");
            return;
        }
        
        
        Console.WriteLine("Alege Id-ul locului de parcare dorit: ");
        int IdLoc = int.Parse(Console.ReadLine());

        LocParcare LocAles = null;
        for (int i = 0; i < ZonaAleasa.Locuri.Count; i++)
        {
            if (ZonaAleasa.Locuri[i].Id == IdLoc)
            {
                LocAles = ZonaAleasa.Locuri[i];
            }
        }
        if (LocAles == null)
        {
            Console.WriteLine("Parcarea nu există.");
            return;
        }
        
        //Alege tipul de abonament
        string tipAbonament;
        do
        {
            Console.WriteLine("Alege tipul de abonament (zi)/(luna)/(an): ");
            tipAbonament = Console.ReadLine()?.ToLower();
            
        } while (tipAbonament != "zi" && tipAbonament != "luna" && tipAbonament != "an");
        
        //Alege perioada
        Console.WriteLine("Alege perioada abonamentului: ");
        int perioada = int.Parse(Console.ReadLine());

        Abonament AbonamentNou;

        switch (tipAbonament)
        {
            case "zi":
                AbonamentNou = new AbonamentZi(LocAles, perioada);
                break;
            case "luna":
                AbonamentNou = new AbonamentLuna(LocAles, perioada);
                break;
            case "an":
                AbonamentNou = new AbonamentAn(LocAles, perioada);
                break;
            default:
                return;
        }
        //Se afiseaza costul
        Console.WriteLine($"Cost total: {AbonamentNou.PretFinal} lei");
        
        //Se adauga in Lista AbonamenteActive
        List<Abonament> AbonamenteActive = new List<Abonament>();
        
        if (File.Exists("AbonamentData.json"))
        {
            string vechiJson = File.ReadAllText("AbonamentData.json");
            AbonamenteActive = JsonSerializer.Deserialize<List<Abonament>>(vechiJson, JsonOptions.Create());
        }
        
        AbonamenteActive.Add(AbonamentNou);
        string AbonamenteJson = JsonSerializer.Serialize(AbonamenteActive, JsonOptions.Create());
        File.WriteAllText("AbonamentData.json", AbonamenteJson);
    }
    
}
