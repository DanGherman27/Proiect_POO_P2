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
            Console.WriteLine($"Zona Parcare {parcare.Id}:");
            foreach (var locParcare in parcare.Locuri)
            {
                Console.WriteLine($"Loc parcare {locParcare}, Id: {locParcare.Id}, Disponibilitate:  {locParcare.Disponibilitate}");
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
                ZonaAleasa = ListaZona[i];    
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
        if (LocAles.Disponibilitate == false)
        {
            Console.WriteLine($"Loc parcare {LocAles.Id} din Zona Parcare: {ZonaAleasa.Id}, nu este disponibil in acest moment.");
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
                AbonamentNou = new AbonamentZi(LocAles, perioada, ZonaAleasa.Id);
                break;
            case "luna":
                AbonamentNou = new AbonamentLuna(LocAles, perioada, ZonaAleasa.Id);
                break;
            case "an":
                AbonamentNou = new AbonamentAn(LocAles, perioada, ZonaAleasa.Id);
                break;
            default:
                return;
        }
        
        //Se afiseaza costul
        Console.WriteLine($"Cost total: {AbonamentNou.PretFinal} lei");
        
        //Se adauga in Lista AbonamenteActive din Client
        if (File.Exists("ClientData.json"))
        {
            string jsonContinut = File.ReadAllText("ClientData.json");
            List<Client> listaClienti = JsonSerializer.Deserialize<List<Client>>(jsonContinut, JsonOptions.Create()) ?? new List<Client>();
            
            Client clientGasit = null;
            foreach (var client in listaClienti)
            {
                if (ManagerClienti.ClientLogat.UserName == client.UserName)
                {
                    clientGasit = client;
                    break;
                }
            }
            
            if (clientGasit != null)
            {
                clientGasit.AbonamenteActive.Add(AbonamentNou);
                
                LocAles.Disponibilitate = false;
                
                string jsonUpdate = JsonSerializer.Serialize(listaClienti, JsonOptions.Create());
                File.WriteAllText("ClientData.json", jsonUpdate);
                
                string jsonUpdateParcari = JsonSerializer.Serialize(ListaZona, JsonOptions.Create());
                File.WriteAllText("ParcariData.json", jsonUpdateParcari);
                
                AbonamentNou.IdZona = ZonaAleasa.Id;
                Console.WriteLine("Abonament adaugat cu succes");
            }
            else
            {
                Console.WriteLine("Clientul nu a fost gasit");
            }
        }
    }

    public static void AfisareAbonamenteActive()
    {
        string ClientiJson =  File.ReadAllText("ClientData.json");
        List<Client> listaClienti = JsonSerializer.Deserialize<List<Client>>(ClientiJson, JsonOptions.Create());
        
        foreach (var client in listaClienti)
        {
            if (ManagerClienti.ClientLogat.UserName == client.UserName)
            {
                foreach (var abonament in client.AbonamenteActive)
                {
                    Console.WriteLine(abonament);
                }
            }
        }
    }
}
