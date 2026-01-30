namespace Proiect_POO_p2;

public class LocPremium : LocParcare
{
    public float Pret { get; set; }
    public bool Disponibilitate { get; set; }

    public LocPremium(int id) : base(id)
    {
        Disponibilitate = false;
        Pret = 10;
    }
}