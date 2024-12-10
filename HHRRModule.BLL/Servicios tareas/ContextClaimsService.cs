using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;

namespace HHRRModule.BLL.Servicios_tareas
{

    public class ContextClaimsService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ContextClaimsService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public ClaimsPrincipal ObtenerUsuarioAutenticado()
        {
            var httpContext = _httpContextAccessor.HttpContext;

            // Verifica que exista el encabezado Authorization
            var token = httpContext?.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
            if (string.IsNullOrEmpty(token))
            {
                throw new UnauthorizedAccessException("No se encontró el token en la solicitud.");
            }

            // Valida y desestructura el token
            var handler = new JwtSecurityTokenHandler();
            var jwtToken = handler.ReadJwtToken(token);

            var claimsPrincipal = new ClaimsPrincipal(new ClaimsIdentity(jwtToken.Claims, "jwt"));
            return claimsPrincipal;
        }

        public string ObtenerClaimPorNombre(string claimType)
        {
            var usuario = ObtenerUsuarioAutenticado();

            var claim = usuario.Claims.FirstOrDefault(c => c.Type == claimType);
            return claim?.Value ?? throw new KeyNotFoundException($"Claim '{claimType}' no encontrado.");
        }

        public string ObtenerIdUsuario()
        {
            return ObtenerClaimPorNombre(ClaimTypes.NameIdentifier);
        }
    }
}
