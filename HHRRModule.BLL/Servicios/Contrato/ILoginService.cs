using HHRRModule.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HHRRModule.BLL.Servicios.Contrato
{
    public interface ILoginService
    {
        public Task<string> Login(LoginDTO user);
        public Task<UserDTO> Register(UserDTO usuario);
    }
}
