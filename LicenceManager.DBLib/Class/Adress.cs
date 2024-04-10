using System;
using System.Collections.Generic;

namespace LicenceManager.DBLib.Class;

public partial class Adress
{
    public ulong Id { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public string Rue { get; set; } = null!;

    public ulong? VilleId { get; set; }

    public DateTime? DeletedAt { get; set; }
}
