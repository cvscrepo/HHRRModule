using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HHRRModule.DTO
{
    public class RequestFormatAuthDTO
    {
        public int IdProcessState { get; set; }

        public int IdAutorizacion { get; set; }

        public int IdRequestFormat { get; set; }

        public string? Status { get; set; }

        public bool? Value { get; set; }

        public string? Comments { get; set; }

        public DateTime? CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }

        public virtual AuthorizationDTO IdAutorizacionNavigation { get; set; } = null!;

        public virtual RequestFormatDTO IdRequestFormatNavigation { get; set; } = null!;
    }
}
