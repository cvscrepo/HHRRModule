using AutoMapper;
using HHRRModule.BLL.Servicios.Contrato;
using HHRRModule.DAL.Repositorios.Contrato;
using HHRRModule.DTO;
using HHRRModule.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HHRRModule.BLL.Servicios
{
    public class RoleService : IRoleService
    {
        public IGenericRepository<Role> _roleRepository;
        public IMapper mapper;

        public RoleService(IGenericRepository<Role> roleRepository, IMapper mapper)
        {
            _roleRepository = roleRepository;
            this.mapper = mapper;
        }

        public async Task<List<RoleDTO>> GetAllRoles()
        {
            try
            {
                IQueryable<Role> roles = await _roleRepository.Consultar();
                return mapper.Map<List<RoleDTO>>(roles);
            }
            catch
            {
                throw;
            }
        }

        public async Task<RoleDTO> CreateRole(RoleDTO role)
        {
            try
            {
                Role roleFound = await _roleRepository.Obtener(r => r.NameRol == role.NameRol);
                if (roleFound != null)
                {
                    throw new Exception("El rol ya existe");
                }
                Role roleCreated = await _roleRepository.Crear(mapper.Map<Role>(role));
                return mapper.Map<RoleDTO>(roleCreated);
            }
            catch
            {
                throw;
            }
        }

        public async Task<RoleDTO> UpdateRole(RoleDTO role)
        {
            try
            {
                Role roleFound = await _roleRepository.Obtener(r => r.NameRol == role.NameRol) ?? throw new Exception("El rol no existe");
                roleFound.NameRol = role.NameRol;
                roleFound.UpdatedAt = DateTime.Now;
                bool roleUpdated = await _roleRepository.Editar(roleFound);
                if (!roleUpdated)
                {
                    throw new Exception("No se pudo actualizar el rol");
                }
                return mapper.Map<RoleDTO>(roleFound);
            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> DeleteRole(RoleDTO role)
        {
            try
            {
                Role roleFound = await _roleRepository.Obtener(r => r.IdRole == role.IdRole) ?? throw new Exception("No se encontró el rol a eliminar");
                return await _roleRepository.Eliminar(mapper.Map<Role>(roleFound));
            }
            catch
            {
                throw;
            }
        }

        public async Task<RoleDTO> GetRoleById(int id)
        {
            // Get role by id
            try
            {
                Role role = await _roleRepository.Obtener(r => r.IdRole == id) ?? throw new Exception("Role not found");
                return mapper.Map<RoleDTO>(role);
            }
            catch
            {
                throw;
            }
        }
    }
}
