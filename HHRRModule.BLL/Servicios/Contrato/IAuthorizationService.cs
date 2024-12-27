using HHRRModule.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HHRRModule.BLL.Servicios.Contrato
{
    public interface IAuthorizationService
    {
        public Task<AuthorizationDTO> GetAuthorization(int idTypeFormat);
        public Task<AuthorizationDTO> CreateAuthorization(AuthorizationDTO authorization);
        public Task<AuthorizationDTO> EditAuthorization(AuthorizationDTO authorization);
        public Task<bool> DeleteAuthorization(int idAuthorization);
    }
}
