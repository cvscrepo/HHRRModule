using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HHRRModule.BLL.Servicios_tareas.Contrato
{
    public interface IContextClaimsService
    {
        public string ObtenerClaimPorNombre(string claimType);
        public string ObtenerIdUsuario();
    }
}
