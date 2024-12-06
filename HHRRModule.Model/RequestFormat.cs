using System;
using System.Collections.Generic;

namespace HHRRModule.Model;

public partial class RequestFormat
{
    public int IdRequest { get; set; }

    public string NameRequest { get; set; } = null!;

    public int IdEmployed { get; set; }

    public int IdTypeFormat { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual ICollection<FieldFormat> FieldFormats { get; set; } = new List<FieldFormat>();

    public virtual Employed IdEmployedNavigation { get; set; } = null!;

    public virtual TypeFormat IdTypeFormatNavigation { get; set; } = null!;

    public virtual ICollection<RequestFormatAuth> RequestFormatAuths { get; set; } = new List<RequestFormatAuth>();
}
