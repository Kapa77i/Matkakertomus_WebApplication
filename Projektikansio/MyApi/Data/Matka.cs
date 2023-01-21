using System;
using System.Collections.Generic;

namespace MyApi.Data;

public partial class Matka
{
    public long Idmatkaaja { get; set; }

    public byte[]? Alkupvm { get; set; }

    public byte[]? Loppupvm { get; set; }

    public long? Yksityinen { get; set; }

    public long Idmatka { get; set; }

    public virtual Matkaaja IdmatkaajaNavigation { get; set; } = null!;

    public virtual ICollection<Tarina> Tarinas { get; } = new List<Tarina>();
}
