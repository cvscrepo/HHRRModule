using System;
using System.Collections.Generic;

namespace HHRRModule.Model;

public partial class TypeFormat
{
    public int IdTypeFormat { get; set; }

    public string NameType { get; set; } = null!;

    public string TypeCode { get; set; } = null!;

    public int Version { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual ICollection<Authorization> Authorizations { get; set; } = new List<Authorization>();

    public virtual ICollection<RequestFormat> RequestFormats { get; set; } = new List<RequestFormat>();

    public virtual ICollection<TypeFieldFormat> TypeFieldFormats { get; set; } = new List<TypeFieldFormat>();
}
