using HHRRModule.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HHRRModule.BLL.Servicios.Contrato
{
    public interface IRoleService
    {
        public Task<List<RoleDTO>> GetAllRoles();
        public Task<RoleDTO> GetRoleById(int id);
        public Task<RoleDTO> CreateRole(RoleDTO role);
        public Task<RoleDTO> UpdateRole(RoleDTO role);
        public Task<bool> DeleteRole(RoleDTO role);
    }
}
