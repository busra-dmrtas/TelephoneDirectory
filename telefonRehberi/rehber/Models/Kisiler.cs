using System;
using System.Collections.Generic;

namespace rehber.Models;

public partial class Kisiler
{
    public long Id { get; set; }

    public string Ad { get; set; } = null!;

    public string? Soyad { get; set; }

    public string Numara { get; set; } = null!;
}
