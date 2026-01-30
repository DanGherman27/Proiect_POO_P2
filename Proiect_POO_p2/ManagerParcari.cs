using Infrastructura.Configuration;

namespace Proiect_POO_p2;
using System.Text.Json;

public static class ManagerParcari
{
    public static void AdaugareZonaParcare(int id, int pret, List<LocParcare> locuriParcare)
    {
        string ParcariJson = File.ReadAllText("ParcariData.json");
        List<ZonaParcare> ListaZone = JsonSerializer.Deserialize<List<ZonaParcare>>(ParcariJson);
        
        ZonaParcare ZonaNoua = new ZonaParcare(id, pret, locuriParcare);
        ListaZone.Add(ZonaNoua);
        
        string updateJson = JsonSerializer.Serialize(ListaZone, JsonOptions.Create());
        File.WriteAllText("ParcariData.json", updateJson);
    }
    public static void AdaugaLocParcare(int IdZona, int standard_or_premium)
    {
        string ParcariJson = File.ReadAllText("ParcariData.json");
        List<ZonaParcare> parcareNoua = JsonSerializer.Deserialize<List<ZonaParcare>>(ParcariJson);

        foreach (var zone in parcareNoua)
        {

            if (IdZona == zone.Id)
            {
                if (standard_or_premium == 0)
                {
                    zone.Locuri.Add(new LocStandard(zone.Locuri.Count));
                    string updateJson = JsonSerializer.Serialize(parcareNoua, JsonOptions.Create());
                    File.WriteAllText("ParcariData.json", updateJson);
                }
            
                else if (standard_or_premium == 1)
                {
                    zone.Locuri.Add(new LocPremium(zone.Locuri.Count));  
                    string updateJson = JsonSerializer.Serialize(parcareNoua, JsonOptions.Create());
                    File.WriteAllText("ParcariData.json", updateJson);
                }
                else
                {
                    Console.WriteLine("Optiune invalida!");
                }
            }
            
        }
    }
    public static void SchimbareTipLocParcare(int IdZona, int IdLoc, string TipLocNou)
    {
        string ParcariJson = File.ReadAllText("ParcariData.json");
        List<ZonaParcare> zonaParcare =  JsonSerializer.Deserialize<List<ZonaParcare>>(ParcariJson);

        LocParcare locNou;
        if (TipLocNou == "premium")
        { 
            locNou = new LocPremium(IdLoc);
        }
        else if (TipLocNou == "standard")
        {
            locNou = new LocStandard(IdLoc);
        }
        else
        {
            Console.WriteLine("Optiune invalida!");
            return;
        }
        
        foreach (var zona in zonaParcare)
        {
            if (IdZona == zona.Id)
            {
                int indexLoc = zona.Locuri.FindIndex(l => l.Id == IdLoc);
                if (indexLoc != -1)
                {
                    zona.Locuri[indexLoc] = locNou;   
                    Console.WriteLine($"Locul {IdLoc} din Zona {IdZona} a fost transformat în {TipLocNou}!");
                }
            }
        }
        string updateJson = JsonSerializer.Serialize(zonaParcare, JsonOptions.Create());
        File.WriteAllText("ParcariData.json", updateJson);
    }
    public static void AfiseazaLocuriParcare(int IdZona)
    {
        string ParcariJson = File.ReadAllText("ParcariData.json");
        List<ZonaParcare> ZonaNoua = JsonSerializer.Deserialize<List<ZonaParcare>>(ParcariJson);

        foreach (var zone in ZonaNoua)
        {
            if (IdZona == zone.Id)
            {
                foreach (var loc in zone.Locuri)
                {
                    string tip = loc is LocPremium ? "Premium" : "Standard";
                    string status = loc.Disponibilitate ? "Ocupat" : "Liber";

                    Console.WriteLine($"ID Loc: {loc.Id} | Tip: {tip} | Status: {status}");
                }
                
            }
        }
    }
    public static void StergereLocParcare(int IdZona , int  IdLoc)
    {
        string ParcariJson = File.ReadAllText("ParcariData.json");
        List<ZonaParcare> ZoneParcare = JsonSerializer.Deserialize<List<ZonaParcare>>(ParcariJson);

        foreach (var zona in ZoneParcare)
        {
            if (IdZona == zona.Id)
            {
                LocParcare LocSters = null;
                foreach (var locParcare in zona.Locuri)
                {
                    if (IdLoc == locParcare.Id)
                    {
                        LocSters = locParcare;
                    }
                }
                
                if (LocSters != null)
                {
                    zona.Locuri.Remove(LocSters);
                }
            }
        }
        
        string updateJson = JsonSerializer.Serialize(ZoneParcare, JsonOptions.Create());
        File.WriteAllText("ParcariData.json", updateJson);
    }

    public static void StergereZonaParcare(int IdZona)
    {
        string ParcariJson = File.ReadAllText("ParcariData.json");
        List <ZonaParcare> ZoneParcare = JsonSerializer.Deserialize<List<ZonaParcare>>(ParcariJson);

        ZonaParcare ZonaStearsa = null;
        foreach (var zona in ZoneParcare)
        {
            if (IdZona == zona.Id)
            {
                ZonaStearsa = zona;
            }
        }

        ZoneParcare.Remove(ZonaStearsa);
        string updateJson = JsonSerializer.Serialize(ZoneParcare, JsonOptions.Create());
        File.WriteAllText("ParcariData.json", updateJson);
    }
    
}