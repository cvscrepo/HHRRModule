using HHRRModule.BLL.Servicios.Contrato;
using HHRRModule.DAL.Repositorios.Contrato;
using HHRRModule.DTO;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace HHRRModule.BLL.Servicios
{
    public class LoginService : ILoginService
    {
        private readonly IUserService _userService;
        private readonly string secretKey;
        private readonly string hash;

        public LoginService(IUserService userService, IConfiguration config)
        {
            _userService = userService;
            secretKey = config["settings:secretkey"];
            hash = config["settings:hash"];
        }
        public async Task<string> Login(LoginDTO user)
        {
            try
            {
                UserDTO userFound = await _userService.GetUserByEmail(user.Email) ?? throw new Exception("Usuario no encontrado");
                if(userFound.StateNavigation.NameState == "Inactivo")
                {
                    throw new Exception("Usuario inactivo");
                }
                string contrasenaDesncrypt;
                // Desencriptar la contraseña
                contrasenaDesncrypt = this.Decrypy(userFound.Password);

                if (userFound.Email == user.Email)
                {
                    if (user.Password == contrasenaDesncrypt)
                    {
                        var token = GenerateToken(userFound);
                        return token;
                    }
                    else
                    {
                        throw new Exception("Contraseña incorrecta");
                    }
                }

                throw new TaskCanceledException("Usuario no encontrado");
            }
            catch
            {
                throw;
            }
        }

        public Task<UserDTO> Register(UserDTO usuario)
        {
            try
            {
                // validate and encript password
                string passwordValidated = ValidatePassword(usuario.Password);
                usuario.Password = this.Encrypt(passwordValidated);

                // Createe the user
                return _userService.CreateUser(usuario);
            }
            catch
            {
                throw;
            }
        }

        public Task<UserDTO> ChangePassword(ChangePasswordDTO user)
        {
            try
            {
                // Validate user 
                UserDTO userFound = _userService.GetUserByEmail(user.Email).Result ?? throw new Exception("Usuario no encontrado");
                // Validate current password
                string contrasenaDesncrypt = this.Decrypy(userFound.Password);
                if (user.Password == contrasenaDesncrypt)
                {
                    // Validate new password
                    string newPasswordValidated = ValidatePassword(user.NewPassword);
                    userFound.Password = this.Encrypt(newPasswordValidated);
                    return _userService.EditUser(userFound);
                }
                else
                {
                    throw new Exception("Contraseña incorrecta");
                }
            }
            catch
            {
                throw;
            }
        }

        public static string ValidatePassword(string password)
        {
            if (string.IsNullOrEmpty(password))
            {
                throw new ArgumentException("La contraseña no puede estar vacía.");
            }

            // Lista para acumular los errores encontrados.
            var errores = new System.Text.StringBuilder();

            // Validar longitud mínima
            if (password.Length < 8)
            {
                errores.AppendLine("La contraseña debe tener al menos 8 caracteres.");
            }

            // Validar que no empiece ni termine con espacios
            if (password.StartsWith(" ") || password.EndsWith(" "))
            {
                errores.AppendLine("La contraseña no debe empezar ni terminar con espacios.");
            }

            // Validar al menos una letra minúscula
            if (!Regex.IsMatch(password, "[a-z]"))
            {
                errores.AppendLine("La contraseña debe contener al menos una letra minúscula.");
            }

            // Validar al menos una letra mayúscula
            if (!Regex.IsMatch(password, "[A-Z]"))
            {
                errores.AppendLine("La contraseña debe contener al menos una letra mayúscula.");
            }

            // Validar al menos un símbolo
            if (!Regex.IsMatch(password, @"[\W_]"))
            {
                errores.AppendLine("La contraseña debe contener al menos un símbolo.");
            }

            // Si hay errores, lanzar una excepción con el mensaje acumulado.
            if (errores.Length > 0)
            {
                throw new ArgumentException(errores.ToString().Trim());
            }

            // Si cumple todos los requisitos, retornar la contraseña.
            return password;
        }

        private string Encrypt(string mensaje)
        {
            byte[] data = UTF8Encoding.UTF8.GetBytes(mensaje);

            MD5 md5 = MD5.Create();
            TripleDES tripleDes = TripleDES.Create();

            tripleDes.Key = md5.ComputeHash(UTF8Encoding.UTF8.GetBytes(hash));
            tripleDes.Mode = CipherMode.ECB;

            ICryptoTransform transform = tripleDes.CreateEncryptor();
            byte[] result = transform.TransformFinalBlock(data, 0, data.Length);

            return Convert.ToBase64String(result);

        }

        private string Decrypy(string mensajeEncriptado)
        {
            byte[] data = Convert.FromBase64String(mensajeEncriptado);

            MD5 md5 = MD5.Create();
            TripleDES tripleDes = TripleDES.Create();

            tripleDes.Key = md5.ComputeHash(UTF8Encoding.UTF8.GetBytes(hash));
            tripleDes.Mode = CipherMode.ECB;

            ICryptoTransform transform = tripleDes.CreateDecryptor();
            byte[] result = transform.TransformFinalBlock(data, 0, data.Length);

            return UTF8Encoding.UTF8.GetString(result);
        }

        private string GenerateToken(UserDTO usuario)
        {
            try
            {
                var keyBytes = Encoding.ASCII.GetBytes(secretKey);
                var claims = new ClaimsIdentity();

                claims.AddClaims(new Claim[]{
                    new Claim(ClaimTypes.Name, usuario.Email),
                    new Claim(ClaimTypes.NameIdentifier, usuario.IdUser.ToString()),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                    new Claim(ClaimTypes.Role, usuario.RoleNavigation.NameRol)
                });

                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = claims,
                    Expires = DateTime.UtcNow.AddMinutes(60),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(keyBytes), SecurityAlgorithms.HmacSha256Signature)
                };

                var tokenHandler = new JwtSecurityTokenHandler();
                var tokenConfig = tokenHandler.CreateToken(tokenDescriptor);

                string tokenCreado = tokenHandler.WriteToken(tokenConfig);

                return tokenCreado;
            }
            catch
            {
                throw;
            }

        }
    }
}
