using System;
using System.Collections.Generic;

namespace LicenceManager.DBLib.Class;

public partial class DemandeLicence
{
    public ulong Id { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public string TypeDemande { get; set; } = null!;

    public DateTime DateDebutLicence { get; set; }

    public DateTime DateFinLicence { get; set; }

    public ulong? LicencechoisieId { get; set; }

    public ulong LicenceId { get; set; }

    public ulong UserId { get; set; }

    public DateTime? DeletedAt { get; set; }
}
