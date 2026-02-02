namespace Proiect_POO_p2;

class AbonamentLuna : Abonament
{
    public AbonamentLuna(LocParcare locParcare, int perioada, int idZona) : base( locParcare, perioada, idZona) { }
    
    public override float PretFinal => (Perioada * LocParcare.CalcularePret());
}