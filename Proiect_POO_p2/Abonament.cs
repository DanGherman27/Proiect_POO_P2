namespace Proiect_POO_p2;
using System.Text.Json.Serialization;

[JsonDerivedType(typeof(AbonamentAn), typeDiscriminator: "an")]
[JsonDerivedType(typeof(AbonamentLuna), typeDiscriminator: "luna")]
[JsonDerivedType(typeof(AbonamentZi), typeDiscriminator: "zi")]
abstract class Abonament
{
    public LocParcare LocParcare { get; }
    public int Perioada { get; }
    public DateTime DateTime { get; protected set; }
    
    [JsonIgnore]
    public abstract float PretFinal {get;}    
    
    protected Abonament(LocParcare locParcare, int perioada)
    {
        LocParcare = locParcare;
        Perioada = perioada;
        DateTime = DateTime.Now;
    }
}
