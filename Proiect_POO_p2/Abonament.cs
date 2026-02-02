namespace Proiect_POO_p2;
using System.Text.Json.Serialization;

[JsonDerivedType(typeof(AbonamentAn), typeDiscriminator: "an")]
[JsonDerivedType(typeof(AbonamentLuna), typeDiscriminator: "luna")]
[JsonDerivedType(typeof(AbonamentZi), typeDiscriminator: "zi")]
public abstract class Abonament
{
    public int IdZona { get; set; }
    public LocParcare LocParcare { get; }
    public int Perioada { get; }
    public DateTime DateTime { get; protected set; }
    
    [JsonIgnore]
    public abstract float PretFinal {get;}    
    
    protected Abonament(LocParcare locParcare, int perioada, int idZona)
    {
        LocParcare = locParcare;
        Perioada = perioada;
        DateTime = DateTime.Now;
        IdZona = idZona;
    }
    
    public override string ToString()
    {
        return $"[{this.GetType().Name}] Zona Parcare: {IdZona}, Loc: {LocParcare.Id}, " +
               $"Perioada: {Perioada}, Data inceperii: {DateTime:dd-MM-yyyy}, " +
               $"Cost: {PretFinal} lei";
    }
}