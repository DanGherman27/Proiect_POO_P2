namespace Proiect_POO_p2;

public class LocPremium : LocParcare
{
    public float Pret { get; set; }

    public LocPremium(int id) : base(id)
    {
        Pret = 10;
    }
}