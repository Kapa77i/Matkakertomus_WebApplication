using System;
using System.Collections.Generic;

namespace MyApi.Data;

public partial class Tarina
{
    public long Idtarina { get; set; }

    public byte[] Pvm { get; set; } = null!;

    public string? Teksti { get; set; }

    public long Idmatkakohde { get; set; }

    public long Idmatka { get; set; }

    public virtual Matka IdmatkaNavigation { get; set; } = null!;

    public virtual Matkakohde IdmatkakohdeNavigation { get; set; } = null!;

    public virtual ICollection<Kuva> Kuvas { get; } = new List<Kuva>();
}
