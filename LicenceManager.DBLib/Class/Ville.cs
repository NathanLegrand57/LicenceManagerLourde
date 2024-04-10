using System;
using System.Collections.Generic;

namespace LicenceManager.DBLib.Class;

public partial class Ville
{
    public ulong Id { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public string Nom { get; set; } = null!;

    public int CodePostal { get; set; }

    public DateTime? DeletedAt { get; set; }
}
