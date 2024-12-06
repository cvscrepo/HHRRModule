using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HHRRModule.DTO
{
    public class FieldFormatDTO
    {
        public int IdField { get; set; }

        public int IdTypeField { get; set; }

        public int IdRequestFormat { get; set; }

        public string NameFieldRequest { get; set; } = null!;

        public string? ValueField { get; set; }

        public DateTime? CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }

        public virtual RequestFormatDTO IdRequestFormatNavigation { get; set; } = null!;

        public virtual TypeFieldFormatDTO IdTypeFieldNavigation { get; set; } = null!;
    }
}
