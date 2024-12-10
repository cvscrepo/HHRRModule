using HHRRModule.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HHRRModule.BLL.Servicios.Contrato
{
    public interface IUserService
    {
        public Task<List<UserDTO>> GetAllUsers();

        public Task<UserDTO> GetUser(int id);

        public Task<UserDTO> GetUserByEmail(string email);

        public Task<UserDTO> CreateUser(UserDTO usuario);

        public Task<UserDTO> EditUser(UserDTO usuario);

        public Task<bool> DeleteUser(int id);
    }
}
