namespace Proiect_POO_p2;

using System.Text.Json;

public abstract class User
{
    public string UserName { get; set; }
    public string Password { get; set; }

    protected User(string userName, string password)
    {
        UserName = userName;
        Password = password;
    }
}