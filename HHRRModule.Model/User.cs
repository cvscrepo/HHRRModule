﻿using System;
using System.Collections.Generic;

namespace HHRRModule.Model;

public partial class User
{
    public int IdUser { get; set; }

    public string FullName { get; set; } = null!;

    public string IdentityDocument { get; set; } = null!;

    public string DocumentIdType { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string? UrlPhoto { get; set; }

    public int RoleId { get; set; }

    public int StateId { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual ICollection<Employed> Employeds { get; set; } = new List<Employed>();

    public virtual ICollection<Log> Logs { get; set; } = new List<Log>();

    public virtual Role Role { get; set; } = null!;

    public virtual UserState State { get; set; } = null!;
}