using System;
using System.Collections.Generic;

namespace HHRRModule.Model;

public partial class UserState
{
    public int IdState { get; set; }

    public string NameState { get; set; } = null!;

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual ICollection<Employed> Employeds { get; set; } = new List<Employed>();

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
