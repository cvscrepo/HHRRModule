using AutoMapper;
using HHRRModule.BLL.Servicios.Contrato;
using HHRRModule.DAL.Repositorios.Contrato;
using HHRRModule.DTO;
using HHRRModule.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HHRRModule.BLL.Servicios
{
    public class AuthorizationService : IAuthorizationService
    {
        private readonly IGenericRepository<Authorization> _authorizationRepository;
        private readonly ITypeFormatService _typeFormatService;
        private readonly IRoleService _roleService;
        private readonly IMapper _mapper;

        public AuthorizationService(IGenericRepository<Authorization> authorizationRepository, IMapper mapper, ITypeFormatService typeFormatService, IRoleService roleService)
        {
            _authorizationRepository = authorizationRepository;
            _mapper = mapper;
            _typeFormatService = typeFormatService;
            _roleService = roleService;
        }
        public async Task<AuthorizationDTO> GetAuthorization(int idTypeFormat)
        {
            try
            {
                IQueryable<Authorization> authorizations = await _authorizationRepository.Consultar(a => a.IdTypeFormat == idTypeFormat);
                List<Authorization> query = authorizations.Include(a => a.IdRoleNavigation).AsEnumerable().ToList();
                return _mapper.Map<AuthorizationDTO>(query);
            }
            catch
            {
                throw;
            }
        }

        public async Task<AuthorizationDTO> CreateAuthorization(AuthorizationDTO authorization)
        {
            try
            {
                // Check if typeFormat exists
                TypeFormatDTO typeFormat = await _typeFormatService.GetTypeFormat(authorization.IdTypeFormat) ?? throw new Exception("The type format does not exist.");
                RoleDTO role = await _roleService.GetRoleById(authorization.IdRole) ?? throw new Exception("The role does not exist.");
                Authorization newAuthorization = _mapper.Map<Authorization>(authorization);
                await _authorizationRepository.Crear(newAuthorization);
                return _mapper.Map<AuthorizationDTO>(newAuthorization);
            }
            catch
            {
                throw;
            }
        }

        public async Task<AuthorizationDTO> EditAuthorization(AuthorizationDTO authorization)
        {
            try
            {
                // Check if the authorization exists
                IQueryable<Authorization> authorizations = await _authorizationRepository.Consultar(a => a.IdTypeFormat == authorization.IdTypeFormat);
                if (!authorizations.Any())
                    throw new Exception("The authorization does not exist.");

                Authorization editAuthorization = _mapper.Map<Authorization>(authorization);
                await _authorizationRepository.Editar(editAuthorization);
                return _mapper.Map<AuthorizationDTO>(editAuthorization);
            }
            catch
            {
                throw;
            }
        }
        
        public async Task<bool> DeleteAuthorization(int idAuthorization)
        {
            try
            {
                // Check if the authorization exists
                IQueryable<Authorization> authorizations = await _authorizationRepository.Consultar(a => a.IdAuthorization == idAuthorization);
                if (!authorizations.Any())
                    throw new Exception("The authorization does not exist.");

                bool deleted = await _authorizationRepository.Eliminar(authorizations);
                return deleted;
            }
            catch
            {
                throw;
            }
        }
    }
}
