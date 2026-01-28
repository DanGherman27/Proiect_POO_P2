namespace Proiect_POO_p2;

public class ZonaParcare
{
    public int Id { get; set; }
    public float Pret { get; set; }
    public List<LocParcare> Parcare = new List<LocParcare>();

    public ZonaParcare(int id, float pret)
    {
        Id = id;
        Pret = pret;
    }
}