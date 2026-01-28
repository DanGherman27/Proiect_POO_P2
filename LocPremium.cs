namespace Proiect_POO_p2;

public class LocPremium : LocParcare
{
    public float pret = 10;

    public LocPremium(int id) : base(id)
    {
        Id = id;
    }
}