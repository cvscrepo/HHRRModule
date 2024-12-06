using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HHRRModule.DTO
{
    public class RoleDTO
    {
        public int IdRole { get; set; }

        public string NameRol { get; set; } = null!;

        public int? ParentRoleId { get; set; }

        public DateTime? CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }

        public virtual ICollection<AuthorizationDTO> Authorizations { get; set; } = new List<AuthorizationDTO>();

        public virtual ICollection<RoleDTO> InverseParentRole { get; set; } = new List<RoleDTO>();

        public virtual RoleDTO? ParentRole { get; set; }

        public virtual ICollection<UserDTO> Users { get; set; } = new List<UserDTO>();
    }
}
