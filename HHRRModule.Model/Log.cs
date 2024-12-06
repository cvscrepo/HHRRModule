using System;
using System.Collections.Generic;

namespace HHRRModule.Model;

public partial class Log
{
    public int IdLog { get; set; }

    public int UserId { get; set; }

    public string Action { get; set; } = null!;

    public string? Description { get; set; }

    public DateTime? CreatedAt { get; set; }

    public virtual User User { get; set; } = null!;
}
