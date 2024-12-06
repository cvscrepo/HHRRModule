using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HHRRModule.DTO
{
    public class UserStateDTO
    {
        public int IdState { get; set; }

        public string NameState { get; set; } = null!;

        public DateTime? CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }

        public virtual ICollection<EmployedDTO> Employeds { get; set; } = new List<EmployedDTO>();

        public virtual ICollection<UserDTO> UsersNavigation { get; set; } = new List<UserDTO>();
    }
}
