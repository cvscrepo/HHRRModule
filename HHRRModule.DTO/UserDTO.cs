using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HHRRModule.DTO
{
    public class UserDTO
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

        public virtual ICollection<EmployedDTO> EmployedNavigation { get; set; } = new List<EmployedDTO>();

        public virtual ICollection<LogDTO> LogsNavigation { get; set; } = new List<LogDTO>();

        public virtual RoleDTO Role { get; set; } = null!;

        public virtual UserStateDTO State { get; set; } = null!;
    }
}
