using AutoMapper;
using HHRRModule.BLL.Servicios.Contrato;
using HHRRModule.DAL.Repositorios.Contrato;
using HHRRModule.DTO;
using HHRRModule.DTO.Enum;
using HHRRModule.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HHRRModule.BLL.Servicios
{
    public class UserService : IUserService
    {
        private readonly IGenericRepository<User> _userRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IMapper mapper;

        public UserService(IGenericRepository<User> userRepository, IMapper mapper, IHttpContextAccessor httpContextAccessor)
        {
            _userRepository = userRepository;
            this.mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<List<UserDTO>> GetAllUsers()
        {
            try
            {
                IQueryable<User> users = await _userRepository.Consultar();
                List<User> queryUsers = users.Include(u => u.EmployeesNavigation).Include(u => u.RoleNavigation).AsEnumerable().ToList();
                List<UserDTO> usersDTO = mapper.Map<List<UserDTO>>(queryUsers);
                return usersDTO;
            }
            catch
            {
                throw;
            }
        }

        public async Task<UserDTO> GetUser(int id)
        {
            try
            {
                IQueryable<User> users = await _userRepository.Consultar(u => u.IdUser == id);
                List<User> queryUsers = users.Include(u => u.EmployeesNavigation).Include(u => u.RoleNavigation).AsEnumerable().ToList();
                List<UserDTO> usersDTO = mapper.Map<List<UserDTO>>(queryUsers);
                return usersDTO.FirstOrDefault();
            }
            catch
            {
                throw;
            }
        }
        // Found by email
        public async Task<UserDTO> GetUserByEmail(string email)
        {
            try
            {
                IQueryable<User> users = await _userRepository.Consultar(u => u.Email == email);
                List<User> queryUsers = users.Include(u => u.EmployeesNavigation).Include(u => u.RoleNavigation).AsEnumerable().ToList();
                List<UserDTO> usersDTO = mapper.Map<List<UserDTO>>(queryUsers);
                return usersDTO.FirstOrDefault();
            }
            catch
            {
                throw;
            }
        } 

        public async Task<UserDTO> CreateUser(UserDTO usuario)
        {
            try
            {
                // Map DTO to entity
                User newUser = mapper.Map<User>(usuario);

                // Validate that the user is not created yet
                User userFound = await _userRepository.Obtener(u => u.Email == newUser.Email) ?? throw new Exception("Usuario ya existe");

                // Validate permissions
                if (userFound.RoleNavigation.NameRol != RoleEnum.Admin) throw new Exception("No tiene permisos para crear usuarios");

                // Add user to repository
                User createdUser = await _userRepository.Crear(newUser);

                // Map back to DTO and return
                UserDTO createdUserDTO = mapper.Map<UserDTO>(createdUser);
                return createdUserDTO;
            }
            catch
            {
                throw;
            }
        }

        public async Task<UserDTO> EditUser(UserDTO usuario)
        {
            try
            {


                // Found user in database
                User user = await _userRepository.Obtener(u => u.IdUser == usuario.IdUser) ?? throw new Exception("Usuario no encontrado");
                // Edit user
                user.FullName = usuario.FullName;
                user.IdentityDocument = usuario.IdentityDocument;
                user.UrlPhoto = usuario.UrlPhoto;
                user.UpdatedAt = DateTime.Now;

                // Update user in repository
                bool editedUser = await _userRepository.Editar(user);

                return usuario;
            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> DeleteUser(int id)
        {
            try
            {
                // Found user in database
                User user = await _userRepository.Obtener(u => u.IdUser == id) ?? throw new Exception("Usuario a eliminar no encontrado");
                // Attempt to delete user
                bool deleted = await _userRepository.Eliminar(user);
                return deleted;
            }
            catch
            {
                throw;
            }
        }

    }
}
