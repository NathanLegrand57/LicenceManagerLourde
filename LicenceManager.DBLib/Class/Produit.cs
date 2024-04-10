using System;
using System.Collections.Generic;

namespace LicenceManager.DBLib.Class;

public partial class Produit
{
    public ulong Id { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public string Libelle { get; set; } = null!;

    public string Description { get; set; } = null!;

    public DateTime? DeletedAt { get; set; }
}
