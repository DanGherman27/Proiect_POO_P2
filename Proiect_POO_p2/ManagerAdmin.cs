namespace Proiect_POO_p2;
using System.Text.Json;

public static class ManagerAdmin
{
    public static void ParcurgereAdmini(string username, string password)
    {
        string AdminJson = File.ReadAllText("AdminData.json");
        List<Admin> Administrators = JsonSerializer.Deserialize<List<Admin>>(AdminJson);

        bool admin_gasit = false;
        foreach (var admin in Administrators)
        {
            if (admin.UserName == username && admin.Password == password)
            {
                Console.WriteLine($"Bine ai venit {username}");
                admin_gasit = true;
                break;
            }
        }

        if (!admin_gasit)
        {
            Console.WriteLine("Mai incercati odata!");
        }
    }

    public static void MeniuAdmin()
    {
        bool admin_running = true;

        while (admin_running)
        {
            string ParcariJson = File.ReadAllText("ParcariData.json");
            List<ZonaParcare> ZoneParcari =  JsonSerializer.Deserialize<List<ZonaParcare>>(ParcariJson);
            
            Console.WriteLine("1. Creare loc parcare\n" +
                              "2. Creare parcare\n"+
                              "3. Modificare tip loc\n"+
                              "4. Stergere loc parcare\n"+
                              "5. Sterge parcare \n"+
                              "6. Afiseaza locuri intr-o zona\n"+
                              "0. Iesire meniu admin\n");
            int opt_admin = Optiuni.Citeste();
            switch (opt_admin)
            {
                case 1:
                    Console.WriteLine("Zona in care doriti sa creeati locul de parcare: ");
                    int IdZona = Optiuni.Citeste();
                    
                    if (IdZona > ZoneParcari.Count)
                    {
                        Console.WriteLine("Zona nu exista!");
                    }
                    
                    Console.WriteLine("Doriti ca locul sa fie standard (0) sau premium (1)?");
                    int AlegereTipParcare = Optiuni.Citeste();
                    
                    ManagerParcari.AdaugaLocParcare(IdZona, AlegereTipParcare);
                    break;
                
                case 2:
                    Console.WriteLine("Pretul zonei: ");
                    int PretZonaNoua =  Optiuni.Citeste();
                    Console.WriteLine("Zona a fost creata cu un loc standard si unul premium!");
                    
                    ManagerParcari.AdaugareZonaParcare(ZoneParcari.Count, PretZonaNoua, new List<LocParcare>{new LocStandard(0), new LocPremium(1)});
                    break;
                
                case 3:
                    Console.WriteLine("In ce zona doriti sa schimbati locul de parcare ?\n"+
                                      "Numarul zonei: ");
                    int NrZona = Optiuni.Citeste();
                    if (NrZona > ZoneParcari.Count)
                    {
                        Console.WriteLine("Zona nu exista!");
                        break;
                    }
                    ManagerParcari.AfiseazaLocParcare(NrZona);
                    Console.WriteLine("Ce loc doriti sa schimbati?\n"+
                                      "Loc: ");
                    int LocParcare = Optiuni.Citeste();
                    Console.WriteLine("Standard(0) sau premium(1)?");
                    int TipNou =  Optiuni.Citeste();

                    if (TipNou == 0)
                    {
                        ManagerParcari.SchimbareTipLocParcare(NrZona, LocParcare, "standard");
                    }
                    else if (TipNou == 1)
                    {
                        ManagerParcari.SchimbareTipLocParcare(NrZona, LocParcare, "premium");
                    }
                    else
                    {
                        Console.WriteLine("Optiune Invalida!");
                    }
                    break;
                
                case 4:
                    break;
                case 5:
                    break;
                case 6:
                    break;

                case 0:
                    admin_running = false;
                    break;

                default:
                    Console.WriteLine("Optiunea este invalida!");
                    break;
            }
        }
    }
}