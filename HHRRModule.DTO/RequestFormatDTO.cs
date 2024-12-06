using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HHRRModule.DTO
{
    public class RequestFormatDTO
    {
        public int IdRequest { get; set; }

        public string NameRequest { get; set; } = null!;

        public int IdEmployed { get; set; }

        public int IdTypeFormat { get; set; }

        public DateTime? CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }

        public virtual ICollection<FieldFormatDTO> FieldFormats { get; set; } = new List<FieldFormatDTO>();

        public virtual EmployedDTO IdEmployedNavigation { get; set; } = null!;

        public virtual TypeFormatDTO IdTypeFormatNavigation { get; set; } = null!;

        public virtual ICollection<RequestFormatAuthDTO> RequestFormatAuths { get; set; } = new List<RequestFormatAuthDTO>();
    }
}
