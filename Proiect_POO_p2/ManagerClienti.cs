using Infrastructura.Configuration;

namespace Proiect_POO_p2;
using System.Text.Json;

public static class ManagerClienti
{
    public static Client ClientLogat { get; private set; }
    public static void ParcurgereClienti(string username, string password)
    {
        string ClientJson = File.ReadAllText("ClientData.json");
        List<Client> clients = JsonSerializer.Deserialize<List<Client>>(ClientJson);

        bool client_gasit = false;
        foreach (var client in clients)
        {
            if (client.UserName == username && client.Password == password)
            {
                Console.WriteLine("Autentificare reusita ");
                ClientLogat = client;
                client_gasit = true;
                break;
            }

        }

        if (!client_gasit)
        {
            Console.WriteLine("Doriti sa adaugati acest user nou?");
            int opt_adaugare_client = Optiuni.Citeste();

            if (opt_adaugare_client == 1)
            {
                Client clientNou = new Client(username, password);
                ManagerClienti.AdaugaClient(clientNou);
                ClientLogat = clientNou;
                Console.WriteLine("Clientul a fost creat!");
            }
        }
    }

    public static void AdaugaClient(Client clientNou)
    {
        string jsonFile = File.ReadAllText("ClientData.json");
        List<Client> listaClienti = JsonSerializer.Deserialize<List<Client>>(jsonFile);
        
        listaClienti.Add(clientNou);
        
        string updatedJson = JsonSerializer.Serialize(listaClienti, JsonOptions.Create());
        File.WriteAllText("ClientData.json", updatedJson);
    }

    public static void MeniuClient()
    {
        bool client_running = true;
        while (client_running)
        {
            Console.Write("\n\n");
            Console.WriteLine("1. Cumpara abonament nou\n" +
                              "2. Abonamente active (Curente)\n" +
                              "3. Istoric Abonamente (Expirate/Anulate)\n" +
                              "4. Anuleaza un abonament activ\n" +
                              "5. Vizualizare parcari\n"+
                              "0. Deconectare\n" +
                              "Optiune: ");
            int opt_client = Optiuni.Citeste();
            switch (opt_client)
            {
                case 1:
                    ManagerAbonamente.CumparaAbonament();
                    break;
                case 2:
                    ManagerAbonamente.AfisareAbonamenteActive();
                    break;
                case 3:
                    ManagerAbonamente.AfisareIstoricAbonament();
                    break;
                case 4:
                    ManagerAbonamente.AnulareAbonament();
                    break;
                case 5:
                    ManagerParcari.AfisareParcari();
                    break;
                
                case 0:
                    client_running = false;
                    Console.Clear();
                    break;
                
                default:
                    Console.WriteLine("Optiunea este invalida!");
                    break;
            }
        }
    }
}

