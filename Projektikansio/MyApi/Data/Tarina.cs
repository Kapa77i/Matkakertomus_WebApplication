using SharedLib;

namespace MyApi.Data;

public partial class Tarina
{

    public Tarina() { }

    internal Tarina(tarinaDTO tarinadto)
    {


    }
    internal tarinaDTO toTarinaDTO()
    {
        return new tarinaDTO
        {
            idtarina = this.Idtarina,
            pvm = this.Pvm,
            teksti = this.Teksti,
            idmatkakohde = this.Idmatkakohde,
            idmatka = this.Idmatka


        };
    }


    public long Idtarina { get; set; }

    public byte[] Pvm { get; set; } = null!;

    public string? Teksti { get; set; }

    public long Idmatkakohde { get; set; }

    public long Idmatka { get; set; }

    public virtual Matka IdmatkaNavigation { get; set; } = null!;

    public virtual Matkakohde IdmatkakohdeNavigation { get; set; } = null!;

    public virtual ICollection<Kuva> Kuvas { get; } = new List<Kuva>();
}
