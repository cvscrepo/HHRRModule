using System;
using System.Collections.Generic;

namespace HHRRModule.Model;

public partial class TypeFieldFormat
{
    public int IdTypeField { get; set; }

    public int IdTypeFormat { get; set; }

    public string NameTypeField { get; set; } = null!;

    public string TypeValue { get; set; } = null!;

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual ICollection<FieldFormat> FieldFormats { get; set; } = new List<FieldFormat>();

    public virtual TypeFormat? IdTypeFormatNavigation { get; set; } = null;
}
