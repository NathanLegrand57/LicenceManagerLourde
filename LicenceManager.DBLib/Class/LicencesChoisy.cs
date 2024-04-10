using System;
using System.Collections.Generic;

namespace LicenceManager.DBLib.Class;

public partial class LicencesChoisy
{
    public ulong Id { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public DateTime DateDebut { get; set; }

    public DateTime DateFin { get; set; }

    public ulong LicenceId { get; set; }

    public ulong UserId { get; set; }

    public DateTime? DeletedAt { get; set; }
}
