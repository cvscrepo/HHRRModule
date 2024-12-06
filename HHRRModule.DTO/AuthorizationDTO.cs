using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HHRRModule.DTO
{
    public class AuthorizationDTO
    {
        public int IdAuthorization { get; set; }

        public int IdTypeFormat { get; set; }

        public int IdRole { get; set; }

        public int? IdParentAuth { get; set; }

        public string Nombre { get; set; } = null!;

        public int Position { get; set; }

        public DateTime? CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }

        public virtual AuthorizationDTO? IdParentAuthNavigation { get; set; }

        public virtual RoleDTO IdRoleNavigation { get; set; } = null!;

        public virtual TypeFormatDTO IdTypeFormatNavigation { get; set; } = null!;

        public virtual ICollection<AuthorizationDTO> InverseIdParentAuthNavigation { get; set; } = new List<AuthorizationDTO>();

        public virtual ICollection<RequestFormatAuthDTO> RequestFormatAuths { get; set; } = new List<RequestFormatAuthDTO>();
    }
}
