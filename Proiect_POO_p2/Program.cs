using Proiect_POO_p2;
using System.Text.Json;

bool app_running = true;

Console.Clear();
while(app_running)
{
    
    
    Console.WriteLine("Buna ziua, ce tip de cont doriti sa accesati?\n" +
                      "1.Client\n" +
                      "2.Admin\n" +
                      "0.Iesire\n");
    Console.Write("Optiunea dvs: ");
    int opt_user = Optiuni.Citeste();
    
    Console.Clear();
    
    if (opt_user == 1)
    {
        ManagerClienti.ParcurgereClienti(CitireUsername(), CitirePassword());
        Console.Clear();
        if(ManagerClienti.ClientLogat != null)
            ManagerClienti.MeniuClient();
    }
    else if (opt_user == 2)
    {
        bool ExistaAdmin = ManagerAdmin.ParcurgereAdmini(CitireUsername(),CitirePassword());
        Console.Clear();
        if (ExistaAdmin)
        {
            ManagerAdmin.MeniuAdmin();
            Console.Clear();
        }
        else
        {
            Console.WriteLine("Mai incercati odata!");
            Console.Clear();
        }
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
