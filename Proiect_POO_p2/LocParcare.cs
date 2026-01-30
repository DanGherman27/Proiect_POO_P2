namespace Proiect_POO_p2;
using System.Text.Json.Serialization;

[JsonDerivedType(typeof(LocStandard), typeDiscriminator: "standard")]
[JsonDerivedType(typeof(LocPremium), typeDiscriminator: "premium")]
public abstract class LocParcare
{
    public int Id { get; set; }
    public bool Disponibilitate { get; set; }

    public LocParcare(int id)
    {
        Id = id;
        Disponibilitate = false;
    }
}