using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HHRRModule.DTO
{
    public class UserDTO
    {
        public int IdUser { get; set; }
        [Required]
        public string FullName { get; set; } = null!;
        [Required]
        public string IdentityDocument { get; set; } = null!;
        [Required]
        public string DocumentIdType { get; set; } = null!;
        [Required, EmailAddress]
        public string Email { get; set; } = null!;
        [Required, MinLength(8)]
        public string Password { get; set; } = null!;

        public string? UrlPhoto { get; set; }
        [Required]
        public int RoleId { get; set; }
        [Required]
        public int StateId { get; set; }

        public DateTime? CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }

        public virtual ICollection<EmployedDTO> EmployeesNavigation { get; set; } = new List<EmployedDTO>();

        public virtual ICollection<LogDTO> LogsNavigation { get; set; } = new List<LogDTO>();

        public virtual RoleDTO RoleNavigation { get; set; } = null!;

        public virtual UserStateDTO StateNavigation { get; set; } = null!;
    }
}
