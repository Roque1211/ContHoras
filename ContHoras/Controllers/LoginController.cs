using BL.Contracts;
using Core.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;


namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        // usuario BL
        public IUsuarioBL _usuarioBL { get; set; }
        public ISessionBL _sessionBL { get; set; }
        private readonly IConfiguration configuration;

        public LoginController(IConfiguration configuration, IUsuarioBL usuarioBL, ISessionBL sessionBL)
        {
            // TRAEMOS EL OBJETO DE CONFIGURACIÓN (appsettings.json)
            // MEDIANTE INYECCIÓN DE DEPENDENCIAS.
            this.configuration = configuration;

            _usuarioBL = usuarioBL;
            _sessionBL = sessionBL;
        }

        [HttpPost]
        [AllowAnonymous]
        [EnableCors("EnableCorsForLocalhost")]
        public async Task<IActionResult> Login(UsuarioDTO usuarioDTO)
        {
            var userInfo = await AutenticarUsuarioAsync(usuarioDTO);
            if (userInfo != null)
            {
                String token = GenerarTokenJWT(userInfo);
                _sessionBL.StartSession(token,userInfo.Id);
                return Ok(JsonConvert.SerializeObject(token));
            }
            else
            {
                return Unauthorized();
            }
        }


        // COMPROBAMOS SI EL USUARIO EXISTE EN LA BASE DE DATOS 
        private async Task<UsuarioInfo> AutenticarUsuarioAsync(UsuarioDTO usuarioDTO)
        {
            return _usuarioBL.Login(usuarioDTO);
        }

        // GENERAMOS EL TOKEN CON LA INFORMACIÓN DEL USUARIO 
        private string GenerarTokenJWT(UsuarioInfo usuarioInfo)
        {
            // CREAMOS EL HEADER //
            var _symmetricSecurityKey = new SymmetricSecurityKey(
                    Encoding.UTF8.GetBytes(configuration["JWT:ClaveSecreta"])
                );
            var _signingCredentials = new SigningCredentials(
                    _symmetricSecurityKey, SecurityAlgorithms.HmacSha256
                );
            var _Header = new JwtHeader(_signingCredentials);

            // CREAMOS LOS CLAIMS //
            var _Claims = new[] {
                new Claim(JwtRegisteredClaimNames.Jti, System.Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.NameId, usuarioInfo.Id.ToString()),
                new Claim("nombre", usuarioInfo.Nombre),
                new Claim("apellidos", usuarioInfo.Apellidos),
                new Claim(JwtRegisteredClaimNames.Email, usuarioInfo.Email),
                new Claim(ClaimTypes.Role, usuarioInfo.Rol)
            };

            // CREAMOS EL PAYLOAD //
            var _Payload = new JwtPayload(
                    issuer: configuration["JWT:Issuer"],
                    audience: configuration["JWT:Audience"],
                    claims: _Claims,
                    notBefore: DateTime.UtcNow,
                    // Expira a las 24 horas.
                    expires: DateTime.UtcNow.AddHours(24)
                );

            // GENERAMOS EL TOKEN //
            var _Token = new JwtSecurityToken(
                    _Header,
                    _Payload
                );

            return new JwtSecurityTokenHandler().WriteToken(_Token);
        }
    }
}