using System;
using System.Collections.Generic;

namespace HHRRModule.Model;

public partial class Authorization
{
    public int IdAuthorization { get; set; }

    public int IdTypeFormat { get; set; }

    public int IdRole { get; set; }

    public int? IdParentAuth { get; set; }

    public string Nombre { get; set; } = null!;

    public int Position { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual Authorization? IdParentAuthNavigation { get; set; }

    public virtual Role IdRoleNavigation { get; set; } = null!;

    public virtual TypeFormat IdTypeFormatNavigation { get; set; } = null!;

    public virtual ICollection<Authorization> InverseIdParentAuthNavigation { get; set; } = new List<Authorization>();

    public virtual ICollection<RequestFormatAuth> RequestFormatAuths { get; set; } = new List<RequestFormatAuth>();
}
