using HHRRModule.BLL.Servicios.Contrato;
using HHRRModule.DTO;
using HHRRModule.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HHRRModule.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<ActionResult<List<UserDTO>>> GetAllUsers()
        {
            ResponseApi response = new ResponseApi();
            try
            {
                List<UserDTO> users = await _userService.GetAllUsers();
                response.Success = true;
                response.Message = "Usuarios encontrados";
                response.Value = users;
                return Ok(response);
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserDTO>> GetUser(int id)
        {
            ResponseApi response = new ResponseApi();
            try
            {
                UserDTO user = await _userService.GetUser(id);
                response.Success = true;
                response.Message = "Usuario encontrado";
                response.Value = user;

                return Ok(response);
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
                return BadRequest(response);
            }
        }

        [HttpPut]
        public async Task<ActionResult<UserDTO>> EditUser(UserDTO user)
        {
            ResponseApi response = new ResponseApi();
            try
            {
                UserDTO userEdited = await _userService.EditUser(user);
                response.Success = true;
                response.Message = "Usuario editado";
                response.Value = userEdited;

                return Ok(response);
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
                return BadRequest(response);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> DeleteUser(int id)
        {
            ResponseApi response = new ResponseApi();
            try
            {
                bool userDeleted = await _userService.DeleteUser(id);
                response.Success = true;
                response.Message = "Usuario eliminado";
                response.Value = userDeleted;

                return Ok(response);
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
                return BadRequest(response);
            }
        }
    }
}
