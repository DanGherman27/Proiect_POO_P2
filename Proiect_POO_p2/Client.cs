namespace Proiect_POO_p2;

public class Client : User
{
    public List<Abonament> IstoricAbonamente { get; set; }
    public List<Abonament> AbonamenteActive { get; set; }

    public Client(string username, string password) : base(username, password)
    {
        IstoricAbonamente = new List<Abonament>();
    }

}
