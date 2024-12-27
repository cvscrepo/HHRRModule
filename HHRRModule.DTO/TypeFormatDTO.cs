using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HHRRModule.DTO
{
    public class TypeFormatDTO
    {
        public int IdTypeFormat { get; set; }

        public string NameType { get; set; } = null!;

        public string TypeCode { get; set; } = null!;

        public int Version { get; set; }

        public DateTime? CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }

        public virtual ICollection<AuthorizationDTO> Authorizations { get; set; } = new List<AuthorizationDTO>();

        public virtual ICollection<TypeFieldFormatDTO> TypeFieldFormats { get; set; } = new List<TypeFieldFormatDTO>();
    }
}
