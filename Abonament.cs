namespace Proiect_POO2;

public class Abonament
{
    public string Tip { get; set; }
    public DateTime DataActivare { get; set; }
    public double Pret { get; set; }

    public Abonament(string tip, LocParcare locParcare)
    {
        Tip = tip;
        DataActivare = DateTime.Now;
        Pret = locParcare.CalcularePret();
    }
}