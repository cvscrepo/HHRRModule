using HHRRModule.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HHRRModule.BLL.Servicios.Contrato
{
    public interface IUserStateService
    {
        public Task<List<UserStateDTO>> GetAllUserStates();
        public Task<UserStateDTO> CreateUserState(UserStateDTO userState);
        public Task<UserStateDTO> UpdateUserState(UserStateDTO userState);
        public Task<bool> DeleteUserState(UserStateDTO userState);
    }
}
