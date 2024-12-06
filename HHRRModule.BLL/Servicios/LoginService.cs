using HHRRModule.BLL.Servicios.Contrato;
using HHRRModule.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HHRRModule.BLL.Servicios
{
    public class LoginService : ILoginService
    {
        public Task<string> Login(LoginDTO user)
        {
            throw new NotImplementedException();
        }

        public Task<UserDTO> Register(UserDTO usuario)
        {
            throw new NotImplementedException();
        }
    }
}
