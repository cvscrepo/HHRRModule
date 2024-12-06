using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HHRRModule.DTO
{
    public class EmployedDTO
    {
        public int IdEmployed { get; set; }

        public int UserId { get; set; }

        public int StateId { get; set; }

        public string Position { get; set; } = null!;

        public string Department { get; set; } = null!;

        public string? ClientAssigned { get; set; }

        public DateOnly EntryDate { get; set; }

        public string TypeEmployed { get; set; } = null!;

        public string? UrlPhoto { get; set; }

        public DateTime? CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }

        public virtual ICollection<RequestFormatDTO> RequestFormats { get; set; } = new List<RequestFormatDTO>();

        public virtual UserStateDTO State { get; set; } = null!;

        public virtual UserDTO User { get; set; } = null!;
    }
}
