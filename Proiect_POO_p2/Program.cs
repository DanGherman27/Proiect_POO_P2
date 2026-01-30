using Proiect_POO_p2;
using System.Text.Json;

bool app_running = true;
bool admin_running;

while(app_running)
{
    
    admin_running = true;
    
    Console.WriteLine("Buna ziua, ce tip de cont doriti sa accesati?\n" +
                      "1.Client\n" +
                      "2.Admin\n" +
                      "0.Iesire\n");
    Console.Write("Optiunea dvs: ");
    int opt_user = Optiuni.Citeste();
    
    if (opt_user == 1)
    {
        ManagerClienti.ParcurgereClienti(CitireUsername(), CitirePassword());
        ManagerClienti.MeniuClient();
    }
    else if (opt_user == 2)
    {
        ManagerAdmin.ParcurgereAdmini(CitireUsername(),CitirePassword());
        ManagerAdmin.MeniuAdmin();
    }
    else if (opt_user == 0)
    {
        app_running = false;
    }
    else
    {
        Console.WriteLine("Optiune invalida!");
    }
}

string CitireUsername()
{
    Console.Write("Username: ");
    string username = Console.ReadLine();
    
    return username;
}

string CitirePassword()
{
    Console.Write("Parola: ");
    string password = Console.ReadLine();
    return password;
}
