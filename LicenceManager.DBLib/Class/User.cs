using System;
using System.Collections.Generic;

namespace LicenceManager.DBLib.Class;

public partial class User
{
    public ulong Id { get; set; }

    public string Libelle { get; set; } = null!;

    public string Email { get; set; } = null!;

    public DateTime? EmailVerifiedAt { get; set; }

    public string Password { get; set; } = null!;

    public string? RememberToken { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public DateTime? DeletedAt { get; set; }
}
