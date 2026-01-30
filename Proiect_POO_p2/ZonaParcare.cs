namespace Proiect_POO_p2;

public class ZonaParcare
{
    public int Id { get; set; }
    public int Pret { get; set; }
    public List<LocParcare> Locuri { get; set; }

    public ZonaParcare(int id, int pret, List<LocParcare> locuri)
    {
        Id = id;
        Pret = pret;
        Locuri = locuri;
    }
}