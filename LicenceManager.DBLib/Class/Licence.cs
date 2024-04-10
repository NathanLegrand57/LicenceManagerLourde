using System;
using System.Collections.Generic;

namespace LicenceManager.DBLib.Class;

public partial class Licence
{
    public ulong Id { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public string Libelle { get; set; } = null!;

    public double Prix { get; set; }

    public int Duree { get; set; }

    public ulong ProduitId { get; set; }

    public DateTime? DeletedAt { get; set; }
}
