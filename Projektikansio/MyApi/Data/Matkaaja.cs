using System;
using System.Collections.Generic;

namespace MyApi.Data;

public partial class Matkaaja
{
    public long Idmatkaaja { get; set; }

    public string? Etunimi { get; set; }

    public string? Sukunimi { get; set; }

    public string? Nimimerkki { get; set; }

    public string? Paikkakunta { get; set; }

    public string? Esittely { get; set; }

    public string? Kuva { get; set; }

    public string? Email { get; set; }

    public string? Password { get; set; }

    public virtual ICollection<Matka> Matkas { get; } = new List<Matka>();
}
