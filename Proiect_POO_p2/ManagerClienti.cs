using Infrastructura.Configuration;

namespace Proiect_POO_p2;
using System.Text.Json;

public static class ManagerClienti
{
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
            Console.WriteLine("1. Cumpara abonament nou");
            Console.WriteLine("2. Abonamente active (Curente)");
            Console.WriteLine("3. Istoric Abonamente (Expirate/Anulate)");
            Console.WriteLine("4. Anuleaza un abonament activ");
            Console.WriteLine("5. Clear");
            Console.WriteLine("0. Deconectare");
            Console.Write("Optiune: ");
            int opt_client = Optiuni.Citeste();
            switch (opt_client)
            {
                case 1:
                    ManagerAbonamente.CumparaAbonament();
                    break;
                case 2:
                    break;
                case 3:
                    break;
                case 4:
                    break;
                case 5:
                    Console.Clear();
                    break;
                
                case 0:
                    client_running = false;
                    break;
                
                default:
                    Console.WriteLine("Optiunea este invalida!");
                    break;
            }
        }
    }
}
