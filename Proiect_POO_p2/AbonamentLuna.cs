namespace Proiect_POO_p2;

class AbonamentLuna : Abonament
{
    public AbonamentLuna(LocParcare locParcare, int perioada, int idZona) : base( locParcare, perioada, idZona) { }
    
    private float Discount = 0.8f;
    public override float PretFinal => (Perioada * LocParcare.CalcularePret() * 30 * Discount);

}
