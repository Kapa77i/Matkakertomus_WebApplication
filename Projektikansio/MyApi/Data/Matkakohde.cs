using System;
using System.Collections.Generic;

namespace MyApi.Data;

public partial class Matkakohde
{
    public long Idmatkakohde { get; set; }

    public string? Kohdenimi { get; set; }

    public string? Maa { get; set; }

    public string? Paikkakunta { get; set; }

    public string? Kuvausteksti { get; set; }

    public string? Kuva { get; set; }

    public virtual ICollection<Tarina> Tarinas { get; } = new List<Tarina>();
}
