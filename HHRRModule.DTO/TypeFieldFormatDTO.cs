using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HHRRModule.DTO
{
    public class TypeFieldFormatDTO
    {
        public int IdTypeField { get; set; }

        public int IdTypeFormat { get; set; }

        public string NameTypeField { get; set; } = null!;

        public string TypeValue { get; set; } = null!;

        public DateTime? CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }

        public virtual ICollection<FieldFormatDTO> FieldFormats { get; set; } = new List<FieldFormatDTO>();
    }
}
