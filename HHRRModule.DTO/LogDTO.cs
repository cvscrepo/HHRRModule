using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HHRRModule.DTO
{
    public class LogDTO
    {
        public int IdLog { get; set; }

        public int UserId { get; set; }

        public string Action { get; set; } = null!;

        public string? Description { get; set; }

        public DateTime? CreatedAt { get; set; }

        public virtual UserDTO User { get; set; } = null!;
    }
}
