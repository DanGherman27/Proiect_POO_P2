namespace Proiect_POO_p2;

public class LocStandard : LocParcare
{
    public float Pret { get; set; }

    public LocStandard(int id) : base(id)
    {
        Pret = 5;
    }
}