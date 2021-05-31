using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BL.Contracts;
using Core.DTO;
using Swashbuckle.AspNetCore.Annotations;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Authorization;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class SessionController : ControllerBase
    {
        public ISessionBL _sessionBL { get; set; }
        public SessionController(ISessionBL sessionBL)
        {
            _sessionBL = sessionBL;
        }

        // Devuelve todas las sessions
        [HttpGet]
        [Route("/api/session/getall")]

        public IEnumerable<SessionDTO> GetAll()
        {
            return _sessionBL.GetAll();
        }

        // GET devuelve una session con un token determinado
        [HttpGet("/api/session/get {token}")]
        [SwaggerOperation("get {token}")]
        [AllowAnonymous]
        [EnableCors("EnableCorsForLocalhost")]

        public SessionDTO Get(String token)
        {
            return _sessionBL.Get(token);
        }
        // GET devuelve el rol del usuario con la session abierta que corresponde al token enviado
        [HttpGet("/api/session/getrole")]
        [SwaggerOperation("/getrole")]
        [AllowAnonymous]
        [EnableCors("EnableCorsForLocalhost")]
        public UsuarioDTO GetRole(String token)
        {
            if (token != null & _sessionBL.CheckToken(token))
            {
                return _sessionBL.GetRole(token);
            }
            else
            {
                return null;
            }
        }
        // Modifica una session
        [HttpPut("/api/session/put")]
        [SwaggerOperation("/session/put {token}")]
        [EnableCors("EnableCorsForLocalhost")]
        public void Put(string session)
        {
        }
        

    }
}
