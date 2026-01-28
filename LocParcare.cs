namespace Proiect_POO_p2;

public abstract class LocParcare
{
    public int Id { get; set; }
    public bool Disponibilitate =  false;

    public LocParcare(int id)
    {
        Id = id;
    }
}