using HHRRModule.BLL.Servicios.Contrato;
using HHRRModule.DTO;
using HHRRModule.Utility;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;

namespace HHRRModule.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoginController : ControllerBase
    {
        private readonly ILoginService _loginService;

        public LoginController(ILoginService loginService)
        {
            _loginService = loginService;
        }

        [HttpPost]
        public async Task<IActionResult> Login([FromBody] LoginDTO login)
        {
            ResponseApi response = new ResponseApi();
            try
            {
                string token = await _loginService.Login(login);
                response.Success = true;
                response.Message = "Login realizado correctamente";
                response.Value = token;

                return Ok(response);
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;

                return BadRequest(response);
            }
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] UserDTO user)
        {
            ResponseApi response = new ResponseApi();
            try
            {
                var userLoguedId = User.FindFirst(JwtRegisteredClaimNames.NameId) ?? throw new Exception("El usuario no se encuentra logueado");
                UserDTO userCreated = await _loginService.Register(user);
                response.Success = true;
                response.Message = "Usuario creado correctamente";
                response.Value = userCreated;

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
