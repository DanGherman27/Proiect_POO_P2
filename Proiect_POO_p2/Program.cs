using Proiect_POO_p2;
using System.Text.Json;

bool app_running = true;
bool client_running = true;
bool admin_running = true;


int obt_user = Optiuni.Citeste();


while(true)
if (obt_user == 1)
{
    Console.Write("Username: ");
    string username = Console.ReadLine();

    Console.Write("Parola: ");
    string password = Console.ReadLine();
    
    ManagerClienti.ParcurgereClienti(username, password);
}
