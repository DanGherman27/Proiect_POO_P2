namespace Proiect_POO_p2;

public class LocStandard : LocParcare
{
    public float Pret { get; set; }
    public bool Disponibilitate { get; set; }

    public LocStandard(int id) : base(id)
    {
        Disponibilitate = false;
        Pret = 5;
    }
}