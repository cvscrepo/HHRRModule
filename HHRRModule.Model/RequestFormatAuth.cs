using System;
using System.Collections.Generic;

namespace HHRRModule.Model;

public partial class RequestFormatAuth
{
    public int IdProcessState { get; set; }

    public int IdAutorizacion { get; set; }

    public int IdRequestFormat { get; set; }

    public string? Status { get; set; }

    public bool? Value { get; set; }

    public string? Comments { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual Authorization IdAutorizacionNavigation { get; set; } = null!;

    public virtual RequestFormat IdRequestFormatNavigation { get; set; } = null!;
}
