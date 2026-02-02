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
                if (clientGasit != null)
                {
                    if (clientGasit.AbonamenteActive == null)
                    {
                        clientGasit.AbonamenteActive = new List<Abonament>();
                    }
                    clientGasit.AbonamenteActive.Add(AbonamentNou);
                }
                
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
    
    public static void AfisareIstoricAbonament()
    {
        string ClientiiJson = File.ReadAllText("ClientData.json");
        List<Client> ListeClienti=JsonSerializer.Deserialize<List<Client>>(ClientiiJson, JsonOptions.Create());

        foreach (var client in ListeClienti)
        {
            if (ManagerClienti.ClientLogat.UserName == client.UserName)
            {
                foreach (var abonament in client.IstoricAbonamente)
                {
                   Console.WriteLine(abonament); 
                }
            }
        }
    }

    public static void AnulareAbonament()
    {
        if (File.Exists("ClientData.json"))
        {
            string JsonContinut = File.ReadAllText("ClientData.json");
            List<Client> listaClienti=JsonSerializer.Deserialize<List<Client>>(JsonContinut, JsonOptions.Create());
            
            string ParcariJson = File.ReadAllText("ParcariData.json");
            List<ZonaParcare> listaParcari = JsonSerializer.Deserialize<List<ZonaParcare>>(ParcariJson, JsonOptions.Create());
            
            Client clientGasit = null;
            foreach (var client in listaClienti)
            {
                if (ManagerClienti.ClientLogat.UserName == client.UserName)
                {
                    clientGasit = client;
                    break;
                }
            }

            if (clientGasit == null)
            {
                Console.WriteLine("Nu sunt abaonamente active de sters");
                return;
            }
            Console.WriteLine("Abonamente active:");
            for (int i = 0; i < clientGasit.AbonamenteActive.Count; i++)
            {
                var ab=clientGasit.AbonamenteActive[i];
                Console.WriteLine($"[{i}] Zona: {ab.IdZona}, Loc:{ab.LocParcare.Id}");
            }
            
            Console.WriteLine("Introdu indexul pe care doresti sa il stergi:");
            int index=int.Parse(Console.ReadLine());

            if (index >= 0 && index < clientGasit.AbonamenteActive.Count)
            {
                Abonament deAnulat=clientGasit.AbonamenteActive[index];
                foreach (var zona in listaParcari)
                {
                    if (zona.Id == deAnulat.IdZona)
                    {
                        foreach (var loc in zona.Locuri)
                        {
                            if (loc.Id == deAnulat.LocParcare.Id)
                            {
                                loc.Disponibilitate = true;
                            }
                        }
                    }
                }

                clientGasit.AbonamenteActive.RemoveAt(index);
                clientGasit.IstoricAbonamente.Add(deAnulat);
                
                File.WriteAllText("ClientData.json", JsonSerializer.Serialize(listaClienti, JsonOptions.Create()));
                File.WriteAllText("ParcariData.json",JsonSerializer.Serialize(listaParcari, JsonOptions.Create()));
                
                Console.WriteLine("Abonament anulat cu succes");
            }
            else
            {
                Console.WriteLine("Numar invalid!");
            }
            
        }
        
    }
}