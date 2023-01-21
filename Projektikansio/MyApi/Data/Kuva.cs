using System;
using System.Collections.Generic;

namespace MyApi.Data;

public partial class Kuva
{
    public long Idkuva { get; set; }

    public string? Kuva1 { get; set; }

    public long Idtarina { get; set; }

    public virtual Tarina IdtarinaNavigation { get; set; } = null!;
}
