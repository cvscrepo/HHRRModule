using System;
using System.Collections.Generic;

namespace HHRRModule.Model;

public partial class Employed
{
    public int IdEmployed { get; set; }

    public int UserId { get; set; }

    public int StateId { get; set; }

    public string Position { get; set; } = null!;

    public string Department { get; set; } = null!;

    public string? ClientAssigned { get; set; }

    public DateOnly EntryDate { get; set; }

    public string TypeEmployed { get; set; } = null!;

    public string? UrlPhoto { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual ICollection<RequestFormat> RequestFormats { get; set; } = new List<RequestFormat>();

    public virtual UserState State { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
