using System;
using System.Collections.Generic;

namespace HHRRModule.Model;

public partial class Role
{
    public int IdRole { get; set; }

    public string NameRol { get; set; } = null!;

    public int? ParentRoleId { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual ICollection<Authorization> Authorizations { get; set; } = new List<Authorization>();

    public virtual ICollection<Role> InverseParentRole { get; set; } = new List<Role>();

    public virtual Role? ParentRole { get; set; }

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
