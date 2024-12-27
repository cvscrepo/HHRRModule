using HHRRModule.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HHRRModule.BLL.Servicios.Contrato
{
    public interface IRequestFormatAuthService
    {
        public Task<bool> CreatedRequestFormatAuth(RequestFormatAuthDTO requestFormatAuth);
        public Task<bool> EditRequestFormatAuth(RequestFormatAuthDTO requestFormatAuth);
        public Task<bool> DeleteRequestFormatAuth(int idRequestFormatAuth);
    }
}
