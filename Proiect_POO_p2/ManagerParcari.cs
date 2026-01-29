namespace Proiect_POO_p2;

public class ManagerParcari
{
    public List<ZonaParcare> ListaZone = new List<ZonaParcare>();

    public void StergeLocParcare(ZonaParcare Zona, int IdLocParcare)
    {
        for (int i = 0; i < Zona.Parcare.Count; i++)
        {
            if (Zona.Parcare[i].Id == IdLocParcare)
            {
                Zona.Parcare.Remove(Zona.Parcare[i]);
                Console.WriteLine("Locul de parcare a fost sters.");
                return;
            }
        }

        Console.WriteLine("Locul de parcare nu a fost gasit.");
    }

    public void ModificaTipLocParcare(ZonaParcare Zona, int IdLocParcare)
    {
        for (int i = 0; i < Zona.Parcare.Count; i++)
        {
            LocParcare locNou = null;

            if (Zona.Parcare[i].Id == IdLocParcare)
            {
                if (Zona.Parcare[i] is LocStandard)
                {
                    locNou = new LocPremium(id: IdLocParcare);
                }
                else if (Zona.Parcare[i] is LocPremium)
                {
                    locNou = new LocStandard(id: IdLocParcare);
                }
                else
                {
                    return;
                }
            }

            locNou.Disponibilitate = Zona.Parcare[i].Disponibilitate;

            Zona.Parcare[i] = locNou;

            Console.WriteLine("Tipul locului de parcare a fost modificat.");
            return;
        }
    }
}
