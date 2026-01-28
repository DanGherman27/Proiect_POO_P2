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
                ManagerClienti.AddClient(clientNou);
                Console.WriteLine("Clientul a fost creat!");
            }
        }
    }

    public static void AddClient(Client clientNou)
    {
        string jsonFile = File.ReadAllText("ClientData.json");
        List<Client> listaClienti = JsonSerializer.Deserialize<List<Client>>(jsonFile);
        
        listaClienti.Add(clientNou);
        
        string updatedJson = JsonSerializer.Serialize(listaClienti, JsonOptions.Create());
        File.WriteAllText("ClientData.json", updatedJson);
    }
}