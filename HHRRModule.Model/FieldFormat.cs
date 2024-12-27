using System;
using System.Collections.Generic;

namespace HHRRModule.Model;

public partial class FieldFormat
{
    public int IdField { get; set; }

    public int IdTypeField { get; set; }

    public int IdRequestFormat { get; set; }

    public string NameFieldRequest { get; set; } = null!;

    public string? ValueField { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual RequestFormat? IdRequestFormatNavigation { get; set; } = null;

    public virtual TypeFieldFormat? IdTypeFieldNavigation { get; set; } = null;
}
