using Proiect_POO_p2;
using System.Text.Json;

int obt;

if (!int.TryParse(Console.ReadLine(), out obt))
{
    Console.WriteLine("Te rog introdu un NUMAR!");
    return;
}

string _filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "ClientData.json");

string ClientJson =  File.ReadAllText(_filePath);
Client client = JsonSerializer.Deserialize<Client>(ClientJson);

if (obt == 1)
{
    Console.Write("Username: ");
    string user = Console.ReadLine();

    Console.Write("Parola: ");
    string pss = Console.ReadLine();

    if (client.UserName == user && client.Password == pss)
    {
        Console.WriteLine("Autentificare reusita ");
    }
    else
    {
        Console.WriteLine("Username sau parola gresite ");
    }
}
 